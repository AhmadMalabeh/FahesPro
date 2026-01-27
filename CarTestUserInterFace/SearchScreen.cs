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
            btnNextDate.FlatAppearance.BorderSize = 2;
            btnRefresh.FlatAppearance.BorderSize = 2;
            btnPrevDate.FlatAppearance.BorderSize = 2;
            
        }


        enum enSearchMood { SearchByPlateNumber, SearchByShasiNumber, SearchFromDateToDate, GetAllContact };


        private void _SetDataGridInfo()
        {
            DataTable dt = clsCarTest.getAllTests();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["ID"].DataPropertyName = "ID";
            dataGridView1.Columns["EntryType1"].DataPropertyName = "EntryType1";
            dataGridView1.Columns["RatCrTyp1"].DataPropertyName = "RatCrTyp1";
            dataGridView1.Columns["PlateNumber"].DataPropertyName = "PlateNumber";
            dataGridView1.Columns["ShasiNumber"].DataPropertyName = "ShasiNumber";
            dataGridView1.Columns["RatPayLatter1"].DataPropertyName = "RatPayLatter1";
            dataGridView1.Columns["RatDate1"].DataPropertyName = "RatDate1";
            dataGridView1.Columns["RatBuyer1"].DataPropertyName = "RatBuyer1";
            dataGridView1.Columns["RatWorkerNa1"].DataPropertyName = "RatWorkerNa1";

            dataGridView1.DataSource = dt;
        }

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
            if (chkIncudingDate.Checked == true)
            {
                string FromDate = DTFrom.Value.ToString();
                string ToDate = DTTo.Value.ToString();

                if (FromDate != ToDate)
                {
                    DataTable dt = new DataTable();
                    dt = clsCarTest.GetAllInfoBetweenTowDates(FromDate, ToDate);
                    _FullDGV_WithInfo(dt, dataGridView1);
                }

                else
                {
                    _SetDataGridInfo();
                }


            }

            else if (txtShasiNumber.Text.ToString() != "")
            {
                DataTable dt = new DataTable();
                dt = clsCarTest.SearchByShasiNumber(txtShasiNumber.Text.ToString());
                _FullDGV_WithInfo(dt, dataGridView1);

            }
            else if (txtPlateNumber.Text.ToString() != "")
            {
                DataTable dt = new DataTable();
                dt = clsCarTest.SearchByPlateNumber(txtPlateNumber.Text.ToString());
                _FullDGV_WithInfo(dt, dataGridView1);
            }
            else if (DTFrom.Value.ToString() == DTTo.Value.ToString())
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

            }
            else
            {
                MessageBox.Show("Please Enter Plate Number Or Shasi Number");
            }


        }

        private void btnNewEvaluation_Click(object sender, EventArgs e)
        {

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
                     evaluationScreen.ShowDialog(); // يفضل ShowDialog لضمان التركيز على الشاشة الجديدة
                }
                else if (entryType == "فحص مركبة")
                {
                    // فتح شاشة الفحص
                    TestScreen newTestScreen = new TestScreen(CarID);
                    newTestScreen.ShowDialog();
                }
                else
                {
                    // في حال وجود أنواع أخرى أو خطأ في النص
                    MessageBox.Show("نوع الإدخال غير محدد أو غير معروف: " + entryType);
                }
            }
        }
    }
}
