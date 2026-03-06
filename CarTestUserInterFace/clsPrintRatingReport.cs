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

    
    public class clsPrintRatingReport
    {
        private float MmToPoint(float mm) => mm * 2.83465f;

        private void DrawCheckMark(PdfGraphics graphics, RectangleF rect, bool value, float markSizeMm = 6)
        {
            float markSize = MmToPoint(markSizeMm);

            // نحسب نقطة البداية بحيث تكون العلامة في وسط المستطيل
            float startX = rect.X + (rect.Width - markSize) / 2;
            float startY = rect.Y + (rect.Height - markSize) / 2;

            PdfPen pen = new PdfPen(PdfBrushes.Black, 1.5f);

            if (value) // ✔
            {
                graphics.DrawLine(pen,
                    startX,
                    startY + markSize * 0.6f,
                    startX + markSize * 0.4f,
                    startY + markSize);

                graphics.DrawLine(pen,
                    startX + markSize * 0.4f,
                    startY + markSize,
                    startX + markSize,
                    startY);
            }
            else // ✖
            {
                graphics.DrawLine(pen,
                    startX, startY,
                    startX + markSize, startY + markSize);

                graphics.DrawLine(pen,
                    startX + markSize, startY,
                    startX, startY + markSize);
            }
        }


        public MemoryStream CreatRatingPdfStream(dynamic carData)
        {
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
                        new PointF(MmToPoint(157), MmToPoint(89)), format);

                    graphics.DrawString(carData.ShasiNumber, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(99), MmToPoint(60)), format);

                    graphics.DrawString(carData.CarType, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(157), MmToPoint(60)), format);

                    

                    graphics.DrawString(carData.CarColor, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(157), MmToPoint(74)), format);

                    graphics.DrawString(carData.CarModel, arabicFont, PdfBrushes.Black,
                        new PointF(MmToPoint(41), MmToPoint(89)), format);

                    graphics.DrawString(carData.TestDate, arabicFontForBodyTest, PdfBrushes.Black,
                        new PointF(MmToPoint(20), MmToPoint(20)), format);

                    graphics.DrawString(carData.FRShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(139), MmToPoint(103)), format);

                    graphics.DrawString(carData.FLShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(139), MmToPoint(115)), format);

                    graphics.DrawString(carData.BRShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(139), MmToPoint(126)), format);

                    graphics.DrawString(carData.BLShasi, arabicFontForTests, PdfBrushes.Black,
                        new PointF(MmToPoint(139), MmToPoint(137)), format);

                    graphics.DrawString(carData.EnginPerc, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(139), MmToPoint(148)), format);

                    graphics.DrawString(carData.EnginTest, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(129), MmToPoint(148)), format);

                    graphics.DrawString(carData.GearTest, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(139), MmToPoint(159)), format);

                    graphics.DrawString(carData.BakaksTest, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(139), MmToPoint(170)), format);

                    graphics.DrawString(carData.RegstrationNumber, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(99), MmToPoint(74)), format);

                    graphics.DrawString(carData.UseType, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(41), MmToPoint(60)), format);

                    graphics.DrawString(carData.EnginCapacity, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(41), MmToPoint(75)), format);


                    graphics.DrawString(carData.EnginNumber, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(99), MmToPoint(89)), format);

                    graphics.DrawString(carData.CarStatius, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(168), MmToPoint(217)), format);

                    graphics.DrawString(carData.BodyValue, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(135), MmToPoint(228)), format);

                    graphics.DrawString(carData.StampValue, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(45), MmToPoint(228)), format);

                    graphics.DrawString(carData.TotalValue, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(118), MmToPoint(236)), format);

                    graphics.DrawString(carData.TotalValueAsString, arabicFontForMicanicTests, PdfBrushes.Black,
                        new PointF(MmToPoint(78), MmToPoint(236)), format);

                    


                    RectangleF checkRect = new RectangleF(
                     MmToPoint(125),
                     MmToPoint(177),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect, carData.chkItem1, 2);

                    RectangleF checkRect2 = new RectangleF(
                     MmToPoint(106),
                     MmToPoint(177),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect2, carData.chkItem2, 2);

                    RectangleF checkRect3 = new RectangleF(
                     MmToPoint(87),
                     MmToPoint(177),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect3, carData.chkItem3, 2);

                    RectangleF checkRect4 = new RectangleF(
                     MmToPoint(77),
                     MmToPoint(177),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect4, carData.chkItem4, 2);

                    RectangleF checkRect5 = new RectangleF(
                     MmToPoint(60.5f),
                     MmToPoint(177),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect5, carData.chkItem5, 2);

                    RectangleF checkRect6 = new RectangleF(
                     MmToPoint(46),
                     MmToPoint(177),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect6, carData.chkItem6, 2);

                    RectangleF checkRect7 = new RectangleF(
                     MmToPoint(32),
                     MmToPoint(177),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect7, carData.chkItem7, 2);


                    RectangleF checkRect8 = new RectangleF(
                     MmToPoint(12),
                     MmToPoint(177),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect8, carData.chkItem8, 2);

                    RectangleF checkRect9 = new RectangleF(
                     MmToPoint(0),
                     MmToPoint(174.5f),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect9, carData.chkItem9, 2);


                    RectangleF checkRect10 = new RectangleF(
                     MmToPoint(105),
                     MmToPoint(241),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect10, carData.chkItem10, 2);

                    RectangleF checkRect11 = new RectangleF(
                     MmToPoint(105),
                     MmToPoint(245.3f),
                     MmToPoint(10),
                     MmToPoint(10)
                     );

                    DrawCheckMark(graphics, checkRect11, carData.chkItem11, 2);




                    format.WordWrap = PdfWordWrapType.Word;
                    RectangleF bodyNotesRect = new RectangleF(MmToPoint(13), MmToPoint(192), MmToPoint(128), MmToPoint(20));
                    graphics.DrawString(carData.BodyTest, arabicFontForBodyTest, PdfBrushes.Black, bodyNotesRect, format);

                    //graphics.DrawRectangle(PdfPens.Red, bodyNotesRect);

                    format.WordWrap = PdfWordWrapType.Word;
                    RectangleF OthersRect = new RectangleF(MmToPoint(0), MmToPoint(185), MmToPoint(123), MmToPoint(20));
                    graphics.DrawString(carData.Others, arabicFontForBodyTest, PdfBrushes.Black, OthersRect, format);

                    //graphics.DrawRectangle(PdfPens.Red, OthersRect);


                    RectangleF CustumerNameRect = new RectangleF(MmToPoint(0), MmToPoint(43), MmToPoint(20), MmToPoint(20));
                    graphics.DrawString(carData.CustumerName, arabicFontForBodyTest, PdfBrushes.Black, CustumerNameRect, format);

                   // graphics.DrawRectangle(PdfPens.Red, CustumerNameRect);


                    RectangleF BankNameRect = new RectangleF(MmToPoint(0), MmToPoint(28), MmToPoint(40), MmToPoint(10));
                    graphics.DrawString(carData.Bank, arabicFontForBodyTest, PdfBrushes.Black, BankNameRect, format);

                   // graphics.DrawRectangle(PdfPens.Red, BankNameRect);


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
    }
}
