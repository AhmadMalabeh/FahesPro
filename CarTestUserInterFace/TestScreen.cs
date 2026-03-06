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
using System.Xml.Linq;

namespace CarTestUserInterFace
{
    public partial class TestScreen : Form
    {

        clsCarTest CarTest;
        clsCarTest CopyTest;

        DateTime minValidDate = new DateTime(2026, 2, 15);
        enum enMood { AddNew, Update };

        enMood _Mood;


        private void FillComboBoxes(ComboBox cmb,DataView dvShasiIssue)
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

            FillComboBoxes(cmbBodyBox, dvOthers);
            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'نسبة الماتور'";
            FillComboBoxes(cmbEnginTestPersantig, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'فحص الماتور'";
            FillComboBoxes(cmbEnginTest, dvOthers);
            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'فحص الجير'";
            FillComboBoxes(cmbGearTest, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'فحص الباك اكس'";
            FillComboBoxes(cmbBakkaksTest, dvOthers);
            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'اسم المشتري'";
            FillComboBoxes(cmbCoustumerName, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'لون السيارة'";
            FillComboBoxes(cmbCarColor, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'نوع السيارة'";
            FillComboBoxes(cmbCarType, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'موديل السيارة(سنة الصنع)'";
            FillComboBoxes(cmbCarModel, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'سعة الحرك'";
            FillComboBoxes(cmbEnginCapacity, dvOthers);

            dvOthers = new DataView(dtAllIssues);
            dvOthers.RowFilter = "MinuName = 'اسم الفاحص'";
            FillComboBoxes(cmbWorkerName, dvOthers);
        }

        private void AssignImagesToImageList()
        {
            imageList1.Images.Add(Properties.Resources.save_file_disk_open_searsh_loading_clipboard_15131);
            imageList1.Images.Add(Properties.Resources._62827printer_1092281);
            button3.Image = imageList1.Images[0];
            btnSaveResult.Image = imageList1.Images[1];
        }
        public TestScreen()
        {
            InitializeComponent();
            AssignIssueToComboBoxes();
            AssignImagesToImageList();
            CarTest = new clsCarTest();
            CopyTest = new clsCarTest();
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            _Mood = enMood.AddNew;
            int CurrentID = clsCarTest.GetLastID() + 1;
            txtID.Text = CurrentID.ToString();  

            btnShowNotes.Tag = "1";

            
        }

        private void FillControlsWithData(clsCarTest TestValues)
        {
            txtCarPlateNumber.Text = TestValues.Car.CarPlateNumber;
            txtCarShasiNumber.Text = TestValues.Car.CarShassiNumber;
            cmbCarColor.Text = TestValues.Car.CarColor;
            cmbCarModel.Text = TestValues.Car.CarMinufacuringYear;
            cmbCarType.Text = TestValues.Car.CarMakeModel;
            cmbEnginCapacity.Text = TestValues.Car.CarEnginCapacity;
            cmbCoustumerName.Text = TestValues.CustumerName;
            txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            cmbFRShasi.Text = TestValues.FRShassi;
            cmbFLShasi.Text = TestValues.FLShassi;
            cmbBRShasi.Text = TestValues.BRShassi;
            cmbBLShasi.Text = TestValues.BLShassi;
            cmbEnginTestPersantig.Text = TestValues.EnginTestPerc;
            cmbEnginTest.Text = TestValues.EnginTest;
            cmbGearTest.Text = TestValues.GearTest;
            cmbBakkaksTest.Text = TestValues.BakaksTest;
            txtBodyTest.Text = TestValues.BodyTest;
            cmbWorkerName.Text = TestValues.WorkerNotes;
            txtCenterNotes.Text = TestValues.CenterNotes;
            nbdTestPrice.Value = Convert.ToDecimal(TestValues.TestPrice);
            chkCachOrPayLater.Checked = TestValues.PayLater;
        }


        public TestScreen(int CarID)
        {
            InitializeComponent();
            txtID.Text = CarID.ToString();
            AssignIssueToComboBoxes();
            AssignImagesToImageList();

            CarTest = clsCarTest.GetCarInfoByID(CarID);

            FillControlsWithData(CarTest);

            txtDate.Text = CarTest.TestDate.ToString("dd-MM-yyyy");
            

            _Mood = enMood.Update;
            btnSaveResult.Text = "  تعديل";
            btnShowNotes.Tag = "1";
        }


        private clsCarTest _FillCarObjWithValue()
        {
            if (CarTest == null) CarTest = new clsCarTest();
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


            TestScreenErrorProvider.Clear();
            bool hasError = false;

            
            Control[] inputsToCheck = { txtCarPlateNumber, txtCarShasiNumber, cmbCoustumerName,cmbCarModel,cmbCarType,
                                        cmbCarColor,cmbFRShasi,cmbFLShasi,cmbBRShasi,cmbBLShasi,cmbEnginTest,cmbGearTest,cmbBakkaksTest,
                                        txtBodyTest};

            foreach (var input in inputsToCheck)
            {
                if (string.IsNullOrWhiteSpace(input.Text))
                {
                    TestScreenErrorProvider.SetError(input, "هذا الحقل مطلوب!");
                    hasError = true;
                }
            }

            
            if (!hasError) 
            {
                CarTest = _FillCarObjWithValue();
                if (nbdTestPrice.Value < 5 && CarTest.TestDate>=minValidDate)
                {
                    MessageBox.Show("خطاء السعر لا يمكن ان يكون اقل من 5 دنانير");
                    return;
                }

                if (CarTest.Save())
                {
                    MessageBox.Show("تم حفظ البيانات بنجاح");


                    _Mood = enMood.Update;
                    btnSaveResult.Text = "  تعديل";
                    button3.Enabled = true;
                }
                else
                {
                    MessageBox.Show(CarTest.ErrorMessage);
                }
            }

        }

        private void TestScreen_Load(object sender, EventArgs e)
        {

            


            if (_Mood == enMood.AddNew)
            {
                button3.Enabled = false;
            }
            if(txtCenterNotes.Text.Length > 0)
            {
                btnShowNotes.BackColor = Color.Green;
            }
        }

        private bool IsThereAPrevTest()
        {
            CopyTest = clsCarTest.GetTestByPlateNumberForCopy(txtCarPlateNumber.Text.Trim());

            return CopyTest != null;
        }

        private bool IsThereAPrevTestByShasiNumber()
        {
            CopyTest = clsCarTest.GetTestByShasiNumberForCopy(txtCarShasiNumber.Text.Trim());

            return CopyTest != null;
        }

        private void picPrevTestByPlateNumber_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FillControlsWithData(CopyTest);
        }

        private void txtCarPlateNumber_Leave(object sender, EventArgs e)
        {

            if (txtCarPlateNumber.Text.Trim().Length > 0 && _Mood == enMood.AddNew)
            {
                if (IsThereAPrevTest())
                {
                    picPrevTestByPlateNumber.Visible = true;
                    string infoMessage = CopyTest.TestDate.ToShortDateString();
                    toolTip1.SetToolTip(picPrevTestByPlateNumber, infoMessage);
                }
                
            }
        }

        private void picPrevTestByShasiNumber_DoubleClick(object sender, EventArgs e)
        {
            FillControlsWithData(CopyTest);
        }

        private void txtCarShasiNumber_Leave(object sender, EventArgs e)
        {
            if (txtCarShasiNumber.Text.Trim().Length > 0 && _Mood == enMood.AddNew)
            {
                if (IsThereAPrevTestByShasiNumber())
                {
                    picPrevTestByShasiNumber.Visible = true;
                    string infoMessage = CopyTest.TestDate.ToShortDateString();
                    toolTip1.SetToolTip(picPrevTestByShasiNumber, infoMessage);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clsPrintTestReport printer = new clsPrintTestReport();

            var data = new
            {
                PlateNumber = CarTest.Car.CarPlateNumber.ToString(),
                ShasiNumber = CarTest.Car.CarShassiNumber.ToString(),
                CarType = CarTest.Car.CarMakeModel.ToString(),
                CustumerName = CarTest.CustumerName.ToString(),
                CarColor = CarTest.Car.CarColor.ToString(),
                CarModel = CarTest.Car.CarMinufacuringYear.ToString(),
                EnginNumber = CarTest.Car.CarEnginCapacity.ToString(),
                FRShasi = CarTest.FRShassi.ToString(),
                FLShasi = CarTest.FLShassi.ToString(),
                BRShasi = CarTest.BRShassi.ToString(),
                BLShasi = CarTest.BLShassi.ToString(),
                EnginPerc = CarTest.EnginTestPerc.ToString(),
                EnginTest = CarTest.EnginTest.ToString(),
                GearTest = CarTest.GearTest.ToString(),
                BakaksTest = CarTest.BakaksTest.ToString(),
                BodyTest = CarTest.BodyTest.ToString(),
                TestDate = CarTest.TestDate.ToString("dd-MM-yyyy"),
                TestPrice = CarTest.TestPrice.ToString("N2")
            };

            MemoryStream ms = null;

            if (chkPrintOnTemplate.Checked)
            {
                ms = printer.CreateInspectionPdfStreamAsPDFFileWithTemplate(data);
            }

            else
            {
                ms = printer.CreateInspectionPdfStream(data);
            }
            
            using (ms)
            {
                using (frmPreview preview = new frmPreview(ms))
                {
                    preview.ShowDialog();
                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void cmbBodyBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbBodyBox.SelectedIndex != -1) // التأكد أن الاختيار ليس فارغاً
            {
                DataRowView row = (DataRowView)cmbBodyBox.SelectedItem;
                txtBodyTest.Text += row["CarIssue1"].ToString();
            }
        }
    }
}
