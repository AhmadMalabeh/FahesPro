using System;
using System.IO;
using System.Windows.Forms;

namespace CarTestUserInterFace
{
    public partial class frmPreview : Form
    {
        private readonly byte[] _pdfBytes;
        private MemoryStream _viewStream; // نخليه حي طوال عمر الفورم

        public frmPreview(MemoryStream pdfStream)
        {
            InitializeComponent();

            if (pdfStream == null)
                throw new ArgumentNullException(nameof(pdfStream));

            // تأكد أن Position بالبداية (احتياط)
            if (pdfStream.CanSeek)
                pdfStream.Position = 0;

            _pdfBytes = pdfStream.ToArray();
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
            if (_pdfBytes == null || _pdfBytes.Length == 0)
            {
                MessageBox.Show("لا يوجد تقرير لعرضه.", "تنبيه");
                btnPrint.Enabled = false;
                return;
            }

            // Stream للعرض يبقى حي
            _viewStream = new MemoryStream(_pdfBytes, writable: false);
            pdfViewerControl1.Load(_viewStream);
        }

        private void frmPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            // مهم جدًا: فك ارتباط الـ viewer وحرر الموارد
            try { pdfViewerControl1.Unload(); } catch { /* تجاهل */ }

            _viewStream?.Dispose();
            _viewStream = null;
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                await System.Threading.Tasks.Task.Run(() =>
                {
                    clsPrintTestReport printer = new clsPrintTestReport();

                    using (MemoryStream printStream = new MemoryStream(_pdfBytes, writable: false))
                    {
                        // احتياط: Position بالبداية
                        if (printStream.CanSeek) printStream.Position = 0;

                        printer.SendToPrinter(printStream);
                    }
                });

                MessageBox.Show("تم إرسال التقرير للطابعة.", "عملية ناجحة");
            }
            catch (Exception ex)
            {
                // هنا ممتاز تسجلها في Logger عندك
                MessageBox.Show("حدث خطأ أثناء الطباعة:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnPrint.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveAsPdfFile_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                clsPrintTestReport printer = new clsPrintTestReport();

                using (MemoryStream printStream = new MemoryStream(_pdfBytes, writable: false))
                {
                    if (printStream.CanSeek)
                        printStream.Position = 0;

                    printer.SavePdfToFile(printStream);
                }

                MessageBox.Show("تم حفظ التقرير بنجاح.", "عملية ناجحة");
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ:\n" + ex.Message,
                                "خطأ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnPrint.Enabled = true;
            }
        }
    }
}

