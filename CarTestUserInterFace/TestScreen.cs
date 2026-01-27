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
    public partial class TestScreen : Form
    {

        clsCarTest CarTest;

        enum enMood { AddNew, Update };

        enMood _Mood;
        public TestScreen()
        {
            InitializeComponent();
            CarTest = new clsCarTest();
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            _Mood = enMood.AddNew;
            
            btnShowNotes.Tag = "1";
        }


        public TestScreen(int CarID)
        {
            InitializeComponent();
            
            CarTest = clsCarTest.GetCarInfoByID(CarID);

            txtCarPlateNumber.Text = CarTest.Car.CarPlateNumber;
            txtCarShasiNumber.Text = CarTest.Car.CarShassiNumber;
            cmbCarColor.Text = CarTest.Car.CarColor;
            cmbCarModel.Text = CarTest.Car.CarMinufacuringYear;
            cmbCarType.Text = CarTest.Car.CarMakeModel;
            cmbEnginCapacity.Text = CarTest.Car.CarEnginCapacity;
            cmbCoustumerName.Text = CarTest.CustumerName;
            txtDate.Text = CarTest.TestDate.ToString("dd/MM/yyyy");
            cmbFRShasi.Text = CarTest.FRShassi;
            cmbFLShasi.Text = CarTest.FLShassi;
            cmbBRShasi.Text = CarTest.BRShassi;
            cmbBLShasi.Text = CarTest.BLShassi;
            cmbEnginTestPersantig.Text = CarTest.EnginTestPerc;
            cmbEnginTest.Text = CarTest.EnginTest;
            cmbGearTest.Text = CarTest.GearTest;
            cmbBakkaksTest.Text = CarTest.BakaksTest;
            txtBodyTest.Text = CarTest.BodyTest;
            cmbWorkerName.Text = CarTest.WorkerNotes;
            txtCenterNotes.Text = CarTest.CenterNotes;
            nbdTestPrice.Value = Convert.ToDecimal(CarTest.TestPrice);
            chkCachOrPayLater.Checked = CarTest.PayLater;

            _Mood = enMood.Update;
            btnSaveResult.Text = "  تعديل";
            btnShowNotes.Tag = "1";
        }


        private clsCarTest _FillCarObjWithValue()
        {
            CarTest.Car.CarPlateNumber = txtCarPlateNumber.Text;
            CarTest.Car.CarShassiNumber = txtCarShasiNumber.Text;
            CarTest.CustumerName = cmbCoustumerName.Text;
            CarTest.Car.CarMakeModel = cmbCarType.Text;
            CarTest.Car.CarMinufacuringYear = cmbCarModel.Text;
            CarTest.Car.CarColor = cmbCarColor.Text;
            CarTest.Car.CarEnginCapacity = cmbEnginCapacity.Text;

            CarTest.FRShassi = cmbFRShasi.Text;
            CarTest.FLShassi = cmbFLShasi.Text;
            CarTest.BRShassi = cmbBRShasi.Text;
            CarTest.BLShassi = cmbBLShasi.Text;
            CarTest.EnginTestPerc = cmbEnginTestPersantig.Text;
            CarTest.EnginTest = cmbEnginTest.Text;
            CarTest.GearTest = cmbGearTest.Text;
            CarTest.BakaksTest = cmbBakkaksTest.Text;
            CarTest.BodyTest = txtBodyTest.Text;
            CarTest.WorkerNotes = cmbWorkerName.Text;
            CarTest.CenterNotes = txtCenterNotes.Text;
            CarTest.TestPrice = (double)nbdTestPrice.Value;
            CarTest.PayLater = chkCachOrPayLater.Checked;

            return CarTest;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (btnShowNotes.Tag.ToString() == "1")
            {
                btnShowNotes.Text = "<<";
                txtCenterNotes.Visible = true;
                btnShowNotes.Tag = "0";
            }
            else
            {
                btnShowNotes.Text = ">>";
                txtCenterNotes.Visible = false;
                btnShowNotes.Tag = "1";
            }
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            CarTest = _FillCarObjWithValue();

            if (CarTest.Save())
            {
                MessageBox.Show("تم حفظ البيانات بنجاح");


                _Mood = enMood.Update;
                btnSaveResult.Text = "تعديل";
            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ، يرجى المحاولة مرة أخرى");
            }
        }
    }
}
