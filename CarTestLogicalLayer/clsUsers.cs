using CarTestDataAccessLayer;
using SharedObj;
using System;
using System.Data;

namespace CarTestLogicalLayer
{
    public class clsUsers
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        public string ErrorMessage { get; private set; } = "";

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public clsUsers()
        {
            UserID = -1;
            UserName = "";
            Password = "";
            IsAdmin = false;
            IsActive = true;
            _Mode = enMode.AddNew;
        }

        private clsUsers(clsSharedclsUsers dto)
        {
            UserID = dto.UserID;
            UserName = dto.UserName;
            Password = dto.Password;
            IsAdmin = dto.IsAdmin;
            IsActive = dto.IsActive;
            _Mode = enMode.Update;
        }

        private clsSharedclsUsers _ToDTO()
        {
            return new clsSharedclsUsers
            {
                UserID = this.UserID,
                UserName = this.UserName,
                Password = this.Password,
                IsAdmin = this.IsAdmin,
                IsActive = this.IsActive
            };
        }

        // ===== Validation =====

        private bool _IsValid()
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                ErrorMessage = "يرجى إدخال اسم المستخدم";
                return false;
            }

            if (clsTestData.IsUserNameExist(UserName, UserID))
            {
                ErrorMessage = "اسم المستخدم مسجل مسبقاً";
                return false;
            }

            if (_Mode == enMode.AddNew && string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "يرجى إدخال كلمة المرور";
                return false;
            }

            return true;
        }

        // ===== Static Methods =====

        public static clsUsers GetUserInfoByUserNameAndPassword(string userName,
                                                                 string password)
        {
            clsSharedclsUsers dto = clsTestData
                .GetUserInfoByUserNameAndPassword(userName, password);

            return dto == null ? null : new clsUsers(dto);
        }

        public static clsUsers GetByID(int userID)
        {
            DataTable dt = clsTestData.GetAllUsers();

            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["UserID"]) == userID)
                {
                    return new clsUsers(new clsSharedclsUsers
                    {
                        UserID = Convert.ToInt32(row["UserID"]),
                        UserName = row["UserName"].ToString(),
                        IsAdmin = Convert.ToBoolean(row["IsAdmin"]),
                        IsActive = Convert.ToBoolean(row["IsActive"])
                    });
                }
            }
            return null;
        }

        public static DataTable GetAllUsers()
        {
            return clsTestData.GetAllUsers();
        }

        // ===== Instance Methods =====

        public bool Save()
        {
            if (!_IsValid()) return false;

            switch (_Mode)
            {
                case enMode.AddNew:
                    int newID = clsTestData.AddNewUser(_ToDTO());
                    if (newID > 0)
                    {
                        UserID = newID;
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return clsTestData.UpdateUser(_ToDTO());
            }

            return false;
        }

        public bool ChangePassword(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                ErrorMessage = "يرجى إدخال كلمة المرور الجديدة";
                return false;
            }

            if (newPassword.Length < 4)
            {
                ErrorMessage = "كلمة المرور يجب أن تكون 4 أحرف على الأقل";
                return false;
            }

            if (clsTestData.ChangePassword(UserID, newPassword))
            {
                Password = newPassword;
                return true;
            }

            return false;
        }

        public bool SetActiveStatus(bool isActive)
        {
            if (UserName.ToLower() == "admin" && !isActive)
            {
                ErrorMessage = "لا يمكن تعطيل حساب Admin";
                return false;
            }

            if (clsTestData.SetUserActiveStatus(UserID, isActive))
            {
                IsActive = isActive;
                return true;
            }

            return false;
        }

        public bool SetAdminStatus(bool isAdmin)
        {
            if (UserName.ToLower() == "admin" && !isAdmin)
            {
                ErrorMessage = "لا يمكن سحب صلاحية Admin من الحساب الرئيسي";
                return false;
            }

            if (clsTestData.SetAdminStatus(UserID, isAdmin))
            {
                IsAdmin = isAdmin;
                return true;
            }

            return false;
        }
    }
}
