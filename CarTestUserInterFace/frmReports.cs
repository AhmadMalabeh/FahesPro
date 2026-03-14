using CarTestLogicalLayer;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CarTestUserInterFace
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();

            DataTable dtAllIssues = clsTools.GetAllIssues();

            // 1. إنشاء نسخة مستقلة لفحص الشصي
            DataView CustumerName = new DataView(dtAllIssues);
            CustumerName.RowFilter = "MinuName = 'اسم المشتري'";
            cmbCustumerName.DisplayMember = "CarIssue1";
            cmbCustumerName.ValueMember = "CarICode1";
            cmbCustumerName.DataSource = CustumerName;
            cmbCustumerName.SelectedIndex = -1;
            
        }

        
        enum enMode
        {
            ReportFromDateToDate,
            ReportForPayLaterTests,
            ReportPayLatterFromDateToDate,
            TestsAndFinancialReport, // الخيار الرابع
            FinancialOnlyReport,      // الخيار الخامس
            DebtSummaryByCustomer
        };

        enMode Mode;
        private DataTable _dtResult;          // للفحوصات
        private DataTable _dtExpensesResult;  // للمصاريف

        private void FillFieldsWithData(DataTable dt)
        {
            txtTestsSum.Text = "0";
            txtPriceSum.Text = "0";

            if (dt != null && dt.Rows.Count > 0)
            {
                txtTestsSum.Text = dt.Rows.Count.ToString();
                object sumObject = dt.Compute("SUM(Voucher1)", string.Empty);
                txtPriceSum.Text = (sumObject != DBNull.Value) ? Convert.ToDouble(sumObject).ToString("N2") : "0";
            }

            // تفعيل زر الطباعة إذا وجد أي نوع من البيانات
            btnPrint.Enabled = (dt != null && dt.Rows.Count > 0) || (_dtExpensesResult != null && _dtExpensesResult.Rows.Count > 0);
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            _dtResult = null;
            _dtExpensesResult = null;
            btnPrint.Enabled = false;

            if (DTFrom.Value.Date > DTTo.Value.Date)
            {
                MessageBox.Show("تاريخ البدء لا يمكن أن يكون بعد تاريخ النهاية", "خطأ");
                return;
            }

            switch (Mode)
            {
                case enMode.ReportFromDateToDate:
                    _dtResult = clsCarTest.GetInfoFromDateToDateForReports(DTFrom.Value.Date, DTTo.Value.Date);
                    break;
                case enMode.ReportForPayLaterTests:
                    _dtResult = clsCarTest.GetAllTestByCustumerNameAndPayLatterForReport(cmbCustumerName.Text, DTFrom.Value.Date, DTTo.Value.Date);
                    break;
                case enMode.ReportPayLatterFromDateToDate:
                    _dtResult = clsCarTest.GetPayLatterReportsFromDateToDate(DTFrom.Value.Date, DTTo.Value.Date);
                    break;
                case enMode.TestsAndFinancialReport:
                    _dtResult = clsCarTest.GetInfoFromDateToDateForReports(DTFrom.Value.Date, DTTo.Value.Date);
                    _dtExpensesResult = clsDialyExpenses.GetAllExpensesBettwenTowDates(DTFrom.Value.Date, DTTo.Value.Date);
                    break;
                case enMode.FinancialOnlyReport:
                    _dtExpensesResult = clsDialyExpenses.GetAllExpensesBettwenTowDates(DTFrom.Value.Date, DTTo.Value.Date);
                    break;
                case enMode.DebtSummaryByCustomer:
                    _dtResult = clsCarTest.GetDebtSummaryByCustomer();

                    if (_dtResult != null && _dtResult.Rows.Count > 0)
                    {
                        int totalCars = 0;
                        double grandTotal = 0;

                        foreach (DataRow row in _dtResult.Rows)
                        {
                            totalCars += Convert.ToInt32(row["عدد المركبات"]);
                            grandTotal += Convert.ToDouble(row["إجمالي المبلغ المستحق"]);
                        }

                        txtTestsSum.Text = totalCars.ToString();
                        txtPriceSum.Text = grandTotal.ToString("N2");
                        btnPrint.Enabled = true;
                    }
                    return; // ← مهم جداً — يمنع استدعاء FillFieldsWithData بعده
            }

            FillFieldsWithData(_dtResult);
            if (Mode == enMode.FinancialOnlyReport && _dtExpensesResult != null) btnPrint.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPrintSummaryReport summaryPrinter = new clsPrintSummaryReport();

            // ===== معالجة تقرير ملخص الذمم بشكل منفصل =====
            if (Mode == enMode.DebtSummaryByCustomer)
            {
                if (_dtResult == null || _dtResult.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد ذمم مالية حالياً", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MemoryStream debtMs = summaryPrinter.CreateDebtSummaryReport(_dtResult);
                if (debtMs == null) return;

                using (debtMs)
                using (frmPreview preview = new frmPreview(debtMs))
                {
                    preview.ShowDialog();
                }
                return;
            }

            // ===== باقي التقارير =====
            string title = "تقرير فحص المركبات";
            clsPrintSummaryReport.ReportType reportType = clsPrintSummaryReport.ReportType.InspectionsFromDateToDate;

            switch (Mode)
            {
                case enMode.ReportFromDateToDate:
                    title = "تقرير الفحوصات حسب التاريخ";
                    reportType = clsPrintSummaryReport.ReportType.InspectionsFromDateToDate;
                    break;

                case enMode.ReportForPayLaterTests:
                    title = $"تقرير ذمم: {cmbCustumerName.Text}";
                    reportType = clsPrintSummaryReport.ReportType.PayLaterByCustomer;
                    break;

                case enMode.ReportPayLatterFromDateToDate:
                    title = "تقرير الذمم حسب التاريخ";
                    reportType = clsPrintSummaryReport.ReportType.PayLaterFromDateToDate;
                    break;

                case enMode.TestsAndFinancialReport:
                    title = "التقرير المالي العام";
                    reportType = clsPrintSummaryReport.ReportType.TestsAndFinancial;
                    break;

                case enMode.FinancialOnlyReport:
                    title = "تقرير المصاريف المالية";
                    reportType = clsPrintSummaryReport.ReportType.FinancialOnly;
                    break;
            }

            MemoryStream ms = summaryPrinter.CreateCustomReportStream(
                _dtResult, _dtExpensesResult, title, reportType);

            if (ms == null) return;

            using (ms)
            using (frmPreview preview = new frmPreview(ms))
            {
                preview.ShowDialog();
            }
        }



        // ربط الـ RadioButtons بالأوضاع (Modes)
        private void rdDateToDateReport_CheckedChanged(object sender, EventArgs e) { Mode = enMode.ReportFromDateToDate; cmbCustumerName.Enabled = false; }
        private void rdPayLatterReport_CheckedChanged(object sender, EventArgs e) { Mode = enMode.ReportForPayLaterTests; cmbCustumerName.Enabled = true; }
        private void rdbPayLaterFromDateToDate_CheckedChanged(object sender, EventArgs e) { Mode = enMode.ReportPayLatterFromDateToDate; cmbCustumerName.Enabled = false; }
        private void rbTestsAndFinancial_CheckedChanged(object sender, EventArgs e) { Mode = enMode.TestsAndFinancialReport; cmbCustumerName.Enabled = false; }
        private void rbFinancialOnly_CheckedChanged(object sender, EventArgs e) { Mode = enMode.FinancialOnlyReport; cmbCustumerName.Enabled = false; }
        private void rdoDebtSummary_CheckedChanged(object sender, EventArgs e)
        {
            Mode = enMode.DebtSummaryByCustomer;
            cmbCustumerName.Enabled = false;
            DTFrom.Enabled = false;
            DTTo.Enabled = false;
        }
        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void frmReports_Load(object sender, EventArgs e)
        {
            Mode = enMode.ReportFromDateToDate;
            cmbCustumerName.Enabled = false;
            btnPrint.Enabled = false;
        }

        private void btnPrevDate_Click(object sender, EventArgs e)
        {
            DTFrom.Value = DTFrom.Value.AddDays(-1);
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            if (DTFrom.Value < DateTime.Today)
            {
                DTFrom.Value = DTFrom.Value.AddDays(1);
            }
            else
            {
                return;
            }
        }
    }
}
