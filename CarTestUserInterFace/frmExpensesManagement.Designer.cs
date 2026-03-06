namespace CarTestUserInterFace
{
    partial class frmExpensesManagement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbExpenseesType = new System.Windows.Forms.ComboBox();
            this.txtDiscription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudExpensesValue = new System.Windows.Forms.NumericUpDown();
            this.dgvExpensesData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.btnClearScreen = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpensesValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpensesData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 49);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(178, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "شاشة المصاريف اليومية";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(611, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "نوع المصروف";
            // 
            // cmbExpenseesType
            // 
            this.cmbExpenseesType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbExpenseesType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbExpenseesType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExpenseesType.FormattingEnabled = true;
            this.cmbExpenseesType.Location = new System.Drawing.Point(359, 93);
            this.cmbExpenseesType.Name = "cmbExpenseesType";
            this.cmbExpenseesType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbExpenseesType.Size = new System.Drawing.Size(246, 24);
            this.cmbExpenseesType.TabIndex = 3;
            // 
            // txtDiscription
            // 
            this.txtDiscription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscription.Location = new System.Drawing.Point(12, 55);
            this.txtDiscription.Name = "txtDiscription";
            this.txtDiscription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiscription.Size = new System.Drawing.Size(641, 27);
            this.txtDiscription.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(659, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "الوصف";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(298, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "القيمة";
            // 
            // nudExpensesValue
            // 
            this.nudExpensesValue.DecimalPlaces = 2;
            this.nudExpensesValue.Location = new System.Drawing.Point(131, 96);
            this.nudExpensesValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudExpensesValue.Name = "nudExpensesValue";
            this.nudExpensesValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nudExpensesValue.Size = new System.Drawing.Size(161, 20);
            this.nudExpensesValue.TabIndex = 7;
            this.nudExpensesValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudExpensesValue.ThousandsSeparator = true;
            // 
            // dgvExpensesData
            // 
            this.dgvExpensesData.AllowUserToAddRows = false;
            this.dgvExpensesData.AllowUserToDeleteRows = false;
            this.dgvExpensesData.BackgroundColor = System.Drawing.Color.White;
            this.dgvExpensesData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpensesData.Location = new System.Drawing.Point(0, 155);
            this.dgvExpensesData.Name = "dgvExpensesData";
            this.dgvExpensesData.ReadOnly = true;
            this.dgvExpensesData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvExpensesData.Size = new System.Drawing.Size(722, 168);
            this.dgvExpensesData.TabIndex = 8;
            this.dgvExpensesData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpensesData_CellDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageIndex = 0;
            this.btnClose.Location = new System.Drawing.Point(413, 329);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(113, 40);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "رحوع";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnDelete.Location = new System.Drawing.Point(278, 329);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(113, 40);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveResult.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveResult.ForeColor = System.Drawing.Color.White;
            this.btnSaveResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveResult.ImageIndex = 0;
            this.btnSaveResult.Location = new System.Drawing.Point(8, 329);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaveResult.Size = new System.Drawing.Size(113, 40);
            this.btnSaveResult.TabIndex = 44;
            this.btnSaveResult.Text = "حفظ";
            this.btnSaveResult.UseVisualStyleBackColor = false;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearScreen
            // 
            this.btnClearScreen.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClearScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearScreen.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearScreen.ForeColor = System.Drawing.Color.White;
            this.btnClearScreen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearScreen.ImageIndex = 0;
            this.btnClearScreen.Location = new System.Drawing.Point(548, 329);
            this.btnClearScreen.Name = "btnClearScreen";
            this.btnClearScreen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClearScreen.Size = new System.Drawing.Size(169, 40);
            this.btnClearScreen.TabIndex = 47;
            this.btnClearScreen.Text = "تنظيف الشاشة";
            this.btnClearScreen.UseVisualStyleBackColor = false;
            this.btnClearScreen.Click += new System.EventHandler(this.btnClearScreen_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.ImageIndex = 0;
            this.btnSearch.Location = new System.Drawing.Point(143, 329);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSearch.Size = new System.Drawing.Size(113, 40);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.Text = "بحث";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(565, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 19);
            this.label5.TabIndex = 49;
            this.label5.Text = "البحث حسب التاريخ";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(415, 133);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpFrom.Size = new System.Drawing.Size(99, 20);
            this.dtpFrom.TabIndex = 50;
            this.dtpFrom.Value = new System.DateTime(2026, 2, 11, 0, 0, 0, 0);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(254, 133);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpTo.Size = new System.Drawing.Size(99, 20);
            this.dtpTo.TabIndex = 51;
            this.dtpTo.Value = new System.DateTime(2026, 2, 11, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(520, 133);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(39, 19);
            this.label6.TabIndex = 52;
            this.label6.Text = "من:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(359, 134);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(42, 19);
            this.label7.TabIndex = 53;
            this.label7.Text = "الى:";
            // 
            // frmExpensesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 376);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClearScreen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.dgvExpensesData);
            this.Controls.Add(this.nudExpensesValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiscription);
            this.Controls.Add(this.cmbExpenseesType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmExpensesManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة المصاريف اليومية";
            this.Load += new System.EventHandler(this.frmExpensesManagement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpensesValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpensesData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExpenseesType;
        private System.Windows.Forms.TextBox txtDiscription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudExpensesValue;
        private System.Windows.Forms.DataGridView dgvExpensesData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.Button btnClearScreen;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}