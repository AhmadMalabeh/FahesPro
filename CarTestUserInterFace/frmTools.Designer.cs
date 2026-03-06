namespace CarTestUserInterFace
{
    partial class frmTools
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMinuName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIssueDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvToolsData = new System.Windows.Forms.DataGridView();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.btnClearScreen = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToolsData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 49);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(337, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "شاشة الأدوات";
            // 
            // cmbMinuName
            // 
            this.cmbMinuName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMinuName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMinuName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMinuName.FormattingEnabled = true;
            this.cmbMinuName.IntegralHeight = false;
            this.cmbMinuName.Location = new System.Drawing.Point(558, 91);
            this.cmbMinuName.Name = "cmbMinuName";
            this.cmbMinuName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMinuName.Size = new System.Drawing.Size(217, 24);
            this.cmbMinuName.TabIndex = 1;
            this.cmbMinuName.SelectedIndexChanged += new System.EventHandler(this.cmbMinuName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(807, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "نوع القائمة";
            // 
            // txtIssueDescription
            // 
            this.txtIssueDescription.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueDescription.Location = new System.Drawing.Point(12, 55);
            this.txtIssueDescription.Name = "txtIssueDescription";
            this.txtIssueDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIssueDescription.Size = new System.Drawing.Size(763, 23);
            this.txtIssueDescription.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(785, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "وصف المشكلة";
            // 
            // dgvToolsData
            // 
            this.dgvToolsData.AllowUserToAddRows = false;
            this.dgvToolsData.AllowUserToDeleteRows = false;
            this.dgvToolsData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToolsData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvToolsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvToolsData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvToolsData.Location = new System.Drawing.Point(0, 121);
            this.dgvToolsData.Name = "dgvToolsData";
            this.dgvToolsData.ReadOnly = true;
            this.dgvToolsData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToolsData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvToolsData.Size = new System.Drawing.Size(885, 234);
            this.dgvToolsData.TabIndex = 5;
            this.dgvToolsData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvToolsData_CellDoubleClick);
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveResult.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveResult.ForeColor = System.Drawing.Color.White;
            this.btnSaveResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveResult.ImageIndex = 0;
            this.btnSaveResult.Location = new System.Drawing.Point(12, 361);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaveResult.Size = new System.Drawing.Size(113, 40);
            this.btnSaveResult.TabIndex = 5;
            this.btnSaveResult.Text = "  حفظ";
            this.btnSaveResult.UseVisualStyleBackColor = false;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // btnClearScreen
            // 
            this.btnClearScreen.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClearScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearScreen.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearScreen.ForeColor = System.Drawing.Color.White;
            this.btnClearScreen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearScreen.ImageIndex = 0;
            this.btnClearScreen.Location = new System.Drawing.Point(704, 361);
            this.btnClearScreen.Name = "btnClearScreen";
            this.btnClearScreen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClearScreen.Size = new System.Drawing.Size(169, 40);
            this.btnClearScreen.TabIndex = 6;
            this.btnClearScreen.Text = "تنظيف الشاشة";
            this.btnClearScreen.UseVisualStyleBackColor = false;
            this.btnClearScreen.Click += new System.EventHandler(this.btnClearScreen_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageIndex = 0;
            this.btnDelete.Location = new System.Drawing.Point(150, 361);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(113, 40);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageIndex = 0;
            this.btnClose.Location = new System.Drawing.Point(288, 361);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(113, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "رحوع";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 405);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClearScreen);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.dgvToolsData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIssueDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMinuName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة الادوات";
            this.Load += new System.EventHandler(this.frmTools_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToolsData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMinuName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIssueDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvToolsData;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.Button btnClearScreen;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}