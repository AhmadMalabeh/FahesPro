using CarTestLogicalLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarTestUserInterFace
{
    public partial class frmUsersManagement : Form
    {
        private clsUsers _User = new clsUsers();
        private int _CurrentAdminUserID;

        public frmUsersManagement(int currentAdminUserID)
        {
            InitializeComponent();
            _CurrentAdminUserID = currentAdminUserID;
        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            _SetupGrid();
            _LoadUsers();
            _SetFormMode(enFormMode.AddNew);
            txtPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
        }

        private enum enFormMode { AddNew, Update }

        private void _SetupGrid()
        {
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.RightToLeft = RightToLeft.Yes;
            dgvUsers.CellClick += _dgvUsers_CellClick;
            dgvUsers.CellFormatting += _ColorRows;
        }

        private void _ColorRows(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvUsers.Rows[e.RowIndex];
            bool isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);
            row.DefaultCellStyle.BackColor = isActive
                ? Color.FromArgb(220, 255, 220)
                : Color.FromArgb(255, 220, 220);
        }

        private void _LoadUsers()
        {
            dgvUsers.Columns.Clear();
            dgvUsers.DataSource = clsUsers.GetAllUsers();
            _RenameColumns();
        }

        private void _RenameColumns()
        {
            if (dgvUsers.Columns.Count == 0) return;

            dgvUsers.Columns["UserID"].HeaderText = "الرقم";
            dgvUsers.Columns["UserName"].HeaderText = "اسم المستخدم";
            dgvUsers.Columns["IsAdmin"].HeaderText = "Admin";
            dgvUsers.Columns["IsActive"].HeaderText = "نشط";

            dgvUsers.Columns["IsActive"].Visible = false;
        }

        private void _dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int userID = Convert.ToInt32(
                dgvUsers.Rows[e.RowIndex].Cells["UserID"].Value);

            _User = clsUsers.GetByID(userID);
            if (_User == null) return;

            _FillFields();
            _SetFormMode(enFormMode.Update);
        }

        private void _FillFields()
        {
            txtUserName.Text = _User.UserName;
            txtPassword.Text = "";
            txtNewPassword.Text = "";
            chkIsAdmin.Checked = _User.IsAdmin;

            lblStatus.Text = _User.IsActive ? "نشط ✔" : "معطّل ✖";
            lblStatus.ForeColor = _User.IsActive ? Color.Green : Color.Red;

            // حماية حساب admin الرئيسي
            bool isMainAdmin = _User.UserName.ToLower() == "admin";
            btnToggleActive.Enabled = !isMainAdmin;
            btnToggleAdmin.Enabled = !isMainAdmin;
        }

        private void _SetFormMode(enFormMode mode)
        {
            switch (mode)
            {
                case enFormMode.AddNew:
                    btnSave.Text = "حفظ";
                    btnChangePassword.Enabled = false;
                    btnToggleActive.Enabled = false;
                    btnToggleAdmin.Enabled = false;
                    lblStatus.Text = "جديد";
                    lblStatus.ForeColor = Color.Gray;
                    txtPassword.Enabled = true;
                    break;

                case enFormMode.Update:
                    btnSave.Text = "تعديل";
                    btnChangePassword.Enabled = true;
                    btnToggleActive.Enabled = _User.UserName.ToLower() != "admin";
                    btnToggleAdmin.Enabled = _User.UserName.ToLower() != "admin";
                    txtPassword.Enabled = false;
                    btnToggleActive.Text = _User.IsActive ? "تعطيل" : "تفعيل";
                    btnToggleAdmin.Text = _User.IsAdmin ? "سحب Admin" : "منح Admin";
                    break;
            }
        }

        private void _ClearFields()
        {
            _User = new clsUsers();
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtNewPassword.Text = "";
            chkIsAdmin.Checked = false;
            _SetFormMode(enFormMode.AddNew);
        }

        private void _FillUserFromFields()
        {
            _User.UserName = txtUserName.Text.Trim();
            _User.IsAdmin = chkIsAdmin.Checked;

            if (txtPassword.Enabled)
                _User.Password = txtPassword.Text.Trim();
        }

        // ===== Button Events =====

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _ClearFields();
            txtUserName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillUserFromFields();

            if (_User.Save())
            {
                MessageBox.Show("تم الحفظ بنجاح", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadUsers();
                _SetFormMode(enFormMode.Update);
            }
            else
            {
                MessageBox.Show(_User.ErrorMessage, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("يرجى إدخال كلمة المرور الجديدة", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                $"هل أنت متأكد من تغيير كلمة مرور: {_User.UserName}؟",
                "تأكيد", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_User.ChangePassword(txtNewPassword.Text.Trim()))
                {
                    MessageBox.Show("تم تغيير كلمة المرور بنجاح", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewPassword.Text = "";
                }
                else
                {
                    MessageBox.Show(_User.ErrorMessage, "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            bool newStatus = !_User.IsActive;
            string action = newStatus ? "تفعيل" : "تعطيل";

            if (MessageBox.Show(
                $"هل أنت متأكد من {action} المستخدم: {_User.UserName}؟",
                "تأكيد", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_User.SetActiveStatus(newStatus))
                {
                    MessageBox.Show($"تم {action} المستخدم بنجاح", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadUsers();
                    _FillFields();
                    _SetFormMode(enFormMode.Update);
                }
                else
                {
                    MessageBox.Show(_User.ErrorMessage, "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnToggleAdmin_Click(object sender, EventArgs e)
        {
            bool newStatus = !_User.IsAdmin;
            string action = newStatus ? "منح" : "سحب";

            if (MessageBox.Show(
                $"هل أنت متأكد من {action} صلاحية Admin للمستخدم: {_User.UserName}؟",
                "تأكيد", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_User.SetAdminStatus(newStatus))
                {
                    MessageBox.Show($"تم {action} الصلاحية بنجاح", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadUsers();
                    _FillFields();
                    _SetFormMode(enFormMode.Update);
                }
                else
                {
                    MessageBox.Show(_User.ErrorMessage, "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _ClearFields();
        }
    }
}
