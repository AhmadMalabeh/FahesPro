using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarTestDataAccessLayer;
using SharedObj;
namespace CarTestLogicalLayer
{
    public class clsCarTest
    {
        protected int ID {  get; set; }
        public string CustumerName { get; set; }
        public string FRShassi { get; set; }
        public string FLShassi { get; set; }
        public string BRShassi { get; set; }
        public string BLShassi { get; set; }
        public string EnginTest { get; set; }
        public string EnginTestPerc {  get; set; }
        public string GearTest { get; set; }
        public string BakaksTest { get; set; }
        public string BodyTest { get; set; }
        public string WorkerNotes {  get; set; }
        public DateTime TestDate { get; set; }
        public double TestPrice { get; set; }
        public string CenterNotes { get; set; }
        public bool PayLater { get; set; }

        public clsCar Car;

        private enum enMood
        {
            AddNew,
            Update
        }

        clsSharedclsCarTest CarTestDTO;

        enMood _Mood;
        public clsCarTest()
        {
            CustumerName = "";
            FRShassi = "";
            FLShassi = "";
            BRShassi = "";
            BLShassi = "";
            EnginTest = "";
            EnginTestPerc = "";
            GearTest = "";
            BakaksTest = "";
            BodyTest = "";
            WorkerNotes = "";
            TestDate = DateTime.Now;
            TestPrice = -1;
            CenterNotes = "";
            PayLater = false;
            Car = new clsCar();
            CarTestDTO = new clsSharedclsCarTest();
            _Mood = enMood.AddNew;
        }


        private clsSharedclsCarTest _ToDTO()
        {
            CarTestDTO = new clsSharedclsCarTest();
            CarTestDTO.ID = this.ID;
            CarTestDTO.CustumerName = this.CustumerName;
            CarTestDTO.FRShassi = this.FRShassi;
            CarTestDTO.FLShassi = this.FLShassi;
            CarTestDTO.BRShassi = this.BRShassi;
            CarTestDTO.BLShassi = this.BLShassi;
            CarTestDTO.EnginTest = this.EnginTest;
            CarTestDTO.EnginTestPerc = this.EnginTestPerc;
            CarTestDTO.GearTest = this.GearTest;
            CarTestDTO.BakaksTest = this.BakaksTest;
            CarTestDTO.BodyTest = this.BodyTest;
            CarTestDTO.WorkerNotes = this.WorkerNotes;
            CarTestDTO.CenterNotes = this.CenterNotes;
            CarTestDTO.TestDate = this.TestDate;
            CarTestDTO.TestPrice = this.TestPrice;
            CarTestDTO.PayLater = this.PayLater;

            CarTestDTO.CarPlateNumber = this.Car.CarPlateNumber;
            CarTestDTO.CarShassiNumber = this.Car.CarShassiNumber;
            CarTestDTO.CarMakeModel = this.Car.CarMakeModel;
            CarTestDTO.CarMinufacuringYear = this.Car.CarMinufacuringYear;
            CarTestDTO.CarColor = this.Car.CarColor;
            CarTestDTO.CarEnginCapacity = this.Car.CarEnginCapacity;

            return CarTestDTO;

        }


        protected clsCarTest(clsSharedclsCarTest DTO)
        {
            if (DTO == null) throw new ArgumentNullException(nameof(DTO));

            Car = new clsCar(DTO); 

            ID = DTO.ID;
            CustumerName = DTO.CustumerName ?? "";
            FRShassi = DTO.FRShassi ?? "";
            FLShassi = DTO.FLShassi ?? "";
            BRShassi = DTO.BRShassi ?? "";
            BLShassi = DTO.BLShassi ?? "";
            EnginTest = DTO.EnginTest ?? "";
            EnginTestPerc = DTO.EnginTestPerc ?? "";
            GearTest = DTO.GearTest ?? "";
            BakaksTest = DTO.BakaksTest ?? "";
            BodyTest = DTO.BodyTest ?? "";
            WorkerNotes = DTO.WorkerNotes ?? "";
            TestDate = DTO.TestDate != DateTime.MinValue ? DTO.TestDate : DateTime.Now;
            TestPrice = DTO.TestPrice;
            CenterNotes = DTO.CenterNotes ?? "";
            PayLater = DTO.PayLater;

            _Mood = enMood.Update;
        }




        public static DataTable getAllTests()
        {
            return clsTestData.GetAllTests();
        }

        public static DataTable SearchByPlateNumber(string PlateNumber)
        {
            return clsTestData.GetTestByPlateNumber(PlateNumber);
        }




        public static clsCarTest GetCarInfoByID(int carID)
        {
            clsSharedclsCarTest dto = clsTestData.GetCarTestDTOByID(carID);

            if (dto == null)
                return null;

            return new clsCarTest(dto);
        }


        public static DataTable SearchByShasiNumber(string ShasiNumber)
        {
            return clsTestData.GetInfoByShasiNumber(ShasiNumber);
        }

        public static DataTable GetAllInfoBetweenTowDates(string FromDate,string ToDate)
        {
            return clsTestData.GetInfoFromDateToDate(FromDate, ToDate);
        }


        private bool _AddNewTest()
        {
            clsSharedclsCarTest dto = _ToDTO();

            this.ID = clsTestData.AddNewTest(dto);

            return this.ID > 0;
        }

        private bool _UpdateTest()
        {
            clsSharedclsCarTest dto = _ToDTO();

            return clsTestData.UpdateTest(dto);
        }



        public bool Save()
        {
            switch (_Mood)
            {
                case enMood.AddNew:
                    if (_AddNewTest())
                    {
                        _Mood = enMood.Update;
                        return true;
                    }
                    return false;

                case enMood.Update:
                    return _UpdateTest();
            }

            return false;
        }




        public static DataTable GetAllTodayTests()
        {
            return clsTestData.GetAllTodayTest();
        }
    }
}
