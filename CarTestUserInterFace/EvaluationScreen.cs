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
    public partial class EvaluationScreen : Form
    {

        clsCarRating CarRating;
        enum enMood { AddNew, Update };

        enMood _Mood;
        public EvaluationScreen()
        {
            InitializeComponent();
            CarRating = new clsCarRating();
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            _Mood = enMood.AddNew;
        }

        public EvaluationScreen(int ID)
        {
            InitializeComponent();
            CarRating = clsCarRating.GetCarInfoByIDForUpdate(ID);
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            _Mood = enMood.AddNew;
            cmbCarType.Text = CarRating.Car.CarMakeModel;
            txtPlateNumber.Text = CarRating.Car.CarPlateNumber;
            txtShasiNumber.Text = CarRating.Car.CarShassiNumber;
            txtRegstrationNumber.Text = CarRating.RegstrationNumber;
            cmbBankName.Text = CarRating.Bank;
            cmbUseType.Text = CarRating.UseType;
            cmbInsuranceType.Text = CarRating.InsuranceType;
            cmbYear.Text = CarRating.Car.CarMinufacuringYear;
            txtEnginNumber.Text = CarRating.EnginNumber;
            txtCarOwner.Text = CarRating.CarOwner;
            cmbCarCapacity.Text = CarRating.CarCapacity;
            cmbEnginCapacity.Text = CarRating.Car.CarEnginCapacity;
            cmbCarCountry.Text = CarRating.CarCountry;
            cmbCarColor.Text = CarRating.Car.CarColor;
            txtBuyer.Text = CarRating.CustumerName;
            cmbFRShasi.Text = CarRating.FRShassi;
            cmbFLShasi.Text = CarRating.FLShassi;
            cmbBRShasi.Text = CarRating.BRShassi;
            cmbBLShasi.Text = CarRating.BLShassi;
            txtBody.Text = CarRating.BodyTest;
            cmbEnginPerc.Text = CarRating.EnginTestPerc;
            cmbEnginTest.Text = CarRating.EnginTest;
            cmbGearTest.Text = CarRating.GearTest;
            cmbBakaks.Text = CarRating.BakaksTest;
            cmbWorkerName.Text = CarRating.WorkerNotes;
            txtCarStatius.Text = CarRating.CarStatus;
            txtBodyRat.Text = CarRating.BodyValue.ToString();
            txtStampRate.Text = CarRating.StampValue.ToString();
            txtTotalValue.Text = CarRating.TotalValue.ToString();
            txtTotalValueAsString.Text = CarRating.TotalValueAsString;

            txtDate.Text = CarRating.TestDate.ToString("yyyy-MM-dd");

            chkItem1.Checked = (bool)CarRating.ChkItem1;
            chkItem2.Checked = (bool)CarRating.ChkItem2;
            chkItem3.Checked = (bool)CarRating.ChkItem3;
            chkItem4.Checked = (bool)CarRating.ChkItem4;
            chkItem5.Checked = (bool)CarRating.ChkItem5;
            chkItem6.Checked = (bool)CarRating.ChkItem6;
            chkItem7.Checked = (bool)CarRating.ChkItem7;
            chkItem8.Checked = (bool)CarRating.ChkItem8;
            chkItem9.Checked = (bool)CarRating.ChkItem9;
            chkPayLatter.Checked = (bool)CarRating.PayLater;
            chkItem10.Checked = (bool)CarRating.ChkItem10;
            chkItem11.Checked = (bool)CarRating.ChkItem11;
            txtOthers.Text = CarRating.Other;
            nudTestValue.Value = Convert.ToDecimal(CarRating.TestPrice);

            _Mood = enMood.Update;
            btnSaveResult.Text = "تعديل";



        }

        private clsCarRating _FillObjWithValues()
        {

            CarRating.Car.CarMakeModel = cmbCarType.Text;
            CarRating.Car.CarPlateNumber = txtPlateNumber.Text;
            CarRating.Car.CarShassiNumber = txtShasiNumber.Text;
            CarRating.Car.CarMinufacuringYear = cmbYear.Text;
            CarRating.Car.CarEnginCapacity = cmbEnginCapacity.Text;
            CarRating.Car.CarColor = cmbCarColor.Text;


            CarRating.RegstrationNumber = txtRegstrationNumber.Text;
            CarRating.Bank = cmbBankName.Text;
            CarRating.UseType = cmbUseType.Text;
            CarRating.InsuranceType = cmbInsuranceType.Text;
            CarRating.EnginNumber = txtEnginNumber.Text;
            CarRating.CarOwner = txtCarOwner.Text;
            CarRating.CarCapacity = cmbCarCapacity.Text;
            CarRating.CarCountry = cmbCarCountry.Text;
            CarRating.CustumerName = txtBuyer.Text;
            CarRating.CarStatus = txtCarStatius.Text;


            CarRating.FRShassi = cmbFRShasi.Text;
            CarRating.FLShassi = cmbFLShasi.Text;
            CarRating.BRShassi = cmbUseType.Text;
            CarRating.BLShassi = cmbBLShasi.Text;
            CarRating.BodyTest = txtBody.Text;
            CarRating.EnginTestPerc = cmbEnginPerc.Text;
            CarRating.EnginTest = cmbEnginTest.Text;
            CarRating.GearTest = cmbGearTest.Text;
            CarRating.BakaksTest = cmbBakaks.Text;
            CarRating.WorkerNotes = cmbWorkerName.Text;


            CarRating.BodyValue = string.IsNullOrEmpty(txtBodyRat.Text) ? 0 : Convert.ToDouble(txtBodyRat.Text);
            CarRating.StampValue = string.IsNullOrEmpty(txtStampRate.Text) ? 0 : Convert.ToDouble(txtStampRate.Text);
            CarRating.TotalValue = string.IsNullOrEmpty(txtTotalValue.Text) ? 0 : Convert.ToDouble(txtTotalValue.Text);
            CarRating.TotalValueAsString = txtTotalValueAsString.Text;
            CarRating.TestPrice = (double)nudTestValue.Value;


            CarRating.ChkItem1 = chkItem1.Checked;
            CarRating.ChkItem2 = chkItem2.Checked;
            CarRating.ChkItem3 = chkItem3.Checked;
            CarRating.ChkItem4 = chkItem4.Checked;
            CarRating.ChkItem5 = chkItem5.Checked;
            CarRating.ChkItem6 = chkItem6.Checked;
            CarRating.ChkItem7 = chkItem7.Checked;
            CarRating.ChkItem8 = chkItem8.Checked;
            CarRating.ChkItem9 = chkItem9.Checked;
            CarRating.ChkItem10 = chkItem10.Checked;
            CarRating.ChkItem11 = chkItem11.Checked;
            CarRating.PayLater = chkPayLatter.Checked;


            CarRating.Other = txtOthers.Text;

            return CarRating;
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            CarRating = _FillObjWithValues();

            if (CarRating.SaveForRating())
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
