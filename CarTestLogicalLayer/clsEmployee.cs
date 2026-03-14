using CarTestDataAccessLayer;
using SharedObj;
using System;
using System.Data;

namespace CarTestLogicalLayer
{
    public class clsEmployee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string NationalID { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool IsActive { get; set; }

        public string ErrorMessage { get; private set; } = "";

        private enum enMood { AddNew, Update }
        private enMood _Mood;

        // ===== Constructors =====

        public clsEmployee()
        {
            EmployeeID = -1;
            FullName = "";
            NationalID = "";
            PhoneNumber = "";
            Salary = 0;
            HireDate = DateTime.Today;
            TerminationDate = null;
            IsActive = true;
            _Mood = enMood.AddNew;
        }

        private clsEmployee(clsSharedEmployee dto)
        {
            EmployeeID = dto.EmployeeID;
            FullName = dto.FullName ?? "";
            NationalID = dto.NationalID ?? "";
            PhoneNumber = dto.PhoneNumber ?? "";
            Salary = dto.Salary;
            HireDate = dto.HireDate;
            TerminationDate = dto.TerminationDate;
            IsActive = dto.IsActive;
            _Mood = enMood.Update;
        }

        // ===== Private Methods =====

        private clsSharedEmployee _ToDTO()
        {
            return new clsSharedEmployee
            {
                EmployeeID = this.EmployeeID,
                FullName = this.FullName,
                NationalID = this.NationalID,
                PhoneNumber = this.PhoneNumber,
                Salary = this.Salary,
                HireDate = this.HireDate,
                TerminationDate = this.TerminationDate,
                IsActive = this.IsActive
            };
        }

        private bool _IsValid()
        {
            if (string.IsNullOrWhiteSpace(FullName))
            {
                ErrorMessage = "يرجى إدخال اسم الموظف";
                return false;
            }

            if (string.IsNullOrWhiteSpace(NationalID))
            {
                ErrorMessage = "يرجى إدخال المعرف الوطني";
                return false;
            }

            if (clsEmployeeData.IsNationalIDExist(NationalID, EmployeeID))
            {
                ErrorMessage = "المعرف الوطني مسجل مسبقاً";
                return false;
            }

            if (Salary <= 0)
            {
                ErrorMessage = "يرجى إدخال راتب صحيح";
                return false;
            }

            if (HireDate > DateTime.Today)
            {
                ErrorMessage = "تاريخ التوظيف لا يمكن أن يكون في المستقبل";
                return false;
            }

            return true;
        }

        private bool _AddNew()
        {
            this.EmployeeID = clsEmployeeData.AddEmployee(_ToDTO());
            return this.EmployeeID > 0;
        }

        private bool _Update()
        {
            return clsEmployeeData.UpdateEmployee(_ToDTO());
        }

        public bool Reactivate()
        {
            if (_Mood == enMood.AddNew)
            {
                ErrorMessage = "لا يمكن إعادة توظيف موظف غير محفوظ";
                return false;
            }

            if (IsActive)
            {
                ErrorMessage = "الموظف نشط مسبقاً";
                return false;
            }

            if (clsEmployeeData.ReactivateEmployee(EmployeeID))
            {
                IsActive = true;
                TerminationDate = null;
                return true;
            }

            return false;
        }
        // ===== Public Static Methods =====


        public static clsEmployee GetByID(int employeeID)
        {
            clsSharedEmployee dto = clsEmployeeData.GetEmployeeByID(employeeID);
            return dto == null ? null : new clsEmployee(dto);
        }

        public static clsEmployee GetByNationalID(string nationalID)
        {
            clsSharedEmployee dto = clsEmployeeData.GetEmployeeByNationalID(nationalID);
            return dto == null ? null : new clsEmployee(dto);
        }

        public static DataTable GetAllEmployees()
        {
            return clsEmployeeData.GetAllEmployees();
        }

        public static DataTable GetActiveEmployees()
        {
            return clsEmployeeData.GetActiveEmployees();
        }

        // ===== Public Methods =====

        public bool Save()
        {
            if (!_IsValid()) return false;

            switch (_Mood)
            {
                case enMood.AddNew:
                    if (_AddNew())
                    {
                        _Mood = enMood.Update;
                        return true;
                    }
                    return false;

                case enMood.Update:
                    return _Update();
            }

            return false;
        }

        public bool Deactivate()
        {
            if (_Mood == enMood.AddNew)
            {
                ErrorMessage = "لا يمكن إنهاء خدمة موظف غير محفوظ";
                return false;
            }

            if (!IsActive)
            {
                ErrorMessage = "الموظف غير نشط مسبقاً";
                return false;
            }

            TerminationDate = DateTime.Today;

            if (clsEmployeeData.DeactivateEmployee(EmployeeID, DateTime.Today))
            {
                IsActive = false;
                return true;
            }

            return false;
        }
    }
}
