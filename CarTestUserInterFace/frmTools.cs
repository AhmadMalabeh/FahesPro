using CarTestLogicalLayer;
using SharedLogging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarTestUserInterFace
{
    public partial class frmTools : Form
    {

        clsTools Tool;

        
        public frmTools()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            Tool = new clsTools();
        }

        enum enMode
        {
            AddNew,
            Update
        }
        enMode _Mode;


        private void frmTools_Load(object sender, EventArgs e)
        {
            DataTable dt = clsTools.GetIssuesMinus();
            cmbMinuName.DataSource = dt;
            cmbMinuName.DisplayMember = "MinuName";
            cmbMinuName.ValueMember = "MinuID";
            cmbMinuName.SelectedIndex = -1;

        }

        int MinuID = -1;

        private void cmbMinuName_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            if (cmbMinuName.SelectedValue == null || cmbMinuName.SelectedValue is DataRowView)
            {
                return;
            }

            txtIssueDescription.Text = string.Empty;
            dgvToolsData.DataSource = null;
            IssueID = -1;
            btnSaveResult.Text = "حفظ";
            btnDelete.Enabled = false;
            Tool = new clsTools();

            try
            {
                
                MinuID = Convert.ToInt32(cmbMinuName.SelectedValue);
                LoadIssuesByMinus(MinuID);
                
            }
            catch (Exception ex)
            {
                // لمراقبة أي خطأ آخر قد يحدث
                clsLogger.LogError(ex, "UI SelectedIndexChanged");
            }
        }

        private void LoadIssuesByMinus(int minuID)
        {
            DataTable dtIssues = clsTools.GetIssuesByMinuID(minuID);
            dgvToolsData.DataSource = dtIssues;

            // التحقق من أن الجدول يحتوي على بيانات وأعمدة قبل تعديل الخصائص
            if (dgvToolsData.Columns.Count > 0)
            {
                if (dgvToolsData.Columns.Contains("CarICode1"))
                    dgvToolsData.Columns["CarICode1"].Visible = false;

                if (dgvToolsData.Columns.Contains("CarIssue1"))
                    dgvToolsData.Columns["CarIssue1"].HeaderText = "وصف المشكلة";

                dgvToolsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void _AddNewIssue()
        {
            Tool.CarIssue = txtIssueDescription.Text;
            Tool.MinuID = MinuID;
        }
        private void btnSaveResult_Click(object sender, EventArgs e)
        {

            if (MinuID == -1)
            {
                MessageBox.Show("الرجاء اختيار القائمة");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIssueDescription.Text))
            {
                MessageBox.Show("الرجاء إدخال وصف المشكلة");
                return;
            }
            _AddNewIssue();
            if (Tool.Save())
            {
                MessageBox.Show("تم الاضافة بنجاح");
                
                _Mode = enMode.Update;
                btnSaveResult.Text = "تعديل";
            }
            else
            {
                MessageBox.Show("خطاء في الاضافة");
            }
            LoadIssuesByMinus(MinuID);
        }

        int IssueID = -1;


        private void dgvToolsData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // الحصول على الصف الحالي
                DataGridViewRow row = dgvToolsData.Rows[e.RowIndex];

                // مثال: جلب قيمة من عمود معين وعرضها في TextBox
                // استبدل "CarIssue1" باسم العمود الحقيقي عندك
                txtIssueDescription.Text = row.Cells["CarIssue1"].Value.ToString();
                IssueID = Convert.ToInt32(row.Cells["CarICode1"].Value);
                
                _Mode = enMode.Update;
                Tool = new clsTools(IssueID, MinuID, txtIssueDescription.Text);
                btnDelete.Enabled = true;

                btnSaveResult.Text = "تعديل المشكلة";
                
                
            }
        }

        private void ClearScreen()
        {
            
            dgvToolsData.DataSource = null;
            IssueID = -1;
            txtIssueDescription.Text = "";
            cmbMinuName.SelectedIndex = -1;
            btnSaveResult.Text = "حفظ";
            btnDelete.Enabled = false;
            Tool = new clsTools();
        }

        private void btnClearScreen_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Tool.DeleteIssue())
            {
                MessageBox.Show("تم الحذف بنجاح");
            }
            else
            {
                MessageBox.Show("حدث خطاء اثناء عملية الحذف");
            }
            IssueID = -1;
            txtIssueDescription.Text = "";
            btnSaveResult.Text = "حفظ";
            btnDelete.Enabled = false;
            Tool = new clsTools();
            LoadIssuesByMinus(MinuID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
