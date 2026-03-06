namespace CarTestUserInterFace
{
    partial class SearchScreen
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryType1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatCrTyp1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShasiNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatBuyer1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatWorkerNa1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatPayLatter1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.txtShasiNumber = new System.Windows.Forms.TextBox();
            this.txtCoustumerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DTFrom = new System.Windows.Forms.DateTimePicker();
            this.DTTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.btnNewTest = new System.Windows.Forms.Button();
            this.btnNewEvaluation = new System.Windows.Forms.Button();
            this.btnGoBackToMainMinu = new System.Windows.Forms.Button();
            this.btnPrevDate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNextDate = new System.Windows.Forms.Button();
            this.lbCurrentDate = new System.Windows.Forms.Label();
            this.chkIncudingDate = new System.Windows.Forms.CheckBox();
            this.chkAllTests = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkPayLatter = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.EntryType1,
            this.RatCrTyp1,
            this.PlateNumber,
            this.ShasiNumber,
            this.RatDate1,
            this.RatBuyer1,
            this.RatWorkerNa1,
            this.RatPayLatter1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 524);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // EntryType1
            // 
            this.EntryType1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryType1.HeaderText = "نوع الادخال";
            this.EntryType1.Name = "EntryType1";
            this.EntryType1.ReadOnly = true;
            // 
            // RatCrTyp1
            // 
            this.RatCrTyp1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RatCrTyp1.HeaderText = "نوع المركبة";
            this.RatCrTyp1.Name = "RatCrTyp1";
            this.RatCrTyp1.ReadOnly = true;
            // 
            // PlateNumber
            // 
            this.PlateNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PlateNumber.HeaderText = "رقم اللوحة";
            this.PlateNumber.Name = "PlateNumber";
            this.PlateNumber.ReadOnly = true;
            // 
            // ShasiNumber
            // 
            this.ShasiNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ShasiNumber.HeaderText = "رقم الشصي";
            this.ShasiNumber.Name = "ShasiNumber";
            this.ShasiNumber.ReadOnly = true;
            // 
            // RatDate1
            // 
            this.RatDate1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RatDate1.HeaderText = "تاريخ الفحص";
            this.RatDate1.Name = "RatDate1";
            this.RatDate1.ReadOnly = true;
            // 
            // RatBuyer1
            // 
            this.RatBuyer1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RatBuyer1.HeaderText = "اسم المشتري";
            this.RatBuyer1.Name = "RatBuyer1";
            this.RatBuyer1.ReadOnly = true;
            // 
            // RatWorkerNa1
            // 
            this.RatWorkerNa1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RatWorkerNa1.HeaderText = "اسم الفاحص";
            this.RatWorkerNa1.Name = "RatWorkerNa1";
            this.RatWorkerNa1.ReadOnly = true;
            // 
            // RatPayLatter1
            // 
            this.RatPayLatter1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RatPayLatter1.HeaderText = "ذمم";
            this.RatPayLatter1.Name = "RatPayLatter1";
            this.RatPayLatter1.ReadOnly = true;
            this.RatPayLatter1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RatPayLatter1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1068, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "شاشة البحث";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1159, 78);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "رقم اللوحة:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1141, 143);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "رقم الشاصي:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1132, 208);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(122, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "اسم المشتري:";
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.Location = new System.Drawing.Point(1027, 110);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlateNumber.Size = new System.Drawing.Size(227, 20);
            this.txtPlateNumber.TabIndex = 1;
            // 
            // txtShasiNumber
            // 
            this.txtShasiNumber.Location = new System.Drawing.Point(1026, 176);
            this.txtShasiNumber.Name = "txtShasiNumber";
            this.txtShasiNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShasiNumber.Size = new System.Drawing.Size(227, 20);
            this.txtShasiNumber.TabIndex = 2;
            // 
            // txtCoustumerName
            // 
            this.txtCoustumerName.Location = new System.Drawing.Point(1026, 246);
            this.txtCoustumerName.Name = "txtCoustumerName";
            this.txtCoustumerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCoustumerName.Size = new System.Drawing.Size(227, 20);
            this.txtCoustumerName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1143, 278);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(111, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "حسب التاريخ:";
            // 
            // DTFrom
            // 
            this.DTFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFrom.Location = new System.Drawing.Point(1150, 334);
            this.DTFrom.Name = "DTFrom";
            this.DTFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTFrom.Size = new System.Drawing.Size(104, 20);
            this.DTFrom.TabIndex = 5;
            // 
            // DTTo
            // 
            this.DTTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTTo.Location = new System.Drawing.Point(1027, 334);
            this.DTTo.Name = "DTTo";
            this.DTTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTTo.Size = new System.Drawing.Size(104, 20);
            this.DTTo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1215, 307);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(39, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "من:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1093, 307);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(42, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "الى:";
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.SteelBlue;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.ForeColor = System.Drawing.Color.White;
            this.SearchButton.Location = new System.Drawing.Point(1025, 399);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SearchButton.Size = new System.Drawing.Size(227, 53);
            this.SearchButton.TabIndex = 9;
            this.SearchButton.Text = "بحث";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // btnNewTest
            // 
            this.btnNewTest.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNewTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTest.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTest.ForeColor = System.Drawing.Color.White;
            this.btnNewTest.Location = new System.Drawing.Point(1025, 464);
            this.btnNewTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewTest.Name = "btnNewTest";
            this.btnNewTest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewTest.Size = new System.Drawing.Size(227, 53);
            this.btnNewTest.TabIndex = 10;
            this.btnNewTest.Text = "فحص جديد";
            this.btnNewTest.UseVisualStyleBackColor = false;
            this.btnNewTest.Click += new System.EventHandler(this.btnNewTest_Click);
            // 
            // btnNewEvaluation
            // 
            this.btnNewEvaluation.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNewEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewEvaluation.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEvaluation.ForeColor = System.Drawing.Color.White;
            this.btnNewEvaluation.Location = new System.Drawing.Point(1025, 529);
            this.btnNewEvaluation.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewEvaluation.Name = "btnNewEvaluation";
            this.btnNewEvaluation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewEvaluation.Size = new System.Drawing.Size(227, 53);
            this.btnNewEvaluation.TabIndex = 11;
            this.btnNewEvaluation.Text = "تخمين جديد";
            this.btnNewEvaluation.UseVisualStyleBackColor = false;
            this.btnNewEvaluation.Click += new System.EventHandler(this.btnNewEvaluation_Click);
            // 
            // btnGoBackToMainMinu
            // 
            this.btnGoBackToMainMinu.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGoBackToMainMinu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBackToMainMinu.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBackToMainMinu.ForeColor = System.Drawing.Color.White;
            this.btnGoBackToMainMinu.Location = new System.Drawing.Point(1025, 594);
            this.btnGoBackToMainMinu.Margin = new System.Windows.Forms.Padding(0);
            this.btnGoBackToMainMinu.Name = "btnGoBackToMainMinu";
            this.btnGoBackToMainMinu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGoBackToMainMinu.Size = new System.Drawing.Size(227, 53);
            this.btnGoBackToMainMinu.TabIndex = 12;
            this.btnGoBackToMainMinu.Text = "رجوع";
            this.btnGoBackToMainMinu.UseVisualStyleBackColor = false;
            this.btnGoBackToMainMinu.Click += new System.EventHandler(this.btnGoBackToMainMinu_Click);
            // 
            // btnPrevDate
            // 
            this.btnPrevDate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPrevDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevDate.ForeColor = System.Drawing.Color.White;
            this.btnPrevDate.Location = new System.Drawing.Point(767, 594);
            this.btnPrevDate.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrevDate.Name = "btnPrevDate";
            this.btnPrevDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrevDate.Size = new System.Drawing.Size(227, 53);
            this.btnPrevDate.TabIndex = 13;
            this.btnPrevDate.Text = ">>";
            this.btnPrevDate.UseVisualStyleBackColor = false;
            this.btnPrevDate.Click += new System.EventHandler(this.btnPrevDate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(398, 594);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRefresh.Size = new System.Drawing.Size(227, 53);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNextDate
            // 
            this.btnNextDate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNextDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextDate.ForeColor = System.Drawing.Color.White;
            this.btnNextDate.Location = new System.Drawing.Point(29, 594);
            this.btnNextDate.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextDate.Name = "btnNextDate";
            this.btnNextDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNextDate.Size = new System.Drawing.Size(227, 53);
            this.btnNextDate.TabIndex = 15;
            this.btnNextDate.Text = "<<";
            this.btnNextDate.UseVisualStyleBackColor = false;
            this.btnNextDate.Click += new System.EventHandler(this.btnNextDate_Click);
            // 
            // lbCurrentDate
            // 
            this.lbCurrentDate.AutoSize = true;
            this.lbCurrentDate.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentDate.ForeColor = System.Drawing.Color.White;
            this.lbCurrentDate.Location = new System.Drawing.Point(12, 9);
            this.lbCurrentDate.Name = "lbCurrentDate";
            this.lbCurrentDate.Size = new System.Drawing.Size(181, 33);
            this.lbCurrentDate.TabIndex = 20;
            this.lbCurrentDate.Text = "CurrentDate";
            // 
            // chkIncudingDate
            // 
            this.chkIncudingDate.AutoSize = true;
            this.chkIncudingDate.Location = new System.Drawing.Point(1122, 283);
            this.chkIncudingDate.Name = "chkIncudingDate";
            this.chkIncudingDate.Size = new System.Drawing.Size(15, 14);
            this.chkIncudingDate.TabIndex = 4;
            this.chkIncudingDate.UseVisualStyleBackColor = true;
            // 
            // chkAllTests
            // 
            this.chkAllTests.AutoSize = true;
            this.chkAllTests.Location = new System.Drawing.Point(1122, 373);
            this.chkAllTests.Name = "chkAllTests";
            this.chkAllTests.Size = new System.Drawing.Size(15, 14);
            this.chkAllTests.TabIndex = 7;
            this.chkAllTests.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1138, 368);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(116, 19);
            this.label8.TabIndex = 23;
            this.label8.Text = "كل الفحوصات:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1068, 278);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(46, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "ذمم:";
            // 
            // chkPayLatter
            // 
            this.chkPayLatter.AutoSize = true;
            this.chkPayLatter.Location = new System.Drawing.Point(1047, 283);
            this.chkPayLatter.Name = "chkPayLatter";
            this.chkPayLatter.Size = new System.Drawing.Size(15, 14);
            this.chkPayLatter.TabIndex = 25;
            this.chkPayLatter.UseVisualStyleBackColor = true;
            // 
            // SearchScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1257, 649);
            this.Controls.Add(this.chkPayLatter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkAllTests);
            this.Controls.Add(this.chkIncudingDate);
            this.Controls.Add(this.lbCurrentDate);
            this.Controls.Add(this.btnNextDate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnPrevDate);
            this.Controls.Add(this.btnGoBackToMainMinu);
            this.Controls.Add(this.btnNewEvaluation);
            this.Controls.Add(this.btnNewTest);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DTTo);
            this.Controls.Add(this.DTFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCoustumerName);
            this.Controls.Add(this.txtShasiNumber);
            this.Controls.Add(this.txtPlateNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SearchScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة البحث";
            this.Load += new System.EventHandler(this.SearchScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.TextBox txtShasiNumber;
        private System.Windows.Forms.TextBox txtCoustumerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DTFrom;
        private System.Windows.Forms.DateTimePicker DTTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button btnNewTest;
        private System.Windows.Forms.Button btnNewEvaluation;
        private System.Windows.Forms.Button btnGoBackToMainMinu;
        private System.Windows.Forms.Button btnPrevDate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnNextDate;
        private System.Windows.Forms.Label lbCurrentDate;
        private System.Windows.Forms.CheckBox chkIncudingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryType1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatCrTyp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShasiNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatBuyer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatWorkerNa1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RatPayLatter1;
        private System.Windows.Forms.CheckBox chkAllTests;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkPayLatter;
    }
}