namespace CarTestUserInterFace
{
    partial class frmAuditLog
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
            this.dgvAuditLog = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DTTo = new System.Windows.Forms.DateTimePicker();
            this.DTFrom = new System.Windows.Forms.DateTimePicker();
            this.SearchButton = new System.Windows.Forms.Button();
            this.btnNextDate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrevDate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 53);
            this.panel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(241, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "شاشة سجل التغييرات";
            // 
            // dgvAuditLog
            // 
            this.dgvAuditLog.AllowUserToAddRows = false;
            this.dgvAuditLog.AllowUserToDeleteRows = false;
            this.dgvAuditLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvAuditLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditLog.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvAuditLog.Location = new System.Drawing.Point(12, 143);
            this.dgvAuditLog.Name = "dgvAuditLog";
            this.dgvAuditLog.ReadOnly = true;
            this.dgvAuditLog.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAuditLog.Size = new System.Drawing.Size(814, 266);
            this.dgvAuditLog.TabIndex = 18;
            this.dgvAuditLog.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuditLog_CellDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(661, 87);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(42, 19);
            this.label7.TabIndex = 22;
            this.label7.Text = "الى:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(787, 87);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(39, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "من:";
            // 
            // DTTo
            // 
            this.DTTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTTo.Location = new System.Drawing.Point(599, 118);
            this.DTTo.Name = "DTTo";
            this.DTTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTTo.Size = new System.Drawing.Size(104, 20);
            this.DTTo.TabIndex = 20;
            // 
            // DTFrom
            // 
            this.DTFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFrom.Location = new System.Drawing.Point(722, 118);
            this.DTFrom.Name = "DTFrom";
            this.DTFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTFrom.Size = new System.Drawing.Size(104, 20);
            this.DTFrom.TabIndex = 19;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.SteelBlue;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.ForeColor = System.Drawing.Color.White;
            this.SearchButton.Location = new System.Drawing.Point(12, 101);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SearchButton.Size = new System.Drawing.Size(91, 37);
            this.SearchButton.TabIndex = 23;
            this.SearchButton.Text = "بحث";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // btnNextDate
            // 
            this.btnNextDate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNextDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextDate.ForeColor = System.Drawing.Color.White;
            this.btnNextDate.Location = new System.Drawing.Point(12, 422);
            this.btnNextDate.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextDate.Name = "btnNextDate";
            this.btnNextDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNextDate.Size = new System.Drawing.Size(146, 53);
            this.btnNextDate.TabIndex = 26;
            this.btnNextDate.Text = "<<";
            this.btnNextDate.UseVisualStyleBackColor = false;
            this.btnNextDate.Click += new System.EventHandler(this.btnNextDate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(345, 422);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRefresh.Size = new System.Drawing.Size(146, 53);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrevDate
            // 
            this.btnPrevDate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPrevDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevDate.ForeColor = System.Drawing.Color.White;
            this.btnPrevDate.Location = new System.Drawing.Point(678, 422);
            this.btnPrevDate.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrevDate.Name = "btnPrevDate";
            this.btnPrevDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrevDate.Size = new System.Drawing.Size(146, 53);
            this.btnPrevDate.TabIndex = 24;
            this.btnPrevDate.Text = ">>";
            this.btnPrevDate.UseVisualStyleBackColor = false;
            this.btnPrevDate.Click += new System.EventHandler(this.btnPrevDate_Click);
            // 
            // frmAuditLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 484);
            this.Controls.Add(this.btnNextDate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnPrevDate);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DTTo);
            this.Controls.Add(this.DTFrom);
            this.Controls.Add(this.dgvAuditLog);
            this.Controls.Add(this.panel1);
            this.Name = "frmAuditLog";
            this.Text = "frmAuditLog";
            this.Load += new System.EventHandler(this.frmAuditLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAuditLog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTTo;
        private System.Windows.Forms.DateTimePicker DTFrom;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button btnNextDate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrevDate;
    }
}