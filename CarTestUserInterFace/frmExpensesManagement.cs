using CarTestLogicalLayer;
using SharedLogging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarTestUserInterFace
{
    public partial class frmExpensesManagement : Form
    {

        clsDialyExpenses _Expense;
        clsUsers CurrentUser;
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode;

        public frmExpensesManagement(clsUsers CurrentUser)
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _Expense = new clsDialyExpenses();
            this.CurrentUser = CurrentUser;
        }

        private void frmExpensesManagement_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
        }

        private void _FillCategoriesComboBox()
        {
            DataTable dt = clsDialyExpenses.GetExpenseCategories();
            cmbExpenseesType.DataSource = dt;
            cmbExpenseesType.DisplayMember = "CategoryName";
            cmbExpenseesType.ValueMember = "CategoryID";
            cmbExpenseesType.SelectedIndex = -1;
        }

        private void _LoadAllExpenses()
        {
            DataTable dtExpenses = clsDialyExpenses.GetAllExpenses();
            dgvExpensesData.DataSource = dtExpenses;

            if (dgvExpensesData.Rows.Count > 0)
            {
                // 1. إخفاء الأعمدة التي لا نريد للمستخدم رؤيتها
                if (dgvExpensesData.Columns.Contains("ExpenseID"))
                    dgvExpensesData.Columns["ExpenseID"].Visible = false;

                if (dgvExpensesData.Columns.Contains("CategoryID"))
                    dgvExpensesData.Columns["CategoryID"].Visible = false;

                // 2. تغيير أسماء الأعمدة (Header Text)
                // تأكد أن الأسماء بين القوسين [" "] تطابق تماماً الأسماء القادمة من قاعدة البيانات
                dgvExpensesData.Columns["CategoryName"].HeaderText = "نوع المصروف";
                dgvExpensesData.Columns["Amount"].HeaderText = "المبلغ";
                dgvExpensesData.Columns["ExpenseDate"].HeaderText = "التاريخ";
                dgvExpensesData.Columns["Description"].HeaderText = "الوصف";

                // ملاحظة: استعمل الاسم الفعلي للعمود في قاعدة البيانات هنا
                // إذا كان العمود في الجدول اسمه CreatedByUserName أو CreatedBy
                dgvExpensesData.Columns["CreatedBy"].HeaderText = "بواسطة";

                // 3. تحسين المظهر
                dgvExpensesData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void _ResetDefaultValues()
        {
            _FillCategoriesComboBox();
            _LoadAllExpenses();

            _Mode = enMode.AddNew;
            _Expense = new clsDialyExpenses();

            txtDiscription.Text = "";
            nudExpensesValue.Value = 0; // ملاحظة: تأكد من أن اسم أداة السعر هو nudAmount أو غيره
            cmbExpenseesType.SelectedIndex = -1;

            btnSaveResult.Text = "حفظ";
            btnDelete.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string categoryName = cmbExpenseesType.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("الرجاء إدخال نوع المصروف");
                return;
            }

            // 1. البحث عن النص في القائمة الحالية (تجاهل حالة الأحرف)
            int index = cmbExpenseesType.FindStringExact(categoryName);

            if (index != -1)
            {
                // إذا وُجد الاسم، قم باختياره وتكملة الحفظ بشكل عادي
                cmbExpenseesType.SelectedIndex = index;
            }
            else
            {
                // 2. إذا لم يوجد، اسأل المستخدم إذا كان يريد إضافته كجديد
                DialogResult result = MessageBox.Show($"التصنيف '{categoryName}' غير موجود، هل تريد إضافته؟",
                                                      "تأكيد", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int newID = clsDialyExpenses.AddNewCategory(categoryName);
                    if (newID != -1)
                    {
                        _FillCategoriesComboBox();
                        cmbExpenseesType.SelectedValue = newID;
                    }
                }
                else return; // توقف إذا رفض الإضافة
            }

            // تكملة كود الحفظ العادي
            _Expense.CategoryID = (int)cmbExpenseesType.SelectedValue;
            _Expense.Amount = nudExpensesValue.Value;
            _Expense.Description = txtDiscription.Text.Trim();
            _Expense.ExpenseDate = DateTime.Now;
            _Expense.CreatedByUserName = CurrentUser.UserName;

            if (_Expense.Save())
            {
                MessageBox.Show("تم حفظ المصروف بنجاح");
                _LoadAllExpenses();
            }
        }

        private void dgvExpensesData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ExpenseID = (int)dgvExpensesData.Rows[e.RowIndex].Cells["ExpenseID"].Value;

                // البحث عن المصروف وجلبه ككائن (يفترض وجود دالة Find في الـ BLL)
                _Expense = clsDialyExpenses.Find(ExpenseID);

                if (_Expense != null)
                {
                    _Mode = enMode.Update;

                    // تعبئة الواجهة من بيانات الكائن
                    txtDiscription.Text = _Expense.Description;
                    nudExpensesValue.Value = _Expense.Amount;
                    cmbExpenseesType.SelectedValue = _Expense.CategoryID;

                    btnSaveResult.Text = "تعديل";
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت متأكد من حذف هذا المصروف؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_Expense.Delete())
                {
                    MessageBox.Show("تم الحذف بنجاح");
                    _ResetDefaultValues();
                }
                else
                {
                    MessageBox.Show("فشلت عملية الحذف");
                }
            }
        }

        private void btnClearScreen_Click(object sender, EventArgs e)
        {
            _ResetDefaultValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = clsDialyExpenses.GetAllExpensesBettwenTowDates(dtpFrom.Value, dtpTo.Value);
            dgvExpensesData.DataSource = dt;
            if (dgvExpensesData.Rows.Count > 0)
            {
                // 1. إخفاء الأعمدة التي لا نريد للمستخدم رؤيتها
                if (dgvExpensesData.Columns.Contains("ExpenseID"))
                    dgvExpensesData.Columns["ExpenseID"].Visible = false;

                if (dgvExpensesData.Columns.Contains("CategoryID"))
                    dgvExpensesData.Columns["CategoryID"].Visible = false;

                // 2. تغيير أسماء الأعمدة (Header Text)
                // تأكد أن الأسماء بين القوسين [" "] تطابق تماماً الأسماء القادمة من قاعدة البيانات
                dgvExpensesData.Columns["CategoryName"].HeaderText = "نوع المصروف";
                dgvExpensesData.Columns["Amount"].HeaderText = "المبلغ";
                dgvExpensesData.Columns["ExpenseDate"].HeaderText = "التاريخ";
                dgvExpensesData.Columns["Description"].HeaderText = "الوصف";

                // ملاحظة: استعمل الاسم الفعلي للعمود في قاعدة البيانات هنا
                // إذا كان العمود في الجدول اسمه CreatedByUserName أو CreatedBy
                dgvExpensesData.Columns["CreatedBy"].HeaderText = "بواسطة";

                // 3. تحسين المظهر
                dgvExpensesData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("لا توجد مصروفات في هذا النطاق الزمني");
                
            }
        }
    }
}
