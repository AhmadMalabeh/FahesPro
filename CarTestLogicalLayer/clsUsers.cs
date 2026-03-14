using CarTestDataAccessLayer;
using SharedObj;

public class clsUsers
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public int UserID { get; set; }
    public bool IsAdmin { get; set; }

    enum enMode { AddNew, Update, Delete }
    enMode _Mode;

    public clsUsers()
    {
        UserName = "";
        Password = "";
        UserID = -1;
        IsAdmin = false;
        _Mode = enMode.AddNew;
    }

    private clsUsers(clsSharedclsUsers dto)
    {
        UserID = dto.UserID;
        UserName = dto.UserName;
        Password = dto.Password;
        IsAdmin = dto.IsAdmin;
        _Mode = enMode.Update;
    }

    private clsSharedclsUsers ToDTO()
    {
        return new clsSharedclsUsers
        {
            UserID = this.UserID,
            UserName = this.UserName,
            Password = this.Password,
            IsAdmin = this.IsAdmin
        };
    }

    public static clsUsers GetUserInfoByUserNameAndPassword(string UserName, string Password)
    {
        clsSharedclsUsers dto = clsTestData.GetUserInfoByUserNameAndPassword(UserName, Password);
        if (dto == null) return null;
        return new clsUsers(dto);
    }
}
