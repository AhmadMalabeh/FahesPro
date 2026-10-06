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
        private bool _backupCompleted;
        private bool _backupInProgress;
        private bool _restartAfterBackup;
#if DEBUG
        private const int BackupProgressTestDelayMilliseconds = 5000;
#else
        private const int BackupProgressTestDelayMilliseconds = 0;
#endif

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

        private async void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_backupCompleted)
                return;

            e.Cancel = true;

            if (_backupInProgress)
                return;

            _backupInProgress = true;
            bool backupSucceeded = false;

            using (Form progressForm = new Form
            {
                Text = "النسخ الاحتياطي",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                ShowInTaskbar = false,
                ControlBox = false,
                RightToLeft = RightToLeft.Yes,
                RightToLeftLayout = true,
                ClientSize = new Size(420, 105)
            })
            {
                Label statusLabel = new Label
                {
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Height = 55,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = "جاري إنشاء النسخة الاحتياطية، الرجاء الانتظار..."
                };
                ProgressBar progressBar = new ProgressBar
                {
                    Dock = DockStyle.Bottom,
                    Height = 22,
                    Style = ProgressBarStyle.Marquee,
                    MarqueeAnimationSpeed = 30
                };
                progressForm.Controls.Add(progressBar);
                progressForm.Controls.Add(statusLabel);

                try
                {
                    progressForm.Show(this);
                    if (BackupProgressTestDelayMilliseconds > 0)
                        await Task.Delay(BackupProgressTestDelayMilliseconds);

                    backupSucceeded = await Task.Run(() => clsBackupManager.PerformSafeBackup());
                }
                catch (Exception ex)
                {
                    SharedLogging.clsLogger.LogError(ex, "UI -> MainScreen_FormClosing backup");
                }
                finally
                {
                    progressForm.Close();
                    _backupCompleted = true;
                    _backupInProgress = false;
                }
            }

            if (!backupSucceeded)
            {
                MessageBox.Show(
                    "تعذر إنشاء النسخة الاحتياطية. يمكنك مراجعة سجل الأخطاء.",
                    "فشل النسخ الاحتياطي",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            bool restartAfterBackup = _restartAfterBackup;
            _restartAfterBackup = false;
            Close();

            if (restartAfterBackup)
                Application.Restart();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            _restartAfterBackup = true;
            this.Close();
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
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("هذه الشاشة متاحة للمدير فقط", "غير مصرح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

        private void btnUsersScreen_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("هذه الشاشة متاحة للمدير فقط", "غير مصرح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmUsersManagement usersForm = new frmUsersManagement(CurrentUser.UserID);
            usersForm.Show();
        }
    }
}
