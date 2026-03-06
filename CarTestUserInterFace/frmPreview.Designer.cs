namespace CarTestUserInterFace
{
    partial class frmPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings messageBoxSettings4 = new Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings();
            Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings pdfViewerPrinterSettings4 = new Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreview));
            Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings textSearchSettings4 = new Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings();
            this.pdfViewerControl1 = new Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveAsPdfFile = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pdfViewerControl1
            // 
            this.pdfViewerControl1.CursorMode = Syncfusion.Windows.Forms.PdfViewer.PdfViewerCursorMode.SelectTool;
            this.pdfViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewerControl1.EnableContextMenu = true;
            this.pdfViewerControl1.EnableNotificationBar = true;
            this.pdfViewerControl1.HorizontalScrollOffset = 0;
            this.pdfViewerControl1.IsBookmarkEnabled = true;
            this.pdfViewerControl1.IsTextSearchEnabled = true;
            this.pdfViewerControl1.IsTextSelectionEnabled = true;
            this.pdfViewerControl1.Location = new System.Drawing.Point(0, 48);
            messageBoxSettings4.EnableNotification = true;
            this.pdfViewerControl1.MessageBoxSettings = messageBoxSettings4;
            this.pdfViewerControl1.MinimumZoomPercentage = 50;
            this.pdfViewerControl1.Name = "pdfViewerControl1";
            this.pdfViewerControl1.PageBorderThickness = 1;
            pdfViewerPrinterSettings4.Copies = 1;
            pdfViewerPrinterSettings4.PageOrientation = Syncfusion.Windows.PdfViewer.PdfViewerPrintOrientation.Auto;
            pdfViewerPrinterSettings4.PageSize = Syncfusion.Windows.PdfViewer.PdfViewerPrintSize.ActualSize;
            pdfViewerPrinterSettings4.PrintLocation = ((System.Drawing.PointF)(resources.GetObject("pdfViewerPrinterSettings4.PrintLocation")));
            pdfViewerPrinterSettings4.ShowPrintStatusDialog = true;
            this.pdfViewerControl1.PrinterSettings = pdfViewerPrinterSettings4;
            this.pdfViewerControl1.ReferencePath = null;
            this.pdfViewerControl1.ScrollDisplacementValue = 0;
            this.pdfViewerControl1.ShowHorizontalScrollBar = true;
            this.pdfViewerControl1.ShowToolBar = false;
            this.pdfViewerControl1.ShowVerticalScrollBar = true;
            this.pdfViewerControl1.Size = new System.Drawing.Size(800, 402);
            this.pdfViewerControl1.SpaceBetweenPages = 8;
            this.pdfViewerControl1.TabIndex = 0;
            this.pdfViewerControl1.Text = "pdfViewerControl1";
            textSearchSettings4.CurrentInstanceColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(64)))));
            textSearchSettings4.HighlightAllInstance = true;
            textSearchSettings4.OtherInstanceColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pdfViewerControl1.TextSearchSettings = textSearchSettings4;
            this.pdfViewerControl1.ThemeName = "Default";
            this.pdfViewerControl1.VerticalScrollOffset = 0;
            this.pdfViewerControl1.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.Default;
            this.pdfViewerControl1.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.Default;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveAsPdfFile);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 48);
            this.panel1.TabIndex = 1;
            // 
            // btnSaveAsPdfFile
            // 
            this.btnSaveAsPdfFile.Location = new System.Drawing.Point(98, 3);
            this.btnSaveAsPdfFile.Name = "btnSaveAsPdfFile";
            this.btnSaveAsPdfFile.Size = new System.Drawing.Size(89, 39);
            this.btnSaveAsPdfFile.TabIndex = 2;
            this.btnSaveAsPdfFile.Text = "حفظ كملف";
            this.btnSaveAsPdfFile.UseVisualStyleBackColor = true;
            this.btnSaveAsPdfFile.Click += new System.EventHandler(this.btnSaveAsPdfFile_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(3, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(89, 39);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(193, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 39);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "رجوع";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pdfViewerControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frmPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة مراجعة التقرير";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPreview_FormClosed);
            this.Load += new System.EventHandler(this.frmPreview_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl pdfViewerControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveAsPdfFile;
    }
}