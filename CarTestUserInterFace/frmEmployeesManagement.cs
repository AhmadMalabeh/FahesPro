using CarTestLogicalLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarTestUI
{
    public partial class frmEmployeesManagement : Form
    {
        private clsEmployee _Employee = new clsEmployee();

        public frmEmployeesManagement()
        {
            InitializeComponent();
        }

        private void frmEmployeesManagement_Load(object sender, EventArgs e)
        {
            _SetupGrid();
            _LoadEmployees();
            _SetFormMode(enFormMode.AddNew);
        }

        private enum enFormMode { AddNew, Update }

        private void _SetupGrid()
        {
            dgvEmployees.ReadOnly = true;
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.RightToLeft = RightToLeft.Yes;
            dgvEmployees.CellClick += _dgvEmployees_CellClick;
            dgvEmployees.CellFormatting += _ColorRows;
        }

        private void _ColorRows(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvEmployees.Rows[e.RowIndex];
            bool isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);
            row.DefaultCellStyle.BackColor = isActive
                ? Color.FromArgb(220, 255, 220)   // أخضر فاتح — نشط
                : Color.FromArgb(255, 220, 220);  // أحمر فاتح — منتهي
        }

        private void _LoadEmployees()
        {
            dgvEmployees.Columns.Clear();
            dgvEmployees.DataSource = clsEmployee.GetAllEmployees();
            _RenameColumns();
        }

        private void _RenameColumns()
        {
            if (dgvEmployees.Columns.Count == 0) return;

            dgvEmployees.Columns["EmployeeID"].HeaderText = "الرقم";
            dgvEmployees.Columns["FullName"].HeaderText = "الاسم";
            dgvEmployees.Columns["NationalID"].HeaderText = "المعرف الوطني";
            dgvEmployees.Columns["PhoneNumber"].HeaderText = "الهاتف";
            dgvEmployees.Columns["Salary"].HeaderText = "الراتب";
            dgvEmployees.Columns["HireDate"].HeaderText = "تاريخ التوظيف";
            dgvEmployees.Columns["TerminationDate"].HeaderText = "تاريخ الانتهاء";
            dgvEmployees.Columns["IsActive"].HeaderText = "نشط";

            // إخفاء العمود المنطقي واستبداله بالألوان
            dgvEmployees.Columns["IsActive"].Visible = false;
        }

        private void _dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int employeeID = Convert.ToInt32(
                dgvEmployees.Rows[e.RowIndex].Cells["EmployeeID"].Value);

            _Employee = clsEmployee.GetByID(employeeID);

            if (_Employee == null) return;

            _FillFields();
            _SetFormMode(enFormMode.Update);
        }

        private void _FillFields()
        {
            txtFullName.Text = _Employee.FullName;
            txtNationalID.Text = _Employee.NationalID;
            txtPhoneNumber.Text = _Employee.PhoneNumber;
            txtSalary.Text = _Employee.Salary.ToString();
            dtpHireDate.Value = _Employee.HireDate;

            lblStatus.Text = _Employee.IsActive ? "نشط ✔" : "منتهي الخدمة ✖";
            lblStatus.ForeColor = _Employee.IsActive ? Color.Green : Color.Red;
        }

        private void _SetFormMode(enFormMode mode)
        {
            switch (mode)
            {
                case enFormMode.AddNew:
                    btnSave.Text = "حفظ";
                    btnDeactivate.Enabled = false;
                    lblStatus.Text = "جديد";
                    lblStatus.ForeColor = Color.Gray;
                    break;

                case enFormMode.Update:
                    btnSave.Text = "تعديل";
                    btnDeactivate.Enabled = _Employee.IsActive;
                    break;
            }
        }

        private void _ClearFields()
        {
            _Employee = new clsEmployee();
            txtFullName.Text = "";
            txtNationalID.Text = "";
            txtPhoneNumber.Text = "";
            txtSalary.Text = "";
            dtpHireDate.Value = DateTime.Today;
            _SetFormMode(enFormMode.AddNew);
        }

        private void _FillEmployeeFromFields()
        {
            _Employee.FullName = txtFullName.Text.Trim();
            _Employee.NationalID = txtNationalID.Text.Trim();
            _Employee.PhoneNumber = txtPhoneNumber.Text.Trim();
            _Employee.HireDate = dtpHireDate.Value;

            if (decimal.TryParse(txtSalary.Text.Trim(), out decimal salary))
                _Employee.Salary = salary;
            else
                _Employee.Salary = 0;
        }

        // ===== Button Events =====

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _ClearFields();
            txtFullName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillEmployeeFromFields();

            if (_Employee.Save())
            {
                MessageBox.Show("تم الحفظ بنجاح", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadEmployees();
                _SetFormMode(enFormMode.Update);
            }
            else
            {
                MessageBox.Show(_Employee.ErrorMessage, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                $"هل أنت متأكد من إنهاء خدمة الموظف: {_Employee.FullName}؟",
                "تأكيد",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_Employee.Deactivate())
                {
                    MessageBox.Show("تم إنهاء الخدمة بنجاح", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadEmployees();
                    _FillFields();
                    btnDeactivate.Enabled = false;
                }
                else
                {
                    MessageBox.Show(_Employee.ErrorMessage, "خطأ",
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
