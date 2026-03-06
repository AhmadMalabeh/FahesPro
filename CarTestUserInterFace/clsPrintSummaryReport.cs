using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace CarTestUserInterFace
{
    public class clsPrintSummaryReport
    {
        private float MmToPoint(float mm) => mm * 2.83465f;

        // =========================
        // Report Types
        // =========================
        public enum ReportType
        {
            InspectionsFromDateToDate,          // تقرير الفحوصات من تاريخ إلى تاريخ
            PayLaterByCustomer,                 // تقرير ذمم حسب اسم مشتري
            PayLaterFromDateToDate,             // تقرير الذمم من تاريخ إلى تاريخ
            TestsAndFinancial,                  // فحوصات + مصاريف (مالي عام)
            FinancialOnly                       // مصاريف فقط
        }

        // =========================
        // Font Cache (مرة واحدة)
        // =========================
        private static byte[] _cachedFontData;

        private static byte[] GetFontData()
        {
            if (_cachedFontData != null) return _cachedFontData;

            string fontPath = Path.Combine(Application.StartupPath, "arial.ttf");
            if (!File.Exists(fontPath))
                throw new FileNotFoundException("ملف الخط arial.ttf غير موجود بجانب البرنامج.", fontPath);

            _cachedFontData = File.ReadAllBytes(fontPath);
            return _cachedFontData;
        }

        private static PdfTrueTypeFont CreateFont(float size)
        {
            return new PdfTrueTypeFont(new MemoryStream(GetFontData()), size);
        }

        // 1) تجهيز جدول RTL
        private DataTable PrepareRtlTable(DataTable sourceTable, bool isInspectionTable)
        {
            DataTable rtlTable = new DataTable();

            if (isInspectionTable)
            {
                if (sourceTable.Columns.Contains("InspectionID")) sourceTable.Columns.Remove("InspectionID");
            }
            else
            {
                if (sourceTable.Columns.Contains("ExpenseID")) sourceTable.Columns.Remove("ExpenseID");
            }

            for (int i = sourceTable.Columns.Count - 1; i >= 0; i--)
                rtlTable.Columns.Add(sourceTable.Columns[i].ColumnName);

            foreach (DataRow row in sourceTable.Rows)
            {
                DataRow newRow = rtlTable.NewRow();

                for (int i = 0; i < sourceTable.Columns.Count; i++)
                {
                    object value = row[i];

                    if (value is DateTime dateValue)
                        value = dateValue.ToString("yyyy/MM/dd");

                    else if (isInspectionTable && sourceTable.Columns[i].ColumnName == "RatPayLatter1" && value != DBNull.Value)
                    {
                        bool isPaidLater = Convert.ToBoolean(value);
                        value = isPaidLater ? "ذمم" : "كاش";
                    }

                    newRow[sourceTable.Columns.Count - 1 - i] = value;
                }

                rtlTable.Rows.Add(newRow);
            }

            return rtlTable;
        }

        // =========================
        // Public API
        // =========================
        public MemoryStream CreateCustomReportStream(
            DataTable dtInspections,
            DataTable dtExpenses,
            string reportTitle,
            ReportType reportType)
        {
            PdfDocument document = new PdfDocument();

            try
            {
                document.PageSettings.Orientation = PdfPageOrientation.Portrait;
                float margin = MmToPoint(10);

                // Fonts
                PdfFont tableFont = CreateFont(8);
                PdfFont titleFont = CreateFont(14);
                PdfFont footerFont = CreateFont(9);
                PdfFont subTitleFont = CreateFont(12);
                PdfFont summaryFont = CreateFont(11);

                PdfStringFormat rtlCenter = new PdfStringFormat { TextDirection = PdfTextDirection.RightToLeft, Alignment = PdfTextAlignment.Center };
                PdfStringFormat rtlRight = new PdfStringFormat { TextDirection = PdfTextDirection.RightToLeft, Alignment = PdfTextAlignment.Right };

                // Header
                PdfPageTemplateElement header = new PdfPageTemplateElement(document.PageSettings.Width, 40);
                header.Graphics.DrawString(reportTitle, titleFont, PdfBrushes.Black, new RectangleF(0, 10, header.Width, 25), rtlCenter);
                document.Template.Top = header;

                // Footer
                PdfPageTemplateElement footer = new PdfPageTemplateElement(document.PageSettings.Width, 30);
                PdfPageNumberField pageNumber = new PdfPageNumberField(footerFont, PdfBrushes.Black);
                PdfPageCountField pageCount = new PdfPageCountField(footerFont, PdfBrushes.Black);
                PdfCompositeField pageField = new PdfCompositeField(footerFont, PdfBrushes.Black, "الصفحة {0} من {1}", pageNumber, pageCount);
                pageField.StringFormat = rtlCenter;
                pageField.Draw(footer.Graphics, new PointF(0, 8));
                document.Template.Bottom = footer;

                PdfPage page = document.Pages.Add();
                PdfLayoutResult result = null;
                float yPosition = 0;

                // =========================
                // 1) جدول الفحوصات (إذا موجود)
                // =========================
                if (dtInspections != null && dtInspections.Rows.Count > 0)
                {
                    page.Graphics.DrawString("كشف الفحوصات", subTitleFont, PdfBrushes.Black,
                        new RectangleF(0, yPosition, page.GetClientSize().Width - margin, 20), rtlRight);

                    PdfGrid gridIns = new PdfGrid();
                    gridIns.DataSource = PrepareRtlTable(dtInspections.Copy(), true);

                    if (gridIns.Headers.Count > 0)
                    {
                        string[] headers = { "سعر الفحص", "دفع لاحقا", "الفاحص", "المشتري", "التاريخ", "الشاصي", "اللوحة", "الموديل", "نوع الفحص" };
                        for (int i = 0; i < Math.Min(headers.Length, gridIns.Headers[0].Cells.Count); i++)
                            gridIns.Headers[0].Cells[i].Value = headers[i];
                    }

                    _ApplyGridStyle(gridIns, tableFont, rtlRight);
                    result = gridIns.Draw(page, new PointF(margin, yPosition + 25));
                    yPosition = result.Bounds.Bottom + 30;
                }

                // =========================
                // 2) جدول المصاريف (إذا موجود)
                // =========================
                if (dtExpenses != null && dtExpenses.Rows.Count > 0)
                {
                    PdfPage currentPage = (result != null) ? result.Page : page;

                    if (result == null) yPosition = 0;

                    if (yPosition > currentPage.GetClientSize().Height - 150)
                    {
                        currentPage = document.Pages.Add();
                        yPosition = 0;
                    }

                    currentPage.Graphics.DrawString("كشف المصاريف", subTitleFont, PdfBrushes.Black,
                        new RectangleF(0, yPosition, currentPage.GetClientSize().Width - margin, 20), rtlRight);

                    PdfGrid gridExp = new PdfGrid();
                    gridExp.DataSource = PrepareRtlTable(dtExpenses.Copy(), false);

                    if (gridExp.Headers.Count > 0)
                    {
                        string[] headers = { "بواسطة", "التاريخ", "المبلغ", "نوع المصروف", "الوصف" };
                        for (int i = 0; i < Math.Min(headers.Length, gridExp.Headers[0].Cells.Count); i++)
                            gridExp.Headers[0].Cells[i].Value = headers[i];
                    }

                    _ApplyGridStyle(gridExp, tableFont, rtlRight);
                    result = gridExp.Draw(currentPage, new PointF(margin, yPosition + 25));
                }

                // =========================
                // 3) الملخص حسب نوع التقرير
                // =========================
                if (result != null)
                {
                    DrawSummaryByType(
                        document,
                        result.Page,
                        result.Bounds.Bottom + 10, // تقليل المسافة قليلاً
                        reportType,
                        dtInspections,
                        dtExpenses,
                        summaryFont,
                        rtlRight
                    );
                }

                MemoryStream outStream = new MemoryStream();
                document.Save(outStream);
                outStream.Position = 0;
                return outStream;
            }
            finally
            {
                try { document.Close(true); } catch { }
            }
        }

        private void _ApplyGridStyle(PdfGrid grid, PdfFont font, PdfStringFormat format)
        {
            grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable1Light);
            grid.Style.Font = font;
            grid.Style.CellPadding = new PdfPaddings(4, 4, 4, 4);

            foreach (PdfGridColumn col in grid.Columns)
                col.Format = format;

            PdfGridCellStyle headerStyle = new PdfGridCellStyle
            {
                BackgroundBrush = PdfBrushes.White,
                TextBrush = PdfBrushes.Black,
                Font = font
            };

            if (grid.Headers.Count > 0)
                foreach (PdfGridCell cell in grid.Headers[0].Cells)
                    cell.Style = headerStyle;
        }

        // =========================================================
        // Summary (تم التعديل هنا لضمان عدم القفز لصفحة جديدة دون داعٍ)
        // =========================================================
        private void DrawSummaryByType(
            PdfDocument doc,
            PdfPage currentPage,
            float yPos,
            ReportType reportType,
            DataTable dtIns,
            DataTable dtExp,
            PdfFont font,
            PdfStringFormat format)
        {
            string summaryText = BuildSummaryText(reportType, dtIns, dtExp);

            if (string.IsNullOrWhiteSpace(summaryText))
                return;

            float maxWidth = currentPage.GetClientSize().Width - (MmToPoint(10) * 2);
            float requiredHeight = EstimateSummaryHeight(summaryText, font, maxWidth);

            // مساحة الأمان للفوتر (أقل من السابق لضمان استغلال الصفحة)
            float footerSpace = 40;

            // إذا كان الارتفاع المطلوب يتجاوز المتبقي من الصفحة الحالية
            if (yPos + requiredHeight > currentPage.GetClientSize().Height - footerSpace)
            {
                currentPage = doc.Pages.Add();
                yPos = 20; // بدء من أعلى الصفحة الجديدة بهامش بسيط
            }

            currentPage.Graphics.DrawString(summaryText, font, PdfBrushes.Black,
                new RectangleF(MmToPoint(10), yPos, maxWidth, requiredHeight),
                format);
        }

        // حساب الارتفاع بدقة بناءً على النص والخط
        private float EstimateSummaryHeight(string text, PdfFont font, float maxWidth)
        {
            int lines = 1;
            foreach (char c in text)
                if (c == '\n') lines++;

            // ارتفاع السطر الفعلي + مسافة بسيطة بين الأسطر
            float lineHeight = font.Height + 2;
            float totalHeight = (lines * lineHeight) + 10;

            return totalHeight;
        }

        private string BuildSummaryText(ReportType reportType, DataTable dtIns, DataTable dtExp)
        {
            switch (reportType)
            {
                case ReportType.FinancialOnly:
                    return BuildExpensesSummary(dtExp);

                case ReportType.TestsAndFinancial:
                    return BuildFullFinancialSummary(dtIns, dtExp);

                case ReportType.InspectionsFromDateToDate:
                    return BuildInspectionsSummary(dtIns);

                case ReportType.PayLaterByCustomer:
                    return BuildPayLaterCustomerSummary(dtIns);

                case ReportType.PayLaterFromDateToDate:
                    return BuildPayLaterSummary(dtIns);

                default:
                    return "";
            }
        }

        // =========================
        // Summary Builders
        // =========================
        private string BuildExpensesSummary(DataTable dtExp)
        {
            if (dtExp == null || dtExp.Rows.Count == 0) return "";

            decimal total = 0;
            foreach (DataRow r in dtExp.Rows)
                total += Convert.ToDecimal(r["Amount"]);

            return
                "\n--- ملخص المصاريف ---\n\n" +
                $"عدد الحركات: {dtExp.Rows.Count}\n" +
                $"إجمالي المصاريف: {total:N2}\n";
        }

        private string BuildInspectionsSummary(DataTable dtIns)
        {
            if (dtIns == null || dtIns.Rows.Count == 0) return "";

            decimal total = 0, cash = 0, later = 0;

            foreach (DataRow r in dtIns.Rows)
            {
                decimal value = Convert.ToDecimal(r["Voucher1"]);
                bool payLater = Convert.ToBoolean(r["RatPayLatter1"]);

                total += value;
                if (payLater) later += value;
                else cash += value;
            }

            return
                "\n--- ملخص الفحوصات ---\n\n" +
                $"عدد الفحوصات: {dtIns.Rows.Count}\n" +
                $"إجمالي الإيرادات: {total:N2}\n" +
                $"كاش: {cash:N2}\n" +
                $"ذمم: {later:N2}\n";
        }

        private string BuildPayLaterCustomerSummary(DataTable dtIns)
        {
            if (dtIns == null || dtIns.Rows.Count == 0) return "";

            decimal laterTotal = 0;
            int count = 0;

            foreach (DataRow r in dtIns.Rows)
            {
                bool payLater = Convert.ToBoolean(r["RatPayLatter1"]);
                if (!payLater) continue;

                laterTotal += Convert.ToDecimal(r["Voucher1"]);
                count++;
            }

            return
                "\n--- ملخص ذمم المشتري ---\n\n" +
                $"عدد الفحوصات الآجلة: {count}\n" +
                $"إجمالي الذمم: {laterTotal:N2}\n";
        }

        private string BuildPayLaterSummary(DataTable dtIns)
        {
            if (dtIns == null || dtIns.Rows.Count == 0) return "";

            decimal laterTotal = 0;
            int count = 0;

            foreach (DataRow r in dtIns.Rows)
            {
                bool payLater = Convert.ToBoolean(r["RatPayLatter1"]);
                if (!payLater) continue;

                laterTotal += Convert.ToDecimal(r["Voucher1"]);
                count++;
            }

            return
                "\n--- ملخص الذمم ---\n\n" +
                $"عدد الفحوصات الآجلة: {count}\n" +
                $"إجمالي الذمم: {laterTotal:N2}\n";
        }

        private string BuildFullFinancialSummary(DataTable dtIns, DataTable dtExp)
        {
            decimal totalRevenue = 0, totalCash = 0, totalLater = 0, expenses = 0;

            if (dtIns != null)
                foreach (DataRow r in dtIns.Rows)
                {
                    decimal value = Convert.ToDecimal(r["Voucher1"]);
                    bool payLater = Convert.ToBoolean(r["RatPayLatter1"]);

                    totalRevenue += value;
                    if (payLater) totalLater += value;
                    else totalCash += value;
                }

            if (dtExp != null)
                foreach (DataRow r in dtExp.Rows)
                    expenses += Convert.ToDecimal(r["Amount"]);

            return
                "\n--- ملخص الحركة المالية ---\n\n" +
                $"إجمالي الإيرادات: {totalRevenue:N2}\n" +
                $"إجمالي الكاش: {totalCash:N2}\n" +
                $"إجمالي الذمم: {totalLater:N2}\n\n" +
                $"إجمالي المصاريف: {expenses:N2}\n" +
                $"الصافي: {(totalRevenue - expenses):N2}\n";
        }
    }
}


