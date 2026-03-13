using CarTestDataAccessLayer;
using SharedLogging;
using SharedObj;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
namespace CarTestLogicalLayer
{
    public class clsCarRating : clsCarTest
    {
        public string RegstrationNumber { get; set; }
        public string Bank {  get; set; }
        public string UseType { get; set; }
        public string InsuranceType { get; set; }
        public string EnginNumber { get; set; }
        public string CarOwner {  get; set; }
        public string CarCapacity { get; set; }
        public string CarCountry { get; set; }
        public string CarStatus { get; set; }
        public double BodyValue { get; set; }
        public double StampValue { get; set; }
        public double TotalValue { get; set; }
        public string TotalValueAsString { get; set; }
        public bool ChkItem1 { get; set; }
        public bool ChkItem2 { get; set; }
        public bool ChkItem3 { get; set; }
        public bool ChkItem4 { get; set; }
        public bool ChkItem5 { get; set; }
        public bool ChkItem6 { get; set; }
        public bool ChkItem7 { get; set; }
        public bool ChkItem8 { get; set; }
        public bool ChkItem9 { get; set; }
        public bool ChkItem10 { get; set; }
        public bool ChkItem11 { get; set; }

        public string Other {  get; set; }

        

        public string ErrorMessageForRating { get; private set; } = "";


        private enum enMood
        {
            AddNew,
            Update
        }

        enMood _Mood;

        public clsCarRating() : base()
        {
            
            RegstrationNumber = "";
            Bank = "";
            UseType = "";
            InsuranceType = "";
            EnginNumber = "";
            CarOwner = "";
            CarCapacity = "";
            CarCountry = "";
            CarStatus = "";
            BodyValue = 0;
            StampValue = 0;
            TotalValue = 0;
            TotalValueAsString = "";
            ChkItem1 = false;
            ChkItem2 = false;
            ChkItem3 = false;
            ChkItem4 = false;
            ChkItem5 = false;
            ChkItem6 = false;
            ChkItem7 = false;
            ChkItem8 = false;
            ChkItem9 = false;
            ChkItem10 = false;
            ChkItem11 = false;
            Other = "";
            CarRatingDTO = new clsSharedclsCarRating();
            _Mood = enMood.AddNew;

        }


        clsSharedclsCarRating CarRatingDTO;


        protected clsCarRating(clsSharedclsCarRating CarRatingDTO) : base(CarRatingDTO)
        {
            if (CarRatingDTO == null) throw new ArgumentNullException(nameof(CarRatingDTO));
            RegstrationNumber = CarRatingDTO.RegstrationNumber ?? ""; 
            Bank = CarRatingDTO.Bank ?? ""; 
            UseType = CarRatingDTO.UseType ?? ""; 
            InsuranceType = CarRatingDTO.InsuranceType ?? ""; 
            EnginNumber = CarRatingDTO.EnginNumber ?? ""; 
            CarOwner = CarRatingDTO.CarOwner ?? ""; 
            CarCapacity = CarRatingDTO.CarCapacity ?? ""; 
            CarCountry = CarRatingDTO.CarCountry ?? ""; 
            CarStatus = CarRatingDTO.CarStatus ?? ""; 
            BodyValue = CarRatingDTO.BodyValue;
            StampValue = CarRatingDTO.StampValue;
            TotalValue = CarRatingDTO.TotalValue;
            TotalValueAsString = CarRatingDTO.TotalValueAsString ?? "";
            ChkItem1 = CarRatingDTO.ChkItem1;
            ChkItem2 = CarRatingDTO.ChkItem2;
            ChkItem3 = CarRatingDTO.ChkItem3;
            ChkItem4 = CarRatingDTO.ChkItem4;
            ChkItem5 = CarRatingDTO.ChkItem5;
            ChkItem6 = CarRatingDTO.ChkItem6;
            ChkItem7 = CarRatingDTO.ChkItem7;
            ChkItem8 = CarRatingDTO.ChkItem8;
            ChkItem9 = CarRatingDTO.ChkItem9;
            ChkItem10 = CarRatingDTO.ChkItem10;
            ChkItem11 = CarRatingDTO.ChkItem11;
            Other = CarRatingDTO.Other ?? "";
            CreatedByUserID = CarRatingDTO.CreatedByUserID;
            ModifiedByUserID = CarRatingDTO.ModifiedByUserID;
            _Mood = enMood.Update;
        }



        public static clsCarRating GetCarInfoByIDForUpdate(int CarID)
        {
            clsSharedclsCarRating dto = clsTestData.GetCarRatingDTOByID(CarID);

            if (dto == null)
                return null;

            return new clsCarRating(dto);
        }


