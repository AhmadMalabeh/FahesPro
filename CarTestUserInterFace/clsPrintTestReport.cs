using CarTestLogicalLayer;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Windows.Forms.PdfViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace CarTestUserInterFace
{
    public class clsPrintTestReport
    {
        // محول القياسات: من مليمتر إلى نقاط (Points)
        private float MmToPoint(float mm) => mm * 2.83465f;

        public MemoryStream CreateInspectionPdfStream(dynamic carData)
        {
            // === الخط: من مجلد البرنامج فقط ===
            string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "arial.ttf");
            if (!File.Exists(fontPath))
                throw new FileNotFoundException("ملف الخط arial.ttf غير موجود بجانب البرنامج.", fontPath);

            byte[] fontData = File.ReadAllBytes(fontPath);

            PdfDocument document = null;
            try
            {
                document = new PdfDocument();
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;

                // ✅ Stream واحد للخط وداخل using
                using (var fontStream = new MemoryStream(fontData, writable: false))
                {
                    // ملاحظة: إذا المكتبة تحتاج Stream لكل Font، نعمل Streams إضافية داخل using أيضًا
                    PdfFont arabicFont = new PdfTrueTypeFont(fontStream, 12);
                    PdfFont arabicFontForBodyTest = new PdfTrueTypeFont(new MemoryStream(fontData, false), 10);
                    PdfFont arabicFontForTests = new PdfTrueTypeFont(new MemoryStream(fontData, false), 14);
                    PdfFont arabicFontForMicanicTests = new PdfTrueTypeFont(new MemoryStream(fontData, false), 11);

                    // ✅ تخلّص من streams الإضافية أيضًا
                    // لأننا أنشأنا 3 MemoryStream إضافية فوق، نخليها داخل using:
                    // (نكتبها بالشكل الصحيح بدل السطرين أعلاه)
                }

                // ❗ خلّينا نكتبها بشكل "صحيح 100%" بدون أي stream متروك:
                using (var fs12 = new MemoryStream(fontData, false))
                using (var fs10 = new MemoryStream(fontData, false))
                using (var fs14 = new MemoryStream(fontData, false))
                using (var fs11 = new MemoryStream(fontData, false))
                {
                    PdfFont arabicFont = new PdfTrueTypeFont(fs12, 12);
                    PdfFont arabicFontForBodyTest = new PdfTrueTypeFont(fs10, 10);
                    PdfFont arabicFontForTests = new PdfTrueTypeFont(fs14, 14);
                    PdfFont arabicFontForMicanicTests = new PdfTrueTypeFont(fs11, 11);

                    PdfStringFormat format = new PdfStringFormat
                    {
                        TextDirection = PdfTextDirection.RightToLeft,
                        Alignment = PdfTextAlignment.Right
                    };

                    graphics.DrawString(carData.PlateNumber, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(150), MmToPoint(53)), format);

                    graphics.DrawString(carData.ShasiNumber, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(150), MmToPoint(61)), format);

                    graphics.DrawString(carData.CarType, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(150), MmToPoint(68)), format);

                    graphics.DrawString(carData.CustumerName, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(146), MmToPoint(83)), format);

                    graphics.DrawString(carData.CarColor, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(39), MmToPoint(53)), format);

                    graphics.DrawString(carData.CarModel, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(39), MmToPoint(61)), format);

                    graphics.DrawString(carData.TestDate, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(39), MmToPoint(69)), format);

                    graphics.DrawString(carData.FRShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(125), MmToPoint(122)), format);

                    graphics.DrawString(carData.FLShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(125), MmToPoint(130)), format);

                    graphics.DrawString(carData.BRShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(125), MmToPoint(139)), format);

                    graphics.DrawString(carData.BLShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(125), MmToPoint(148)), format);

                    graphics.DrawString(carData.EnginPerc, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(142), MmToPoint(160)), format);

                    graphics.DrawString(carData.EnginTest, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(130), MmToPoint(160)), format);

                    graphics.DrawString(carData.GearTest, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(130), MmToPoint(171)), format);

                    graphics.DrawString(carData.BakaksTest, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(130), MmToPoint(181)), format);

                    format.WordWrap = PdfWordWrapType.Word;
                    RectangleF bodyNotesRect = new RectangleF(MmToPoint(15), MmToPoint(200), MmToPoint(150), MmToPoint(60));
                    graphics.DrawString(carData.BodyTest, arabicFontForBodyTest, PdfBrushes.Black, bodyNotesRect, format);

                    graphics.DrawString(carData.TestPrice, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(24), MmToPoint(261)), format);

                    var stream = new MemoryStream();
                    document.Save(stream);
                    stream.Position = 0;
                    return stream;
                }
            }
            finally
            {
                // ✅ حتى لو صار خطأ بأي سطر، لا تترك document عايش
                if (document != null)
                {
                    try { document.Close(true); } catch { }
                }
            }
        }

        public MemoryStream CreateInspectionPdfStreamAsPDFFileWithTemplate(dynamic carData)
        {
            // === الخط: من مجلد البرنامج فقط ===
            string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "arial.ttf");
            if (!File.Exists(fontPath))
                throw new FileNotFoundException("ملف الخط arial.ttf غير موجود بجانب البرنامج.", fontPath);

            byte[] fontData = File.ReadAllBytes(fontPath);

            PdfDocument document = null;
            try
            {
                document = new PdfDocument();
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;

                // ✅ 1) ارسم الخلفية من Resources
                // 🔥 من وين أجيب اسم الصورة؟
                // افتح Resources.resx وشوف اسم الصورة في العمود Name
                // مثال: TemplateBg  => Properties.Resources.TemplateBg
                using (var imgMs = new MemoryStream())
                {
                    Properties.Resources.قالب_كرت_الفحص.Save(imgMs, System.Drawing.Imaging.ImageFormat.Png);
                    imgMs.Position = 0;

                    PdfBitmap bg = new PdfBitmap(imgMs);

                    float w = page.GetClientSize().Width;
                    float h = page.GetClientSize().Height;

                    graphics.DrawImage(bg, 0, 0, w, h);
                }

                // ✅ 2) الخطوط (Streams) بشكل صحيح بدون تسريب
                using (var fs12 = new MemoryStream(fontData, writable: false))
                using (var fs10 = new MemoryStream(fontData, writable: false))
                using (var fs14 = new MemoryStream(fontData, writable: false))
                using (var fs11 = new MemoryStream(fontData, writable: false))
                {
                    PdfFont arabicFont = new PdfTrueTypeFont(fs12, 10);
                    PdfFont arabicFontForBodyTest = new PdfTrueTypeFont(fs10, 10);
                    PdfFont arabicFontForTests = new PdfTrueTypeFont(fs14, 12);
                    PdfFont arabicFontForMicanicTests = new PdfTrueTypeFont(fs11, 11);

                    PdfStringFormat format = new PdfStringFormat
                    {
                        TextDirection = PdfTextDirection.RightToLeft,
                        Alignment = PdfTextAlignment.Right
                    };

                    graphics.DrawString(carData.PlateNumber, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(141), MmToPoint(63)), format);

                    graphics.DrawString(carData.ShasiNumber, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(141), MmToPoint(69.3f)), format);

                    graphics.DrawString(carData.CarType, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(141), MmToPoint(75.8f)), format);

                    graphics.DrawString(carData.CustumerName, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(139), MmToPoint(89)), format);

                    graphics.DrawString(carData.CarColor, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(46), MmToPoint(63)), format);

                    graphics.DrawString(carData.CarModel, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(46), MmToPoint(69.3f)), format);

                    graphics.DrawString(carData.TestDate, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(46), MmToPoint(75.8f)), format);

                    graphics.DrawString(carData.FRShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(125), MmToPoint(123)), format);

                    graphics.DrawString(carData.FLShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(125), MmToPoint(131)), format);

                    graphics.DrawString(carData.BRShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(125), MmToPoint(138.4f)), format);

                    graphics.DrawString(carData.BLShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(125), MmToPoint(146.1f)), format);

                    graphics.DrawString(carData.EnginPerc, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(134), MmToPoint(157)), format);

                    graphics.DrawString(carData.EnginTest, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(125), MmToPoint(157)), format);

                    graphics.DrawString(carData.GearTest, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(134), MmToPoint(166.5f)), format);

                    graphics.DrawString(carData.BakaksTest, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(134), MmToPoint(175)), format);

                    format.WordWrap = PdfWordWrapType.Word;
                    RectangleF bodyNotesRect = new RectangleF(MmToPoint(15), MmToPoint(190), MmToPoint(140), MmToPoint(60));
                    graphics.DrawString(carData.BodyTest, arabicFontForBodyTest, PdfBrushes.Black, bodyNotesRect, format);

                    graphics.DrawString(carData.TestPrice, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(24), MmToPoint(250)), format);

                    var stream = new MemoryStream();
                    document.Save(stream);
                    stream.Position = 0;
                    return stream;
                }
            }
            finally
            {
                if (document != null)
                {
                    try { document.Close(true); } catch { }
                }
            }
        }

        public void SendToPrinter(Stream pdfStream)
        {
            if (pdfStream == null)
                throw new ArgumentNullException(nameof(pdfStream));

            if (pdfStream.CanSeek)
                pdfStream.Position = 0;

            using (var pdfView = new PdfDocumentView())
            {
                try
                {
                    pdfView.Load(pdfStream);

                    var settings = new PrinterSettings(); // بدون using
                    string printerName = settings.PrinterName;

                    if (string.IsNullOrWhiteSpace(printerName))
                        throw new InvalidOperationException("لا يوجد طابعة افتراضية مضبوطة على الجهاز.");

                    pdfView.Print(printerName);
                }
                finally
                {
                    try { pdfView.Unload(); } catch { }
                }
            }
        }

        public void SavePdfToFile(Stream pdfStream)
        {
            if (pdfStream == null)
                throw new ArgumentNullException(nameof(pdfStream));

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "حفظ التقرير";
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                sfd.DefaultExt = "pdf";
                sfd.AddExtension = true;

                if (sfd.ShowDialog() != DialogResult.OK)
                    return; // المستخدم ألغى العملية

                // تأكد أن المؤشر بالبداية
                if (pdfStream.CanSeek)
                    pdfStream.Position = 0;

                using (var fileStream = new FileStream(sfd.FileName,
                                                       FileMode.Create,
                                                       FileAccess.Write,
                                                       FileShare.None))
                {
                    pdfStream.CopyTo(fileStream);
                }
            }
        }
    }
}
