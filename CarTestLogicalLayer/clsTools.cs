using CarTestDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarTestLogicalLayer
{
    public class clsTools
    {
        public int CarCodeID {  get; set; }
        public string CarIssue {  get; set; }

        public int MinuID { get; set; }

        enum enMode
        {
            AddNew,
            Update
        }
        enMode _Mode;

        public clsTools()
        {
            CarCodeID = -1;
            CarIssue = "";
            MinuID = -1;
            _Mode = enMode.AddNew;
        }

        public clsTools(int ToolID,int minuID, string carIssue)
        {
            CarCodeID = ToolID;
            CarIssue = carIssue;
            MinuID = minuID;
            _Mode = enMode.Update;
        }

        private bool _AddNewIssue()
        {
            if (MinuID <= 0 || string.IsNullOrWhiteSpace(CarIssue))
                return false;
            this.CarCodeID= clsTestData.AddNewIssue(this.MinuID, this.CarIssue);
            return this.CarCodeID > 0;
        }

        private bool _UpdateIssue()
        {
            return clsTestData.UpdateIssue(this.CarCodeID, this.CarIssue);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewIssue())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateIssue();



            }
            return false;
        }

        public bool DeleteIssue()
        {
            if (_Mode == enMode.Update)
            {
                return clsTestData.DeleteIssue(this.CarCodeID);
            }
            return false;
        }


        public static DataTable GetIssuesMinus()
        {
            return clsTestData.GetIssuesMinus();
        }

        public static DataTable GetIssuesByMinuID(int minuID)
        {
            return clsTestData.GetIssueByMinuID(minuID);
        }

        public static DataTable GetAllIssues()
        {
            return clsTestData.GetAllIssues();
        }
    }
}
