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
using System.Windows.Forms.DataVisualization.Charting;

namespace CarTestUserInterFace
{
    public partial class frmChart : Form
    {
        public frmChart()
        {
            InitializeComponent();
            
            AssignIssueToComboBoxes();
            comboBox1.SelectedValue = DateTime.Now.Year;
        }

        private void AssignIssueToComboBoxes()
        {
            DataTable dtAllIssues = clsTools.GetAllIssues();

            DataView dvYear = new DataView(dtAllIssues);
            dvYear.RowFilter = "MinuName = 'سنة التقرير البياني'";

            comboBox1.DisplayMember = "CarIssue1"; // مثلا 2025
            comboBox1.ValueMember = "CarICode1";   // لازم تكون نفس السنة كرقم أو كود قابل للتحويل
            comboBox1.DataSource = dvYear;

            // ✅ اختَر السنة الحالية إن وُجدت
            comboBox1.SelectedValue = DateTime.Now.Year;
            if (comboBox1.SelectedIndex == -1 && comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }


        private void frmChart_Load(object sender, EventArgs e)
        {
            FillChart(DateTime.Now.Year);
        }

        

        private void FillChart(int Year)
        {
            DataTable dt = clsCharts.DataTableGetTestsAndTotalPriceByYear(Year);

            chart1.Series.Clear();

            // ✅ بدل Tests عمود واحد → عمودين: كاش وذمم
            var sCashTests = chart1.Series.Add("CashTests");
            sCashTests.ChartType = SeriesChartType.Column;

            var sDebtTests = chart1.Series.Add("DebtTests");
            sDebtTests.ChartType = SeriesChartType.Column;

            var sRevenue = chart1.Series.Add("Revenue");
            sRevenue.ChartType = SeriesChartType.Column;
            sRevenue.YAxisType = AxisType.Secondary;

            var sExpenses = chart1.Series.Add("Expenses");
            sExpenses.ChartType = SeriesChartType.Column;
            sExpenses.YAxisType = AxisType.Secondary;

            var sNet = chart1.Series.Add("NetProfit");
            sNet.ChartType = SeriesChartType.Column;
            sNet.YAxisType = AxisType.Secondary;

            

            string[] months = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            // ✅ مجاميع السنة
            int totalTestsYear = 0, cashTestsYear = 0, debtTestsYear = 0;
            decimal totalRevenueYear = 0m, cashRevenueYear = 0m, debtRevenueYear = 0m;
            decimal totalExpensesYear = 0m;

            foreach (DataRow row in dt.Rows)
            {
                int m = Convert.ToInt32(row["Month"]);

                int cashTests = Convert.ToInt32(row["CashTests"]);
                int debtTests = Convert.ToInt32(row["DebtTests"]);
                int tests = cashTests + debtTests;

                decimal revenue = Convert.ToDecimal(row["TotalRevenue"]);
                decimal cashRevenue = Convert.ToDecimal(row["CashRevenue"]);
                decimal debtRevenue = Convert.ToDecimal(row["DebtRevenue"]);

                decimal expenses = Convert.ToDecimal(row["TotalExpenses"]);
                decimal net = revenue - expenses;

                // ✅ اجمع
                cashTestsYear += cashTests;
                debtTestsYear += debtTests;
                totalTestsYear += tests;

                totalRevenueYear += revenue;
                cashRevenueYear += cashRevenue;
                debtRevenueYear += debtRevenue;

                totalExpensesYear += expenses;

                string x = months[m];

                // ✅ الرسم: عمودين للفحوصات
                sCashTests.Points.AddXY(x, cashTests);
                sDebtTests.Points.AddXY(x, debtTests);

                // ✅ بقية الأعمدة
                sRevenue.Points.AddXY(x, revenue);
                sExpenses.Points.AddXY(x, expenses);
                sNet.Points.AddXY(x, net);
            }

            decimal totalNetYear = totalRevenueYear - totalExpensesYear;

            chart1.Titles.Clear();
            chart1.Titles.Add(
                $"Tests: {totalTestsYear} (Cash:{cashTestsYear}, Debt:{debtTestsYear}) | " +
                $"Rev: {totalRevenueYear:N2} (Cash:{cashRevenueYear:N2}, Debt:{debtRevenueYear:N2}) | " +
                $"Exp: {totalExpensesYear:N2} | Net: {totalNetYear:N2}"
            );

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.Title = "Month";
            chart1.ChartAreas[0].AxisY.Title = "Tests";
            chart1.ChartAreas[0].AxisY2.Title = $"Money ({Year})";
            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            // SelectedItem هنا DataRowView
            var rowView = (DataRowView)comboBox1.SelectedItem;

            // CarIssue1 هو النص اللي ظاهر (السنة)
            if (int.TryParse(rowView["CarIssue1"].ToString(), out int year))
                FillChart(year);
        }
    }
}
