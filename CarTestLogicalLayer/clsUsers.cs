using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarTestDataAccessLayer;
using SharedObj;
namespace CarTestLogicalLayer
{
    public class clsUsers
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }

        enum enMode
        {
            AddNew,
            Update,
            Delete
        }

        enMode _Mode;


        public clsUsers()
        {
            UserName = "";
            Password = "";
            UserID = -1;
            _Mode = enMode.AddNew;
        }

        private clsUsers (clsSharedclsUsers dto)
        {
            UserID = dto.UserID;
            UserName = dto.UserName;
            Password = dto.Password;
            _Mode = enMode.Update;
        }

        private clsSharedclsUsers ToDTO()
        {
            clsSharedclsUsers dto = new clsSharedclsUsers();
            dto.UserID = this.UserID;
            dto.UserName = this.UserName;
            dto.Password = this.Password;
            return dto;
        }

        public static clsUsers GetUserInfoByUserNameAndPassword(string UserName,string Password)
        {
            clsSharedclsUsers dto = clsTestData.GetUserInfoByUserNameAndPassword(UserName,Password);
            if (dto == null) return null;
            return new clsUsers(dto);
        }
    }
}
