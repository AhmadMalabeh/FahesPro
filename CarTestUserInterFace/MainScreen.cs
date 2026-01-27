using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarTestLogicalLayer;
namespace CarTestUserInterFace
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            btnAddNewEvaluationScreen.FlatAppearance.BorderSize = 2;
            btnAddNewTestScreen.FlatAppearance.BorderSize = 2;
            btnReports.FlatAppearance.BorderSize = 2;
            btnSearchScreen.FlatAppearance.BorderSize = 2;
            btnLogOut.FlatAppearance.BorderSize = 2;
            btnSettings.FlatAppearance.BorderSize = 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnSearchScreen_Click(object sender, EventArgs e)
        {
            SearchScreen searchScreen = new SearchScreen();
            searchScreen.Show();
        }

        private void btnAddNewTestScreen_Click(object sender, EventArgs e)
        {
            TestScreen testScreen = new TestScreen();
            testScreen.Show();
        }

        private void btnAddNewEvaluationScreen_Click(object sender, EventArgs e)
        {
            EvaluationScreen evaluationScreen = new EvaluationScreen();
            evaluationScreen.Show();
        }
    }
}