        private clsSharedclsCarRating _ToDTO()
        {
            CarRatingDTO = new clsSharedclsCarRating();

            CarRatingDTO.ID = this.ID;
            CarRatingDTO.CustumerName = this.CustumerName;
            CarRatingDTO.FRShassi = this.FRShassi;
            CarRatingDTO.FLShassi = this.FLShassi;
            CarRatingDTO.BRShassi = this.BRShassi;
            CarRatingDTO.BLShassi = this.BLShassi;
            CarRatingDTO.EnginTest = this.EnginTest;
            CarRatingDTO.EnginTestPerc = this.EnginTestPerc;
            CarRatingDTO.GearTest = this.GearTest;
            CarRatingDTO.BakaksTest = this.BakaksTest;
            CarRatingDTO.BodyTest = this.BodyTest;
            CarRatingDTO.WorkerNotes = this.WorkerNotes;
            CarRatingDTO.CenterNotes = this.CenterNotes;
            CarRatingDTO.TestDate = this.TestDate;
            CarRatingDTO.TestPrice = this.TestPrice;
            CarRatingDTO.PayLater = this.PayLater;

            CarRatingDTO.CarPlateNumber = this.Car.CarPlateNumber;
            CarRatingDTO.CarShassiNumber = this.Car.CarShassiNumber;
            CarRatingDTO.CarMakeModel = this.Car.CarMakeModel;
            CarRatingDTO.CarMinufacuringYear = this.Car.CarMinufacuringYear;
            CarRatingDTO.CarColor = this.Car.CarColor;
            CarRatingDTO.CarEnginCapacity = this.Car.CarEnginCapacity;

            // الخصائص الجديدة
            CarRatingDTO.RegstrationNumber = this.RegstrationNumber;
            CarRatingDTO.Bank = this.Bank;
            CarRatingDTO.UseType = this.UseType;
            CarRatingDTO.InsuranceType = this.InsuranceType;
            CarRatingDTO.EnginNumber = this.EnginNumber;
            CarRatingDTO.CarOwner = this.CarOwner;
            CarRatingDTO.CarCapacity = this.CarCapacity;
            CarRatingDTO.CarCountry = this.CarCountry;
            CarRatingDTO.CarStatus = this.CarStatus;
            CarRatingDTO.BodyValue = this.BodyValue;
            CarRatingDTO.StampValue = this.StampValue;
            CarRatingDTO.TotalValue = this.TotalValue;
            CarRatingDTO.TotalValueAsString = this.TotalValueAsString;
            CarRatingDTO.ChkItem1 = this.ChkItem1;
            CarRatingDTO.ChkItem2 = this.ChkItem2;
            CarRatingDTO.ChkItem3 = this.ChkItem3;
            CarRatingDTO.ChkItem4 = this.ChkItem4;
            CarRatingDTO.ChkItem5 = this.ChkItem5;
            CarRatingDTO.ChkItem6 = this.ChkItem6;
            CarRatingDTO.ChkItem7 = this.ChkItem7;
            CarRatingDTO.ChkItem8 = this.ChkItem8;
            CarRatingDTO.ChkItem9 = this.ChkItem9;
            CarRatingDTO.ChkItem10 = this.ChkItem10;
            CarRatingDTO.ChkItem11 = this.ChkItem11;
            CarRatingDTO.Other = this.Other;
            CarRatingDTO.CreatedByUserID = this.CreatedByUserID;
            CarRatingDTO.ModifiedByUserID = this.ModifiedByUserID;
            return CarRatingDTO;
        }


        private bool _AddNewRating()
        {
            clsSharedclsCarRating dto = _ToDTO();
            this.ID = clsTestData.AddNewRating(dto);
            return (this.ID > 0);

        }
        private bool _UpdateRating()
        {
            clsSharedclsCarRating dto = _ToDTO();
            return clsTestData.UpdateRating(dto);
        }

        protected override bool _IsFullObjectValid()
        {
            if (!base._IsFullObjectValid())
            {
                return false;
            }
            bool areNewFieldsValid =
                                  !string.IsNullOrWhiteSpace(Bank) &&
                                  !string.IsNullOrWhiteSpace(UseType) &&
                                  !string.IsNullOrWhiteSpace(CarStatus) &&
                                  !string.IsNullOrWhiteSpace(TotalValueAsString) &&
                                  BodyValue >= 0 &&
                                  TotalValue >= 0;
            return areNewFieldsValid;
        }

        public bool SaveForRating(int currentUserID)
        {

            if (!_IsFullObjectValid())
            {
                ErrorMessageForRating = "خطأ في عملية الحفظ يرجى تعبئة الحقول بالقيم الصحيحة";
                return false;
            }
            try
            {
                switch (_Mood)
                {
                    case enMood.AddNew:
                        CreatedByUserID = currentUserID;
                        ModifiedByUserID = null;
                        if (_AddNewRating())
                        {
                            _Mood = enMood.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case enMood.Update:
                        ModifiedByUserID = currentUserID;
                        return _UpdateRating();

                }
                return false;
            }
            catch (Exception ex)
            {
                clsLogger.LogError(ex, $"BLL -> SaveForRating | Mood = {_Mood}");
                return false;
            }

        }
    }
}
