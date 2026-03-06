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
    public partial class SearchScreen : Form
    {
        public SearchScreen()
        {
            InitializeComponent();
            SearchButton.FlatAppearance.BorderSize = 2;
            btnNewTest.FlatAppearance.BorderSize = 2;
            btnNewEvaluation.FlatAppearance.BorderSize = 2;
            btnGoBackToMainMinu.FlatAppearance.BorderSize = 2;
            btnPrevDate.FlatAppearance.BorderSize = 2;
            btnRefresh.FlatAppearance.BorderSize = 2;
            btnNextDate.FlatAppearance.BorderSize = 2;
            
        }


        enum enSearchMood { SearchByPlateNumber, SearchByShasiNumber, SearchFromDateToDate, GetAllContact };


        DateTime DateFoSearch = DateTime.Today;

        

        

        private void SearchScreen_Load(object sender, EventArgs e)
        {
            lbCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable dt = clsCarTest.GetAllTodayTests();
            if (dt != null)
            {
                _FullDGV_WithInfo(dt, dataGridView1);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void _FullDGV_WithInfo(DataTable dt, DataGridView DGV)
        {

            DGV.AutoGenerateColumns = false;
            DGV.Columns["ID"].DataPropertyName = "ID";
            DGV.Columns["EntryType1"].DataPropertyName = "EntryType1";
            DGV.Columns["RatCrTyp1"].DataPropertyName = "RatCrTyp1";
            DGV.Columns["PlateNumber"].DataPropertyName = "PlateNumber";
            DGV.Columns["ShasiNumber"].DataPropertyName = "ShasiNumber";
            DGV.Columns["RatPayLatter1"].DataPropertyName = "RatPayLatter1";
            DGV.Columns["RatDate1"].DataPropertyName = "RatDate1";
            DGV.Columns["RatBuyer1"].DataPropertyName = "RatBuyer1";
            DGV.Columns["RatWorkerNa1"].DataPropertyName = "RatWorkerNa1";
            DGV.DataSource = dt;


        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            DateTime FromDate = DTFrom.Value.Date;
            DateTime ToDate = DTTo.Value.Date;
            DataTable dt = null; // نعرّفه كـ null في البداية

            // 1. منطق تحديد مصدر البيانات
            if (txtPlateNumber.Text.Length > 0)
            {
                dt = clsCarTest.SearchByPlateNumber(txtPlateNumber.Text.Trim());
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("لا توجد نتائج مطابقة لرقم اللوحة المدخل.", "نتائج البحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (txtShasiNumber.Text.Length > 0)
            {
                dt = clsCarTest.SearchByShasiNumber(txtShasiNumber.Text.Trim());
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد نتائج مطابقة لرقم الشاسيه المدخل.", "نتائج البحث", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
            }
            else if (txtCoustumerName.Text.Length > 0)
            {
                dt = clsCarTest.SearchByCustumerName(txtCoustumerName.Text.Trim());
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد نتائج مطابقة لاسم العميل المدخل.", "نتائج البحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (chkIncudingDate.Checked)
            {
                if (FromDate > ToDate)
                {
                    MessageBox.Show("تاريخ البدء لا يمكن أن يكون أكبر من تاريخ الانتهاء", "خطأ في التاريخ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (chkPayLatter.Checked)
                {
                    dt = clsCarTest.GetAllPayLatterTestsFromDateToDate(FromDate, ToDate);
                }
                else
                {
                    dt = (FromDate == ToDate) ? clsCarTest.GetAllTestByDate(FromDate) : clsCarTest.GetAllInfoBetweenTowDates(FromDate, ToDate);
                }
            }
            else if (chkAllTests.Checked)
            {
                dt = clsCarTest.getAllTests();
            }

            // 2. سطر واحد فقط لعرض البيانات إذا وجدت
            if (dt != null)
            {
                _FullDGV_WithInfo(dt, dataGridView1);
            }
            else
            {
                MessageBox.Show("يرجى إدخال قيم للبحث أو اختيار خيار 'كل الفحوصات'", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnNewEvaluation_Click(object sender, EventArgs e)
        {
            EvaluationScreen evaluationscreen = new EvaluationScreen();

            evaluationscreen.Show();
        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 1. الحصول على الرقم المعرف (ID) من العمود الأول
                int CarID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                // 2. الحصول على نوع الإدخال من عمود EntryType1
                // ملاحظة: تأكد أن "EntryType1" هو اسم العمود الصحيح في الـ DataGridView
                string entryType = dataGridView1.CurrentRow.Cells["EntryType1"].Value.ToString();

                // 3. التوجيه بناءً على النوع
                if (entryType == "تقدير مركبة")
                {
                    // فتح شاشة التقدير
                    EvaluationScreen evaluationScreen = new EvaluationScreen(CarID);
                     evaluationScreen.Show(); // يفضل ShowDialog لضمان التركيز على الشاشة الجديدة
                }
                else if (entryType == "فحص مركبة")
                {
                    // فتح شاشة الفحص
                    TestScreen newTestScreen = new TestScreen(CarID);
                    newTestScreen.Show();
                }
                else
                {
                    // في حال وجود أنواع أخرى أو خطأ في النص
                    MessageBox.Show("نوع الإدخال غير محدد أو غير معروف: " + entryType);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable dt = clsCarTest.GetAllTodayTests();
            if (dt != null)
            {
                _FullDGV_WithInfo(dt, dataGridView1);
            }
            else
            {
                MessageBox.Show("Error");
            }
            DTFrom.Value = DateTime.Today;
            DTTo.Value = DateTime.Today;
            DateFoSearch = DateTime.Today;
        }

        private void btnNewTest_Click(object sender, EventArgs e)
        {
            TestScreen testScreen = new TestScreen();
            testScreen.Show();
        }

        private void btnPrevDate_Click(object sender, EventArgs e)
        {
            DateFoSearch = DateFoSearch.AddDays(-1);
            DataTable dt = clsCarTest.GetAllTestByDate(DateFoSearch);
            if (dt != null)
            {
                _FullDGV_WithInfo(dt, dataGridView1);
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            DateFoSearch = DateFoSearch.AddDays(1);
            if (DateFoSearch > DateTime.Today)
            {
                DateFoSearch = DateTime.Today;
                DataTable dtToday = clsCarTest.GetAllTodayTests();
                if (dtToday != null)
                {
                    _FullDGV_WithInfo(dtToday, dataGridView1);
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
            else
            {
                DataTable dt = clsCarTest.GetAllTestByDate(DateFoSearch);
                if (dt != null)
                {
                    _FullDGV_WithInfo(dt, dataGridView1);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
                
        }

        private void btnGoBackToMainMinu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
