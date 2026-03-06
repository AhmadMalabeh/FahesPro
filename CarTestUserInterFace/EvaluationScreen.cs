using CarTestLogicalLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;


namespace CarTestUserInterFace
{
    public partial class EvaluationScreen : Form
    {

        clsCarRating CarRating;
        clsCarTest CopyTest;
        DateTime minValidDate = new DateTime(2026, 2, 15);
        enum enMood { AddNew, Update };

        enMood _Mood;


        private void FillComboBoxes(ComboBox cmb, DataView dvShasiIssue)
        {
            cmb.DisplayMember = "CarIssue1";
            cmb.ValueMember = "CarICode1";
            cmb.DataSource = dvShasiIssue;
            cmb.SelectedIndex = -1;
        }



        private void AssignIssueToComboBoxes()
        {
            DataTable dtAllIssues = clsTools.GetAllIssues();

            // 1. إنشاء نسخة مستقلة لفحص الشصي
            DataView dvShasi = new DataView(dtAllIssues);
            dvShasi.RowFilter = "MinuName = 'فحص الشاصيات'";

            FillComboBoxes(cmbFRShasi, new DataView(dtAllIssues) { RowFilter = "MinuName = 'فحص الشاصيات'" });
            FillComboBoxes(cmbFLShasi, new DataView(dtAllIssues) { RowFilter = "MinuName = 'فحص الشاصيات'" });
            FillComboBoxes(cmbBRShasi, new DataView(dtAllIssues) { RowFilter = "MinuName = 'فحص الشاصيات'" });
            FillComboBoxes(cmbBLShasi, new DataView(dtAllIssues) { RowFilter = "MinuName = 'فحص الشاصيات'" });

            // 2. إنشاء نسخة مستقلة تماماً لفحص البودي
            DataView dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'فحص البودي'";

            FillComboBoxes(cmbBodyTest, dvOthers);
            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'نسبة الماتور'";
            FillComboBoxes(cmbEnginPerc, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'فحص الماتور'";
            FillComboBoxes(cmbEnginTest, dvOthers);
            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'فحص الجير'";
            FillComboBoxes(cmbGearTest, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'فحص الباك اكس'";
            FillComboBoxes(cmbBakaks, dvOthers);
            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'اسم المشتري'";
            FillComboBoxes(cmbBuyer, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'لون السيارة'";
            FillComboBoxes(cmbCarColor, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'نوع السيارة'";
            FillComboBoxes(cmbCarType, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'موديل السيارة(سنة الصنع)'";
            FillComboBoxes(cmbYear, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'سعة الحرك'";
            FillComboBoxes(cmbEnginCapacity, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'اسم الفاحص'";
            FillComboBoxes(cmbWorkerName, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'اسم البنك'";
            FillComboBoxes(cmbBankName, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'نوع التأمين'";
            FillComboBoxes(cmbInsuranceType, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'صفة الاستعمال'";
            FillComboBoxes(cmbUseType, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'بلد الصنع'";
            FillComboBoxes(cmbCarCountry, dvOthers);
        }

        private void AssignImageToButtons()
        {
            imageList1.Images.Add(Properties.Resources.save_file_disk_open_searsh_loading_clipboard_15131);
            imageList1.Images.Add(Properties.Resources._62827printer_1092281);
            button3.Image = imageList1.Images[1];
            btnSaveResult.Image = imageList1.Images[0];
        }


        public EvaluationScreen()
        {
            InitializeComponent();
            int CurrentID = clsCarTest.GetLastID() + 1;
            txtID.Text = CurrentID.ToString();
            CarRating = new clsCarRating();
            CopyTest = new clsCarTest();
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            _Mood = enMood.AddNew;
            AssignImageToButtons();
            AssignIssueToComboBoxes();
            button3.Enabled = false;
        }

        private void FillControlsWithData(clsCarTest TestValues)
        {
            txtPlateNumber.Text = TestValues.Car.CarPlateNumber;
            txtShasiNumber.Text = TestValues.Car.CarShassiNumber;
            cmbCarColor.Text = TestValues.Car.CarColor;
            cmbYear.Text = TestValues.Car.CarMinufacuringYear;
            cmbCarType.Text = TestValues.Car.CarMakeModel;
            cmbEnginCapacity.Text = TestValues.Car.CarEnginCapacity;
            cmbBuyer.Text = TestValues.CustumerName;
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cmbFRShasi.Text = TestValues.FRShassi;
            cmbFLShasi.Text = TestValues.FLShassi;
            cmbBRShasi.Text = TestValues.BRShassi;
            cmbBLShasi.Text = TestValues.BLShassi;
            cmbEnginPerc.Text = TestValues.EnginTestPerc;
            cmbEnginTest.Text = TestValues.EnginTest;
            cmbGearTest.Text = TestValues.GearTest;
            cmbBakaks.Text = TestValues.BakaksTest;
            txtBody.Text = TestValues.BodyTest;
            cmbWorkerName.Text = TestValues.WorkerNotes;
            nudTestValue.Value = Convert.ToDecimal(TestValues.TestPrice);
            chkPayLatter.Checked = TestValues.PayLater;
        }

        private bool IsThereAPrevTest()
        {
            CopyTest = clsCarTest.GetTestByPlateNumberForCopy(txtPlateNumber.Text.Trim());

            return CopyTest != null;
        }

        private bool IsThereAPrevTestByShasiNumber()
        {
            CopyTest = clsCarTest.GetTestByShasiNumberForCopy(txtShasiNumber.Text.Trim());

            return CopyTest != null;
        }

        
        private void picPrevTestByShasiNumber_DoubleClick(object sender, EventArgs e)
        {
            FillControlsWithData(CopyTest);
        }

        
        public EvaluationScreen(int ID)
        {
            InitializeComponent();
            AssignIssueToComboBoxes();
            AssignImageToButtons();
            txtID.Text = ID.ToString();
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
            textCarCapacity.Text = CarRating.CarCapacity;
            cmbEnginCapacity.Text = CarRating.Car.CarEnginCapacity;
            cmbCarCountry.Text = CarRating.CarCountry;
            cmbCarColor.Text = CarRating.Car.CarColor;
            cmbBuyer.Text = CarRating.CustumerName;
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
            if(CarRating == null)
            {
                CarRating = new clsCarRating();
            }
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
            CarRating.CarCapacity = textCarCapacity.Text;
            CarRating.CarCountry = cmbCarCountry.Text;
            CarRating.CustumerName = cmbBuyer.Text;
            CarRating.CarStatus = txtCarStatius.Text;


            CarRating.FRShassi = cmbFRShasi.Text;
            CarRating.FLShassi = cmbFLShasi.Text;
            CarRating.BRShassi = cmbBRShasi.Text;
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

            RatingScreenErroeProvider.Clear();
            bool hasError = false;
            RatingScreenErroeProvider.RightToLeft = true;

            Control[] inputsToCheck = { txtPlateNumber, txtShasiNumber, cmbBuyer,cmbYear,cmbCarType,
                                        cmbCarColor,cmbFRShasi,cmbFLShasi,cmbBRShasi,cmbBLShasi,cmbEnginTest,cmbGearTest,cmbBakaks,
                                        txtBody,cmbBankName,cmbUseType,cmbEnginCapacity,txtCarStatius,txtBodyRat,txtTotalValueAsString};


            

            foreach (var input in inputsToCheck)
            {
                if (string.IsNullOrWhiteSpace(input.Text))
                {
                    RatingScreenErroeProvider.SetError(input, "هذا الحقل مطلوب!");
                    hasError = true;
                }
            }

            

            

            if (!hasError)
            {
                CarRating = _FillObjWithValues();
                if (nudTestValue.Value < 5 && CarRating.TestDate >= minValidDate)
                {
                    MessageBox.Show("خطاء السعر لا يمكن ان يكون اقل من 5 دنانير");
                    return;
                }
                if (CarRating.SaveForRating())
                {
                    MessageBox.Show("تم حفظ البيانات بنجاح");


                    _Mood = enMood.Update;
                    btnSaveResult.Text = "تعديل";
                    button3.Enabled = true;
                }
                else
                {
                    MessageBox.Show(CarRating.ErrorMessage);
                }
            }
        }

        private void CheckNumericInput(System.Windows.Forms.TextBox txt)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt.Text, "[^0-9]"))
            {
                MessageBox.Show("يرجى إدخال أرقام فقط!");
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, "[^0-9]", "");

                // إعادة مؤشر الكتابة إلى نهاية النص
                txt.SelectionStart = txt.Text.Length;
            }
        }
        

        private void txtCheckRatingTextBoxes_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;
            CheckNumericInput(txt);
        }

        private void txtTextBoxes_Leave(object sender, EventArgs e)
        {
            txtTotalValue.Text = ( (string.IsNullOrEmpty( txtBodyRat.Text) ? 0 : Convert.ToDouble(txtBodyRat.Text)) +
                (string.IsNullOrEmpty(txtStampRate.Text) ? 0 : Convert.ToDouble(txtStampRate.Text)) ).ToString();
        }

        private void txtTotalValueAsString_Enter(object sender, EventArgs e)
        {
            if (_Mood == enMood.AddNew)
            {
                if (!string.IsNullOrEmpty(txtTotalValue.Text))
                {

                    decimal TotalValue = Convert.ToDecimal(txtTotalValue.Text);
                    txtTotalValueAsString.Text = clsJordanianCurrencyToWords.Convert(TotalValue);
                }
            }
        }

        private void txtPlateNumber_Leave(object sender, EventArgs e)
        {

            if (txtPlateNumber.Text.Trim().Length > 0 && _Mood == enMood.AddNew)
            {
                if (IsThereAPrevTest())
                {
                    picPrevTestByPlateNumber.Visible = true;
                    string infoMessage = CopyTest.TestDate.ToShortDateString();
                    toolTip1.SetToolTip(picPrevTestByPlateNumber, infoMessage);
                }

            }
        }

        private void txtShasiNumber_Leave(object sender, EventArgs e)
        {
            if (txtShasiNumber.Text.Trim().Length > 0 && _Mood == enMood.AddNew)
            {
                if (IsThereAPrevTestByShasiNumber())
                {
                    picPrevTestByShasiNumber.Visible = true;
                    string infoMessage = CopyTest.TestDate.ToShortDateString();
                    toolTip1.SetToolTip(picPrevTestByShasiNumber, infoMessage);
                }

            }
        }

        private void picPrevTestByPlateNumber_DoubleClick(object sender, EventArgs e)
        {
            FillControlsWithData(CopyTest);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clsPrintRatingReport printer = new clsPrintRatingReport();

            var data = new
            {
                PlateNumber = CarRating.Car.CarPlateNumber.ToString(),
                ShasiNumber = CarRating.Car.CarShassiNumber.ToString(),
                CarType = CarRating.Car.CarMakeModel.ToString(),
                CustumerName = CarRating.CustumerName.ToString(),
                CarColor = CarRating.Car.CarColor.ToString(),
                CarModel = CarRating.Car.CarMinufacuringYear.ToString(),
                EnginNumber = CarRating.EnginNumber.ToString(),
                FRShasi = CarRating.FRShassi.ToString(),
                FLShasi = CarRating.FLShassi.ToString(),
                BRShasi = CarRating.BRShassi.ToString(),
                BLShasi = CarRating.BLShassi.ToString(),
                EnginPerc = CarRating.EnginTestPerc.ToString(),
                EnginTest = CarRating.EnginTest.ToString(),
                GearTest = CarRating.GearTest.ToString(),
                BakaksTest = CarRating.BakaksTest.ToString(),
                BodyTest = CarRating.BodyTest.ToString(),
                TestDate = CarRating.TestDate.ToString("dd-MM-yyyy"),
                TestPrice = CarRating.TestPrice.ToString("N2"),
                RegstrationNumber = CarRating.RegstrationNumber.ToString(),
                Bank = CarRating.Bank.ToString(),
                UseType = CarRating.UseType.ToString(),
                InsuranceType= CarRating.InsuranceType.ToString(),
                EnginCapacity = CarRating.Car.CarEnginCapacity.ToString(),
                CarCapacity = CarRating.CarCapacity.ToString(),
                CarStatius = CarRating.CarStatus.ToString(),
                BodyValue= CarRating.BodyValue.ToString(),
                StampValue = CarRating.StampValue.ToString(),
                TotalValue = CarRating.TotalValue.ToString(),
                TotalValueAsString = CarRating.TotalValueAsString.ToString(),
                chkItem1 = CarRating.ChkItem1,
                chkItem2 = CarRating.ChkItem2,
                chkItem3 = CarRating.ChkItem3,
                chkItem4 = CarRating.ChkItem4,
                chkItem5= CarRating.ChkItem5,
                chkItem6 = CarRating.ChkItem6,
                chkItem7 = CarRating.ChkItem7,
                chkItem8 = CarRating.ChkItem8,
                chkItem9 = CarRating.ChkItem9,
                chkItem10 = CarRating.ChkItem10,
                chkItem11 = CarRating.ChkItem11,
                Others = CarRating.Other.ToString()


            };

            MemoryStream ms = printer.CreatRatingPdfStream(data);

            using (ms)
            {
                using (frmPreview preview = new frmPreview(ms))
                {
                    preview.ShowDialog();
                }
            }
        }

        private void EvaluationScreen_Load(object sender, EventArgs e)
        {

        }

        private void cmbBodyTest_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbBodyTest.SelectedIndex != -1) // التأكد أن الاختيار ليس فارغاً
            {
                DataRowView row = (DataRowView)cmbBodyTest.SelectedItem;
                txtBody.Text += row["CarIssue1"].ToString();
            }
        }
    }
}
