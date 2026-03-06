namespace CarTestUserInterFace
{
    partial class frmReports
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
            this.btntest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtPriceSum = new System.Windows.Forms.TextBox();
            this.txtTestsSum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DTTo = new System.Windows.Forms.DateTimePicker();
            this.DTFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCustumerName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdbPayLaterFromDateToDate = new System.Windows.Forms.RadioButton();
            this.rdDateToDateReport = new System.Windows.Forms.RadioButton();
            this.rdPayLatterReport = new System.Windows.Forms.RadioButton();
            this.btnPrevDate = new System.Windows.Forms.Button();
            this.btnNextDate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 57);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(219, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "شاشة التقارير";
            // 
            // btntest
            // 
            this.btntest.BackColor = System.Drawing.Color.SteelBlue;
            this.btntest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntest.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntest.ForeColor = System.Drawing.Color.White;
            this.btntest.Location = new System.Drawing.Point(54, 381);
            this.btntest.Margin = new System.Windows.Forms.Padding(0);
            this.btntest.Name = "btntest";
            this.btntest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btntest.Size = new System.Drawing.Size(174, 45);
            this.btntest.TabIndex = 32;
            this.btntest.Text = "بحث";
            this.btntest.UseVisualStyleBackColor = false;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(434, 381);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(174, 45);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "رجوع";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(54, 443);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrint.Size = new System.Drawing.Size(554, 45);
            this.btnPrint.TabIndex = 30;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtPriceSum
            // 
            this.txtPriceSum.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceSum.Location = new System.Drawing.Point(54, 168);
            this.txtPriceSum.Name = "txtPriceSum";
            this.txtPriceSum.ReadOnly = true;
            this.txtPriceSum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceSum.Size = new System.Drawing.Size(121, 27);
            this.txtPriceSum.TabIndex = 29;
            // 
            // txtTestsSum
            // 
            this.txtTestsSum.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestsSum.Location = new System.Drawing.Point(54, 126);
            this.txtTestsSum.Name = "txtTestsSum";
            this.txtTestsSum.ReadOnly = true;
            this.txtTestsSum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTestsSum.Size = new System.Drawing.Size(121, 27);
            this.txtTestsSum.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(206, 172);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(119, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "مجموع القيمة:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(202, 129);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(123, 19);
            this.label6.TabIndex = 26;
            this.label6.Text = "عدد الفحوصات:";
            // 
            // DTTo
            // 
            this.DTTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTTo.Location = new System.Drawing.Point(448, 177);
            this.DTTo.Name = "DTTo";
            this.DTTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTTo.Size = new System.Drawing.Size(104, 20);
            this.DTTo.TabIndex = 25;
            // 
            // DTFrom
            // 
            this.DTFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFrom.Location = new System.Drawing.Point(448, 134);
            this.DTFrom.Name = "DTFrom";
            this.DTFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTFrom.Size = new System.Drawing.Size(104, 20);
            this.DTFrom.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(570, 177);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "الى:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(573, 134);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "من:";
            // 
            // cmbCustumerName
            // 
            this.cmbCustumerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustumerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustumerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustumerName.FormattingEnabled = true;
            this.cmbCustumerName.IntegralHeight = false;
            this.cmbCustumerName.Location = new System.Drawing.Point(54, 73);
            this.cmbCustumerName.Name = "cmbCustumerName";
            this.cmbCustumerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCustumerName.Size = new System.Drawing.Size(498, 27);
            this.cmbCustumerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(558, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "ألاسم";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.rdbPayLaterFromDateToDate);
            this.groupBox1.Controls.Add(this.rdDateToDateReport);
            this.groupBox1.Controls.Add(this.rdPayLatterReport);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(54, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(558, 162);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نوع التقرير";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(445, 130);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(107, 20);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "التقرير المالي";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.rbFinancialOnly_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(228, 104);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(324, 20);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "تقرير عدد الفحوصات حسب المدة + التقرير المالي";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.rbTestsAndFinancial_CheckedChanged);
            // 
            // rdbPayLaterFromDateToDate
            // 
            this.rdbPayLaterFromDateToDate.AutoSize = true;
            this.rdbPayLaterFromDateToDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPayLaterFromDateToDate.Location = new System.Drawing.Point(273, 78);
            this.rdbPayLaterFromDateToDate.Name = "rdbPayLaterFromDateToDate";
            this.rdbPayLaterFromDateToDate.Size = new System.Drawing.Size(279, 20);
            this.rdbPayLaterFromDateToDate.TabIndex = 2;
            this.rdbPayLaterFromDateToDate.Text = "تقرير الفحوصات الغير مدفوعة حسب المدة";
            this.rdbPayLaterFromDateToDate.UseVisualStyleBackColor = true;
            this.rdbPayLaterFromDateToDate.CheckedChanged += new System.EventHandler(this.rdbPayLaterFromDateToDate_CheckedChanged);
            // 
            // rdDateToDateReport
            // 
            this.rdDateToDateReport.AutoSize = true;
            this.rdDateToDateReport.Checked = true;
            this.rdDateToDateReport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDateToDateReport.Location = new System.Drawing.Point(329, 26);
            this.rdDateToDateReport.Name = "rdDateToDateReport";
            this.rdDateToDateReport.Size = new System.Drawing.Size(223, 20);
            this.rdDateToDateReport.TabIndex = 1;
            this.rdDateToDateReport.TabStop = true;
            this.rdDateToDateReport.Text = "تقرير عدد الفحوصات حسب المدة";
            this.rdDateToDateReport.UseVisualStyleBackColor = true;
            this.rdDateToDateReport.CheckedChanged += new System.EventHandler(this.rdDateToDateReport_CheckedChanged);
            // 
            // rdPayLatterReport
            // 
            this.rdPayLatterReport.AutoSize = true;
            this.rdPayLatterReport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPayLatterReport.Location = new System.Drawing.Point(216, 52);
            this.rdPayLatterReport.Name = "rdPayLatterReport";
            this.rdPayLatterReport.Size = new System.Drawing.Size(336, 20);
            this.rdPayLatterReport.TabIndex = 0;
            this.rdPayLatterReport.Text = "تقرير الفحوصات الغير مدفوعة حسب اسم المشتري";
            this.rdPayLatterReport.UseVisualStyleBackColor = true;
            this.rdPayLatterReport.CheckedChanged += new System.EventHandler(this.rdPayLatterReport_CheckedChanged);
            // 
            // btnPrevDate
            // 
            this.btnPrevDate.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevDate.Location = new System.Drawing.Point(543, 105);
            this.btnPrevDate.Name = "btnPrevDate";
            this.btnPrevDate.Size = new System.Drawing.Size(69, 23);
            this.btnPrevDate.TabIndex = 34;
            this.btnPrevDate.Text = ">>";
            this.btnPrevDate.UseVisualStyleBackColor = false;
            this.btnPrevDate.Click += new System.EventHandler(this.btnPrevDate_Click);
            // 
            // btnNextDate
            // 
            this.btnNextDate.BackColor = System.Drawing.Color.Transparent;
            this.btnNextDate.Location = new System.Drawing.Point(448, 105);
            this.btnNextDate.Name = "btnNextDate";
            this.btnNextDate.Size = new System.Drawing.Size(69, 23);
            this.btnNextDate.TabIndex = 35;
            this.btnNextDate.Text = "<<";
            this.btnNextDate.UseVisualStyleBackColor = false;
            this.btnNextDate.Click += new System.EventHandler(this.btnNextDate_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(657, 509);
            this.Controls.Add(this.btnNextDate);
            this.Controls.Add(this.btnPrevDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btntest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtPriceSum);
            this.Controls.Add(this.txtTestsSum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DTTo);
            this.Controls.Add(this.DTFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCustumerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة التقارير";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btntest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtPriceSum;
        private System.Windows.Forms.TextBox txtTestsSum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTTo;
        private System.Windows.Forms.DateTimePicker DTFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCustumerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdDateToDateReport;
        private System.Windows.Forms.RadioButton rdPayLatterReport;
        private System.Windows.Forms.Button btnPrevDate;
        private System.Windows.Forms.Button btnNextDate;
        private System.Windows.Forms.RadioButton rdbPayLaterFromDateToDate;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}