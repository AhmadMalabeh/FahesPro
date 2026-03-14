using CarTestLogicalLayer;
using CarTestUI;
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
    public partial class MainScreen : Form
    {
        clsUsers CurrentUser;
        public MainScreen(clsUsers User)
        {
            InitializeComponent();
            btnAddNewEvaluationScreen.FlatAppearance.BorderSize = 2;
            btnAddNewTestScreen.FlatAppearance.BorderSize = 2;
            btnReports.FlatAppearance.BorderSize = 2;
            btnSearchScreen.FlatAppearance.BorderSize = 2;
            btnLogOut.FlatAppearance.BorderSize = 2;
            btnSettings.FlatAppearance.BorderSize = 2;
            lbUserName.Text = User.UserName;
            CurrentUser = User;
            imageList1.Images.Add(Properties.Resources.icons8_money_501);
            imageList1.Images.Add(Properties.Resources.icons8_tool_50);
            imageList1.Images.Add(Properties.Resources.icons8_logout_50);
            btnLogOut.Image= imageList1.Images[2];
            btnSettings.Image = imageList1.Images[1];
            btnDialyExpensesScreen.Image = imageList1.Images[0];



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            lbCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnSearchScreen_Click(object sender, EventArgs e)
        {
            SearchScreen searchScreen = new SearchScreen(CurrentUser.UserID);
            searchScreen.Show();
        }

        private void btnAddNewTestScreen_Click(object sender, EventArgs e)
        {
            TestScreen testScreen = new TestScreen(CurrentUser.UserID);
            testScreen.Show();
        }

        private void btnAddNewEvaluationScreen_Click(object sender, EventArgs e)
        {
            EvaluationScreen evaluationScreen = new EvaluationScreen(CurrentUser.UserID);
            evaluationScreen.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReports reportsForm = new frmReports();
            reportsForm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmTools ToolsForm = new frmTools();
            ToolsForm.Show();
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsBackupManager.PerformSafeBackup();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // نخبر البرنامج أننا نريد إغلاق الشاشة الحالية فقط
            // وسيقوم حدث FormClosing بتنفيذ النسخ الاحتياطي تلقائياً كما خططت
            this.Close();

            // لإعادة تشغيل البرنامج من الصفر (إظهار شاشة الدخول مجدداً)
            Application.Restart();
        }

        private void btnDialyExpensesScreen_Click(object sender, EventArgs e)
        {
            frmExpensesManagement expensesForm = new frmExpensesManagement(CurrentUser);
            expensesForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmChart chartForm = new frmChart();
            chartForm.Show();
        }

        private void btnAuditingScreen_Click(object sender, EventArgs e)
        {
            frmAuditLog auditLogForm = new frmAuditLog(CurrentUser.UserID);
            auditLogForm.Show();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("هذه الشاشة متاحة للمدير فقط", "غير مصرح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmEmployeesManagement employeesForm = new frmEmployeesManagement();
            employeesForm.Show();
        }
    }
}
