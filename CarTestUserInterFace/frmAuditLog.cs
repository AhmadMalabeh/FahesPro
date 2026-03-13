using CarTestLogicalLayer;
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
    public partial class frmAuditLog : Form
    {
        int UserID;
        DateTime DateFoSearch = DateTime.Today;
        public frmAuditLog(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }
        private void _RenameColumns()
        {
            if (dgvAuditLog.Columns.Count == 0) return;
            dgvAuditLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLog.Columns["RecordID"].HeaderText = "معرف المركبة";
            dgvAuditLog.Columns["EntryType"].HeaderText = "نوع العملية";
            dgvAuditLog.Columns["FieldName"].HeaderText = "الحقل الذي تم تغييره";
            dgvAuditLog.Columns["OldValue"].HeaderText = "القيمة القديمة";
            dgvAuditLog.Columns["NewValue"].HeaderText = "القيمة الجديدة";
            dgvAuditLog.Columns["ActionType"].HeaderText = "إنشاء / تعديل";
            dgvAuditLog.Columns["UserName"].HeaderText = "تم بواسطة";
            dgvAuditLog.Columns["ChangedDate"].HeaderText = "تاريخ التغيير";
        }
        private void frmAuditLog_Load(object sender, EventArgs e)
        {
            
            dgvAuditLog.DataSource = clsAuditing.GetTodayAuditing();
            
            _RenameColumns();
            

        }

        private void dgvAuditLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int CarID = Convert.ToInt32(dgvAuditLog.CurrentRow.Cells[0].Value);
            string entryType = dgvAuditLog.CurrentRow.Cells["EntryType"].Value.ToString();

            if (entryType == "تخمين مركبة")
            {
                // فتح شاشة التقدير
                EvaluationScreen evaluationScreen = new EvaluationScreen(CarID, UserID);
                evaluationScreen.Show(); // يفضل ShowDialog لضمان التركيز على الشاشة الجديدة
            }
            else if (entryType == "فحص مركبة")
            {
                // فتح شاشة الفحص
                TestScreen newTestScreen = new TestScreen(CarID, UserID);
                newTestScreen.Show();
            }
            else
            {
                // في حال وجود أنواع أخرى أو خطأ في النص
                MessageBox.Show("نوع الإدخال غير محدد أو غير معروف: " + entryType);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            dgvAuditLog.DataSource = clsAuditing.GetTodayAuditing();
            _RenameColumns();
            DTFrom.Value = DateTime.Today;
            DTTo.Value = DateTime.Today;
            DateFoSearch = DateTime.Today;

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            dgvAuditLog.DataSource = clsAuditing.GetAuditingBetweenTowDates(DTFrom.Value, DTTo.Value);
            _RenameColumns();
        }

        private void btnPrevDate_Click(object sender, EventArgs e)
        {
            DateFoSearch = DateFoSearch.AddDays(-1);
            dgvAuditLog.DataSource = clsAuditing.GetAudidingLogByDate(DateFoSearch);
            _RenameColumns();
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            DateFoSearch = DateFoSearch.AddDays(1);
            if(DateFoSearch > DateTime.Today)
            {
                
                DateFoSearch = DateTime.Today; 
                dgvAuditLog.DataSource = clsAuditing.GetTodayAuditing();
                _RenameColumns();
                return;
            }
            else
            {
                 dgvAuditLog.DataSource = clsAuditing.GetAudidingLogByDate(DateFoSearch);
                _RenameColumns();

            }
        }
    }
}
