using SharedObj;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using SharedLogging;
using System.Diagnostics.Contracts;
namespace CarTestDataAccessLayer
{
    public class clsTestData
    {
        
        private static DataTable _ExecuteDataTable(string query, string methodName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLogger.LogError(ex, "DAL -> " + methodName);
                        throw;
                    }
                }
            }
            return dt;
        }

        
        private static int _ExecuteScalar(string query, string methodName, SqlParameter[] parameters)
        {
            int ID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLogger.LogError(ex, "DAL -> " + methodName);
                        throw;
                    }
                }
            }
            return ID;
        }

        
        private static bool _ExecuteNonQuery(string query, string methodName, SqlParameter[] parameters)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsLogger.LogError(ex, "DAL -> " + methodName);
                        throw;
                    }
                }
            }
            return rowsAffected > 0;
        }

        
        private static T _GetSingleItem<T>(string query, string methodName, SqlParameter[] parameters, Func<SqlDataReader, T> mapFunction) where T : class
        {
            T dto = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dto = mapFunction(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLogger.LogError(ex, "DAL -> " + methodName);
                        throw;
                    }
                }
            }
            return dto;
        }

        

        private static clsSharedclsCarTest _MapToCarTest(SqlDataReader reader)
        {
            return new clsSharedclsCarTest
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                CarPlateNumber = reader["PlateNumber"].ToString(),
                CarShassiNumber = reader["ShasiNumber"].ToString(),
                CarMakeModel = reader["RatCrTyp1"].ToString(),
                CarMinufacuringYear = reader["RatYear1"].ToString(),
                CarColor = reader["RatColor1"].ToString(),
                CarEnginCapacity = reader["RatEnginQ1"].ToString(),
                CustumerName = reader["RatBuyer1"].ToString(),
                FRShassi = reader["RatShasiFR1"].ToString(),
                FLShassi = reader["RatShasiFL1"].ToString(),
                BRShassi = reader["RatShasiBR1"].ToString(),
                BLShassi = reader["RatShasiBL1"].ToString(),
                EnginTest = reader["RatEngin1"].ToString(),
                EnginTestPerc = reader["RatEnginPers1"].ToString(),
                GearTest = reader["RatGear1"].ToString(),
                BakaksTest = reader["RatBakaks1"].ToString(),
                BodyTest = reader["RatNote1"].ToString(),
                WorkerNotes = reader["RatWorkerNa1"].ToString(),
                CenterNotes = reader["RatCenterNotes1"].ToString(),
                TestDate = Convert.ToDateTime(reader["RatDate1"]),
                TestPrice = Convert.ToDouble(reader["Voucher1"]),
                PayLater = Convert.ToBoolean(reader["RatPayLatter1"]),
                CreatedByUserID = reader["CreatedByUserID"] != DBNull.Value
                   ? (int?)reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                   : null,
                ModifiedByUserID = reader["ModifiedByUserID"] != DBNull.Value
                   ? (int?)reader.GetInt32(reader.GetOrdinal("ModifiedByUserID"))
                   : null

            };
        }

        private static clsSharedclsCarRating _MapToCarRating(SqlDataReader reader)
        {
            return new clsSharedclsCarRating
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                CarPlateNumber = reader["PlateNumber"].ToString(),
                CarShassiNumber = reader["ShasiNumber"].ToString(),
                CarMakeModel = reader["RatCrTyp1"].ToString(),
                CarMinufacuringYear = reader["RatYear1"].ToString(),
                CarColor = reader["RatColor1"].ToString(),
                CarEnginCapacity = reader["RatEnginQ1"].ToString(),
                CustumerName = reader["RatBuyer1"].ToString(),
                FRShassi = reader["RatShasiFR1"].ToString(),
                FLShassi = reader["RatShasiFL1"].ToString(),
                BRShassi = reader["RatShasiBR1"].ToString(),
                BLShassi = reader["RatShasiBL1"].ToString(),
                EnginTest = reader["RatEngin1"].ToString(),
                EnginTestPerc = reader["RatEnginPers1"].ToString(),
                GearTest = reader["RatGear1"].ToString(),
                BakaksTest = reader["RatBakaks1"].ToString(),
                BodyTest = reader["RatNote1"].ToString(),
                WorkerNotes = reader["RatWorkerNa1"].ToString(),
                CenterNotes = reader["RatCenterNotes1"].ToString(),
                TestDate = Convert.ToDateTime(reader["RatDate1"]),
                TestPrice = reader["Voucher1"] != DBNull.Value ? Convert.ToDouble(reader["Voucher1"]) : 0,
                PayLater = reader["RatPayLatter1"] != DBNull.Value && Convert.ToBoolean(reader["RatPayLatter1"]),
                RegstrationNumber = reader["RatRegNo1"].ToString(),
                Bank = reader["RatMr1"].ToString(),
                UseType = reader["RatUsTyp1"].ToString(),
                InsuranceType = reader["RatInsuranceType1"].ToString(),
                EnginNumber = reader["RatEnginNo1"].ToString(),
                CarOwner = reader["RatCarOwner1"].ToString(),
                CarCapacity = reader["RatCarCapacity1"].ToString(),
                CarCountry = reader["CarCountry1"].ToString(),
                CarStatus = reader["RatGenStatus1"].ToString(),
                BodyValue = reader["RatBodyRat1"] != DBNull.Value ? Convert.ToDouble(reader["RatBodyRat1"]) : 0,
                StampValue = reader["RatStampRat1"] != DBNull.Value ? Convert.ToDouble(reader["RatStampRat1"]) : 0,
                TotalValue = reader["RatTotal1"] != DBNull.Value ? Convert.ToDouble(reader["RatTotal1"]) : 0,
                TotalValueAsString = reader["RatTotalChar1"].ToString(),
                ChkItem1 = reader["ChkItem1"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem1"]),
                ChkItem2 = reader["ChkItem2"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem2"]),
                ChkItem3 = reader["ChkItem3"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem3"]),
                ChkItem4 = reader["ChkItem4"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem4"]),
                ChkItem5 = reader["ChkItem5"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem5"]),
                ChkItem6 = reader["ChkItem6"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem6"]),
                ChkItem7 = reader["ChkItem7"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem7"]),
                ChkItem8 = reader["ChkItem8"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem8"]),
                ChkItem9 = reader["ChkItem9"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem9"]),
                ChkItem10 = reader["RatChkIsGood1"] != DBNull.Value && Convert.ToBoolean(reader["RatChkIsGood1"]),
                ChkItem11 = reader["RatChkToBeSale1"] != DBNull.Value && Convert.ToBoolean(reader["RatChkToBeSale1"]),
                Other = reader["RatOther1"].ToString(),
                CreatedByUserID = reader["CreatedByUserID"] != DBNull.Value
                   ? (int?)reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                   : null,
                ModifiedByUserID = reader["ModifiedByUserID"] != DBNull.Value
                   ? (int?)reader.GetInt32(reader.GetOrdinal("ModifiedByUserID"))
                   : null
            };
        }



        public static void AddAuditLog(clsSharedAuditLog log)
        {
            string query = @"INSERT INTO AuditLog 
    (TableName, RecordID, FieldName, OldValue, 
     NewValue, ActionType, ChangedByUserID, ChangedDate, EntryType)
    VALUES 
    (@TableName, @RecordID, @FieldName, @OldValue,
     @NewValue, @ActionType, @ChangedByUserID, @ChangedDate, @EntryType)";

            SqlParameter[] p = {
        new SqlParameter("@TableName",       log.TableName),
        new SqlParameter("@RecordID",        log.RecordID),
        new SqlParameter("@FieldName",       log.FieldName),
        new SqlParameter("@OldValue",        (object)log.OldValue       ?? DBNull.Value),
        new SqlParameter("@NewValue",        (object)log.NewValue       ?? DBNull.Value),
        new SqlParameter("@ActionType",      log.ActionType),
        new SqlParameter("@ChangedByUserID", log.ChangedByUserID),
        new SqlParameter("@ChangedDate",     log.ChangedDate),
        new SqlParameter("@EntryType", (object)log.EntryType ?? DBNull.Value)
    };

            _ExecuteNonQuery(query, "AddAuditLog", p);
        }

        public static DataTable GetTodayAuditLogs()
        {
            string query = @"SELECT 
                                al.RecordID,
                                al.EntryType,
                                al.FieldName,
                                al.OldValue,
                                al.NewValue,
                                al.ActionType,
                                u.UserName,
                                al.ChangedDate
                            FROM AuditLog al
                            LEFT JOIN Users u ON al.ChangedByUserID = u.UserID
                            where CAST(al.ChangedDate AS DATE) = CAST(GETDATE() AS DATE)
                            ORDER BY al.LogID DESC ;";

            return _ExecuteDataTable(query, "GetTodayAuditLogs");
        }

        public static DataTable GetAuditLogBetweenTwoDates(DateTime FromDate, DateTime ToDate)
        {
            string query = @"SELECT 
                        al.RecordID,
                        al.EntryType,
                        al.FieldName,
                        al.OldValue,
                        al.NewValue,
                        al.ActionType,
                        u.UserName,
                        al.ChangedDate
                    FROM AuditLog al
                    LEFT JOIN Users u ON al.ChangedByUserID = u.UserID
                    WHERE al.ChangedDate >= @FromDate 
                      AND al.ChangedDate < DATEADD(DAY, 1, @ToDate)
                    ORDER BY al.LogID DESC";

            SqlParameter[] p = {
        new SqlParameter("@FromDate", FromDate.Date),
        new SqlParameter("@ToDate",   ToDate.Date)
             };

            return _ExecuteDataTable(query, "GetAuditLogBetweenTwoDates", p);
        }

        public static DataTable GetAllAuditingLogByDate(DateTime Date)
        {
            string query = @"SELECT 
                        al.RecordID,
                        al.EntryType,
                        al.FieldName,
                        al.OldValue,
                        al.NewValue,
                        al.ActionType,
                        u.UserName,
                        al.ChangedDate
                    FROM AuditLog al
                    LEFT JOIN Users u ON al.ChangedByUserID = u.UserID
                    WHERE CAST(al.ChangedDate AS DATE) = CAST(@Date AS DATE)
                    ORDER BY al.LogID DESC";

            SqlParameter[] p = {
        new SqlParameter("@Date", Date.Date)
            };

            return _ExecuteDataTable(query, "GetAuditingLogByDate", p);
        }

        public static DataTable GetAllUsersForFilter()
        {
            string query = @"
        SELECT -1 AS UserID, 'الكل' AS UserName
        UNION ALL
        SELECT UserID, UserName FROM Users
        ORDER BY UserID";

            return _ExecuteDataTable(query, "GetAllUsersForFilter");
        }

        public static void CreateBackup(string backupFilePath)
        {
            string query = $@"
        BACKUP DATABASE DBCar_Rating_Testing01
        TO DISK = '{backupFilePath}'
        WITH INIT;";

            using (SqlConnection con = new SqlConnection(
                clsDataAccessLayerSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static clsSharedclsUsers GetUserInfoByUserNameAndPassword(string UserName, string Password)
        {
            string Query = @"select * from Users
                     where UserName  = @UserName 
                     and   Password  = @Password
                     and   IsActive  = 1";

            SqlParameter[] p = {
        new SqlParameter("@UserName", UserName),
        new SqlParameter("@Password", Password)
    };

            return _GetSingleItem(Query, "GetUserInfoByUserNameAndPassword", p,
                reader => new clsSharedclsUsers
                {
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    IsAdmin = reader["IsAdmin"] != DBNull.Value && Convert.ToBoolean(reader["IsAdmin"]),
                    IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"])
                });
        }

        public static DataTable GetAllUsers()
        {
            string query = @"SELECT UserID, UserName, IsAdmin, IsActive
                     FROM Users
                     ORDER BY UserID";

            return _ExecuteDataTable(query, "GetAllUsers");
        }

        public static int AddNewUser(clsSharedclsUsers dto)
        {
            string query = @"INSERT INTO Users (UserName, Password, IsAdmin, IsActive)
                     VALUES (@UserName, @Password, @IsAdmin, 1);
                     SELECT SCOPE_IDENTITY();";

            SqlParameter[] p = {
        new SqlParameter("@UserName", dto.UserName),
        new SqlParameter("@Password", dto.Password),
        new SqlParameter("@IsAdmin",  dto.IsAdmin)
    };

            return _ExecuteScalar(query, "AddNewUser", p);
        }

        public static bool UpdateUser(clsSharedclsUsers dto)
        {
            string query = @"UPDATE Users
                     SET UserName = @UserName,
                         IsAdmin  = @IsAdmin
                     WHERE UserID = @UserID";

            SqlParameter[] p = {
        new SqlParameter("@UserID",   dto.UserID),
        new SqlParameter("@UserName", dto.UserName),
        new SqlParameter("@IsAdmin",  dto.IsAdmin)
    };

            return _ExecuteNonQuery(query, "UpdateUser", p);
        }

        public static bool ChangePassword(int userID, string newPassword)
        {
            string query = @"UPDATE Users
                     SET Password = @Password
                     WHERE UserID = @UserID";

            SqlParameter[] p = {
        new SqlParameter("@UserID",   userID),
        new SqlParameter("@Password", newPassword)
    };

            return _ExecuteNonQuery(query, "ChangePassword", p);
        }

        public static bool SetUserActiveStatus(int userID, bool isActive)
        {
            string query = @"UPDATE Users
                     SET IsActive = @IsActive
                     WHERE UserID = @UserID";

            SqlParameter[] p = {
        new SqlParameter("@UserID",   userID),
        new SqlParameter("@IsActive", isActive)
    };

            return _ExecuteNonQuery(query, "SetUserActiveStatus", p);
        }

        public static bool SetAdminStatus(int userID, bool isAdmin)
        {
            string query = @"UPDATE Users
                     SET IsAdmin = @IsAdmin
                     WHERE UserID = @UserID";

            SqlParameter[] p = {
        new SqlParameter("@UserID",  userID),
        new SqlParameter("@IsAdmin", isAdmin)
    };

            return _ExecuteNonQuery(query, "SetAdminStatus", p);
        }

        public static bool IsUserNameExist(string userName, int excludeUserID = -1)
        {
            string query = @"SELECT COUNT(*) FROM Users
                     WHERE UserName = @UserName
                     AND   UserID  != @ExcludeID";

            SqlParameter[] p = {
        new SqlParameter("@UserName",  userName),
        new SqlParameter("@ExcludeID", excludeUserID)
    };

            int count = 0;
            using (SqlConnection connection = new SqlConnection(
                       clsDataAccessLayerSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddRange(p);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null) count = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    clsLogger.LogError(ex, "DAL -> IsUserNameExist");
                    throw;
                }
            }
            return count > 0;
        }


        public static DataTable GetAllTests()
        {
            string Query = @"SELECT 
                    ID, 
                    EntryType1, 
                    RatCrTyp1, 
                    PlateNumber, 
                    Shasinumber, 
                    RatPayLatter1, 
                    RatDate1, 
                    RatBuyer1, 
                    RatWorkerNa1 
                 FROM Car_Rating_Testing01
                 order by ID;";
            return _ExecuteDataTable(Query, "GetAllTests");
        }

        public static DataTable GetTestByPlateNumber(string PlateNumber)
        {
            string Query = @"SELECT 
                    ID, 
                    EntryType1, 
                    RatCrTyp1, 
                    PlateNumber, 
                    Shasinumber, 
                    RatPayLatter1, 
                    RatDate1, 
                    RatBuyer1, 
                    RatWorkerNa1 
                 FROM Car_Rating_Testing01
                 WHERE PlateNumber = @PlateNumber
                 order by ID;";
            SqlParameter[] p = { new SqlParameter("@PlateNumber", PlateNumber) };
            return _ExecuteDataTable(Query, "GetTestByPlateNumber", p);
        }

        public static DataTable GetIssuesMinus()
        {
            string Query = @"select * From Minus;";
            return _ExecuteDataTable(Query, "GetIssuesMinus");
        }

        public static DataTable GetExpenseCategories()
        {
            string Query = @"select * from ExpenseCategories;";
            return _ExecuteDataTable(Query, "GetAllExpenses");
        }

        public static DataTable GetAllExpenses()
        {
            string Query = @"SELECT 
            DailyExpenses.ExpenseID, 
            DailyExpenses.Description , 
            ExpenseCategories.CategoryName , 
            DailyExpenses.Amount , 
            DailyExpenses.ExpenseDate,
            DailyExpenses.CreatedBy
            FROM DailyExpenses
            INNER JOIN ExpenseCategories ON DailyExpenses.CategoryID = ExpenseCategories.CategoryID
            ORDER BY DailyExpenses.ExpenseDate DESC;";
            return _ExecuteDataTable(Query, "GetAllExpenses");
        }

        public static DataTable GetAllExpensesBettwenTowDates(DateTime from, DateTime to)
        {
            string query = @"
                          SELECT 
                          de.ExpenseID,
                          de.Description,
                          ec.CategoryName,
                          de.Amount,
                          de.ExpenseDate,
                          de.CreatedBy
                          FROM DailyExpenses de
                          INNER JOIN ExpenseCategories ec ON de.CategoryID = ec.CategoryID
                          WHERE de.ExpenseDate >= @From
                           AND de.ExpenseDate <  DATEADD(DAY, 1, @To)
                          ORDER BY de.ExpenseDate DESC;";
                
                            SqlParameter[] p =
                            {
                        new SqlParameter("@From", from.Date),
                        new SqlParameter("@To",   to.Date)
                            };

            return _ExecuteDataTable(query, "GetAllExpensesBetweenDates", p);
        }




        public static DataTable GetIssueByMinuID(int MinuID)
        {
            string Query = @"SELECT CarICode1, CarIssue1
                          FROM Car_Issue
                          WHERE MinuID = @MinuID;";
            SqlParameter[] p = { new SqlParameter("@MinuID", MinuID) };
            return _ExecuteDataTable(Query, "GetIssueByMinuID", p);

        }

        public static int AddNewCategory(string CategoryName)
        {
            int NewID = -1;

            // اتصال قاعدة البيانات
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            // الاستعلام: يضيف الاسم ثم يعيد الـ ID الذي تم إنشاؤه في نفس اللحظة
            string Query = @"INSERT INTO ExpenseCategories (CategoryName) 
                     VALUES (@CategoryName);
                     SELECT SCOPE_IDENTITY();";
            SqlParameter[] p = { new SqlParameter("@CategoryName", CategoryName) };
            return _ExecuteScalar(Query, "AddNewCategory", p);
        }

        public static int AddNewExpense(int CategoryID, decimal Amount, string Description, DateTime ExpenseDate, string CreatedByUserName)
        {
            string Query = @"INSERT INTO DailyExpenses (CategoryID, Amount, Description, ExpenseDate, CreatedBy)
                             VALUES (@CategoryID, @Amount, @Description, @ExpenseDate, @CreatedBy);
                             SELECT SCOPE_IDENTITY();";
            SqlParameter[] p = {
            new SqlParameter("@CategoryID", CategoryID),
            new SqlParameter("@Amount", Amount),
            new SqlParameter("@Description", Description),
            new SqlParameter("@ExpenseDate", ExpenseDate),
            new SqlParameter("@CreatedBy", CreatedByUserName)
           };
            return _ExecuteScalar(Query, "AddNewExpense", p);
        }

        public static bool UpdateExpense(int ExpenseID, int CategoryID, decimal Amount, string Description, DateTime ExpenseDate, string CreatedByUserName)
        {
            // استعلام التعديل لجدول المصاريف اليومية
            string Query = @"UPDATE DailyExpenses
                     SET CategoryID = @CategoryID,
                         Amount = @Amount,
                         Description = @Description,
                         ExpenseDate = @ExpenseDate,
                         CreatedBy = @CreatedBy
                     WHERE ExpenseID = @ExpenseID;";

            // تعريف الباراميترز بنفس نمط مشروعك
            SqlParameter[] p = {
             new SqlParameter("@ExpenseID", ExpenseID),
             new SqlParameter("@CategoryID", CategoryID),
             new SqlParameter("@Amount", Amount),
             new SqlParameter("@Description", (object)Description ?? DBNull.Value),
             new SqlParameter("@ExpenseDate", ExpenseDate),
            new SqlParameter("@CreatedBy", CreatedByUserName)
            };

            // استدعاء دالة التنفيذ الموحدة الموجودة في مشروعك
            return _ExecuteNonQuery(Query, "UpdateExpense", p);
        }

        public static bool DeleteExpense(int ExpenseID)
        {
            // استعلام الحذف بناءً على الرقم المعرف للمصروف
            string Query = @"DELETE FROM DailyExpenses
                     WHERE ExpenseID = @ExpenseID;";

            // تعريف الباراميترز بنفس نمط مشروعك المعتاد
            SqlParameter[] p = {
             new SqlParameter("@ExpenseID", ExpenseID)
             };

            // تنفيذ الاستعلام عبر الدالة المساعدة وتمرير اسم العملية للسجلات (Logs)
            return _ExecuteNonQuery(Query, "DeleteExpense", p);
        }

        public static int GetLastID()
        {
            int LastID = -1;
            
            using(SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.connectionString))
            {
                string query = @"select top 1 ID from Car_Rating_Testing01
                             order by ID desc;";
                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    conn.Open();
                    LastID = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            
            return LastID;
        }

        public static void GetCpuAndMatherBordIDs (ref string CpuID,ref string MatherBordID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.connectionString))
            {
                string query = @"SELECT  CPUID, MatherBordID
                                 FROM   ComputersAccessSittings;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            CpuID = reader["CPUID"].ToString();
                            MatherBordID = reader["MatherBordID"].ToString();
                        }
                    }
                }
            }
        }

        public static bool GetExpenseByID(int ExpenseID, ref int CategoryID, ref decimal Amount,
                                  ref string Description, ref DateTime ExpenseDate, ref string CreatedByUserName)
        {
            bool isFound = false;

            // استعلام لجلب بيانات مصروف واحد
            string Query = @"SELECT * FROM DailyExpenses WHERE ExpenseID = @ExpenseID;";

            SqlParameter[] p = {
             new SqlParameter("@ExpenseID", ExpenseID)
             };

            // استخدام DataTable لجلب الصف (يمكنك استخدام DataReader أيضاً حسب نمط مشروعك)
            // هنا سنفترض وجود دالة مساعدة ExecuteQuery تعيد DataTable
            DataTable dt = _ExecuteDataTable(Query, "GetExpenseByID", p);

            if (dt != null && dt.Rows.Count > 0)
            {
                isFound = true;
                DataRow row = dt.Rows[0];

                CategoryID = (int)row["CategoryID"];
                Amount = (decimal)row["Amount"];
                Description = row["Description"] != DBNull.Value ? (string)row["Description"] : "";
                ExpenseDate = (DateTime)row["ExpenseDate"];
                CreatedByUserName = row["CreatedBy"] != DBNull.Value ? (string)row["CreatedBy"] : "";
            }

            return isFound;
        }

        public static DataTable GetAllIssues()
        {
            string Query = @"select Car_Issue.CarICode1 CarICode , Car_Issue.CarIssue1 , Minus.MinuName
                             from Car_Issue join Minus on Car_Issue.MinuID = Minus.MinuID;";
            return _ExecuteDataTable(Query, "GetAllIssues");

        }

        public static int AddNewIssue(int MinuID, string Issue)
        {
            string Query = @"INSERT INTO Car_Issue (MinuID, CarIssue1)
                             VALUES (@MinuID, @CarIssue1); 
                             SELECT SCOPE_IDENTITY();";
            SqlParameter[] p = {
            new SqlParameter("@MinuID", MinuID),
            new SqlParameter("@CarIssue1", Issue)
           };
            return _ExecuteScalar(Query, "AddNewIssue", p);
        }

        public static bool UpdateIssue(int CarICodeID, string Issue)
        {
            string Query = @"UPDATE Car_Issue
                             SET CarIssue1 = @CarIssue1
                             WHERE CarICode1 = @CarICode1;";
            SqlParameter[] p = {
            new SqlParameter("@CarICode1", CarICodeID),
            new SqlParameter("@CarIssue1", Issue)
           };
            return _ExecuteNonQuery(Query, "UpdateIssue", p);
        }

        public static bool DeleteIssue(int CarICodeID)
        {
            string Query = @"DELETE FROM Car_Issue
                             WHERE CarICode1 = @CarICode1;";
            SqlParameter[] p = {
            new SqlParameter("@CarICode1", CarICodeID)
           };
            return _ExecuteNonQuery(Query, "DeleteIssue", p);
        }

        public static clsSharedclsCarTest GetTestByPlateNumberForCopy(string PlateNumber)
        {
            string query = @"select top 1 * from Car_Rating_Testing01
                                 where PlateNumber = @PlateNumber1  and EntryType1 like 'فحص%' order by RatDate1 desc";
            SqlParameter[] p = { new SqlParameter("@PlateNumber1", PlateNumber) };

            // نستخدم دالة التعبئة _MapToCarTest هنا لاختصار الكود
            return _GetSingleItem(query, "GetTestByPlateNumberForCopy", p, _MapToCarTest);
        }

        public static clsSharedclsCarTest GetTestByShasiNumberForCopy(string ShasiNumber)
        {
            string query = @"select top 1 * from Car_Rating_Testing01
                                 where ShasiNumber = @ShasiNumber1  and EntryType1 like 'فحص%' order by RatDate1 desc";
            SqlParameter[] p = { new SqlParameter("@ShasiNumber1", ShasiNumber) };

            return _GetSingleItem(query, "GetTestByShasiNumberForCopy", p, _MapToCarTest);
        }

        public static clsSharedclsCarTest GetCarTestDTOByID(int carID)
        {
            string query = @"SELECT * FROM Car_Rating_Testing01 WHERE ID = @ID";
            SqlParameter[] p = { new SqlParameter("@ID", carID) };

            // لاحظ في كودك الأصلي هنا كنت تنشئ كائناً فارغاً حتى لو لم تجد بيانات
            // ولكن مع دالة المساعد سيعود null إذا لم يجد بيانات.
            // لكي نلتزم تماماً بالكود القديم، سنتحقق من النتيجة:
            var result = _GetSingleItem(query, "GetCarTestDTOByID", p, _MapToCarTest);
            return result ?? new clsSharedclsCarTest();
        }

        public static clsSharedclsCarRating GetCarRatingDTOByID(int carID)
        {
            string query = @"SELECT *
             FROM Car_Rating_Testing01
             WHERE ID = @ID";
            SqlParameter[] p = { new SqlParameter("@ID", carID) };

            // نستخدم دالة تعبئة Rating هنا
            var result = _GetSingleItem(query, "GetCarRatingDTOByID", p, _MapToCarRating);
            return result ?? new clsSharedclsCarRating();
        }

        public static DataTable GetInfoByShasiNumber(string ShasiNumber)
        {
            string Query = @"SELECT 
                    ID, 
                    EntryType1, 
                    RatCrTyp1, 
                    PlateNumber, 
                    Shasinumber, 
                    RatPayLatter1, 
                    RatDate1, 
                    RatBuyer1, 
                    RatWorkerNa1 
                    FROM Car_Rating_Testing01
                    Where ShasiNumber = @ShasiNumber
                     order by ID";
            SqlParameter[] p = { new SqlParameter("@ShasiNumber", ShasiNumber) };
            return _ExecuteDataTable(Query, "GetInfoByShasiNumber", p);
        }

        public static DataTable GetInfoByCustumerName(string CustumerName)
        {
            // حافظنا على اسم الدالة GetInfoPyCustumerName (مع حرف P) في السطر التالي للوج
            string Query = @"select * from Car_Rating_Testing01 Where RatBuyer1 like @CustumerName order by ID";
            SqlParameter[] p = { new SqlParameter("@CustumerName", CustumerName + "%") };
            return _ExecuteDataTable(Query, "GetInfoPyCustumerName", p);
        }

        public static DataTable GetInfoByCustumerNameAndPayLaterForReports(string CustumerName, DateTime dtFrom, DateTime dtTo)
        {
            string Query = @"
                            select  EntryType1 , RatCrTyp1 , PlateNumber, ShasiNumber,
                            RatDate1, RatBuyer1, RatWorkerNa1, RatPayLatter1, Voucher1
                            from Car_Rating_Testing01
                            where RatPayLatter1 = 1
                            and RatBuyer1 LIKE @CustumerName + '%'
                            and RatDate1 between @dtFrom and @dtTo";
            SqlParameter[] p = {
            new SqlParameter("@CustumerName", CustumerName),
            new SqlParameter("@dtFrom", dtFrom),
            new SqlParameter("@dtTo", dtTo)
        };
            return _ExecuteDataTable(Query, "GetInfoByCustomerNameAndPayLatterForReports", p);
        }

        public static DataTable GetPayLatterTestsFromDateToDate(DateTime dtFrom, DateTime dtTo)
        {
            string Query = @"select ID ,  EntryType1 , RatCrTyp1 ,PlateNumber,ShasiNumber,
                          RatDate1,RatBuyer1,RatWorkerNa1,RatPayLatter1,Voucher1  from Car_Rating_Testing01 
                          where RatPayLatter1 = 1 and RatDate1 between @dtFrom and @dtTo
                          order by ID";
            SqlParameter[] p = {
            new SqlParameter("@dtFrom", dtFrom),
            new SqlParameter("@dtTo", dtTo)
        };
            return _ExecuteDataTable(Query, "GetPayLatterReportsFromDateToDate", p);
        }

        public static DataTable GetPayLatterReportsFromDateToDate(DateTime dtFrom, DateTime dtTo)
        {
            string Query = @"select  EntryType1 , RatCrTyp1 ,PlateNumber,ShasiNumber,
                          RatDate1,RatBuyer1,RatWorkerNa1,RatPayLatter1,Voucher1  from Car_Rating_Testing01 
                          where RatPayLatter1 = 1 and RatDate1 between @dtFrom and @dtTo";
            SqlParameter[] p = {
            new SqlParameter("@dtFrom", dtFrom),
            new SqlParameter("@dtTo", dtTo)
        };
            return _ExecuteDataTable(Query, "GetPayLatterReportsFromDateToDate", p);
        }

        public static DataTable GetInfoFromDateToDateForReports(DateTime dtFrom, DateTime dtTo)
        {
            string Query = @"select  EntryType1 , RatCrTyp1 ,PlateNumber,ShasiNumber,
                          RatDate1,RatBuyer1,RatWorkerNa1,RatPayLatter1,Voucher1  from Car_Rating_Testing01 
                          where RatDate1 between @dtFrom and @dtTo";
            SqlParameter[] p = {
            new SqlParameter("@dtFrom", dtFrom),
            new SqlParameter("@dtTo", dtTo)
        };
            return _ExecuteDataTable(Query, "GetInfoFromDateToDateForReport", p);
        }

        public static DataTable GetInfoFromDateToDate(DateTime FromDate, DateTime ToDate)
        {
            string Query = @"select * from Car_Rating_Testing01
                             where RatDate1 between @FromDate and @ToDate order by ID;";
            SqlParameter[] p = {
            new SqlParameter("@FromDate", FromDate),
            new SqlParameter("@ToDate", ToDate)
        };
            return _ExecuteDataTable(Query, "GetInfoFromDateToDate", p);
        }

        public static DataTable GetAllTestsAndTotalPriceByYear(int Year)
        {
            string Query = @"WITH RevenueCTE AS
                            (
                                SELECT 
                                    MONTH(RatDate1) AS [Month],
                            
                                    COUNT(*) AS TotalTests,
                            
                                    -- ✅ عدد الكاش / الذمم
                                    SUM(CASE WHEN RatPayLatter1 = 0 THEN 1 ELSE 0 END) AS CashTests,
                                    SUM(CASE WHEN RatPayLatter1 = 1 THEN 1 ELSE 0 END) AS DebtTests,
                            
                                    -- ✅ مجموع المبالغ للكاش / الذمم
                                    SUM(CASE WHEN RatPayLatter1 = 0 THEN Voucher1 ELSE 0 END) AS CashRevenue,
                                    SUM(CASE WHEN RatPayLatter1 = 1 THEN Voucher1 ELSE 0 END) AS DebtRevenue,
                            
                                    -- ✅ المجموع الكلي للإيرادات
                                    SUM(Voucher1) AS TotalRevenue
                            
                                FROM Car_Rating_Testing01
                                WHERE YEAR(RatDate1) = @Year
                                GROUP BY MONTH(RatDate1)
                            ),
                            ExpensesCTE AS
                            (
                                SELECT
                                    MONTH(ExpenseDate) AS [Month],
                                    SUM(Amount) AS TotalExpenses
                                FROM DailyExpenses
                                WHERE YEAR(ExpenseDate) = @Year
                                GROUP BY MONTH(ExpenseDate)
                            )
                            SELECT
                                COALESCE(r.[Month], e.[Month]) AS [Month],
                            
                                ISNULL(r.TotalTests, 0)     AS TotalTests,
                                ISNULL(r.CashTests, 0)      AS CashTests,
                                ISNULL(r.DebtTests, 0)      AS DebtTests,
                            
                                ISNULL(r.CashRevenue, 0)    AS CashRevenue,
                                ISNULL(r.DebtRevenue, 0)    AS DebtRevenue,
                                ISNULL(r.TotalRevenue, 0)   AS TotalRevenue,
                            
                                ISNULL(e.TotalExpenses, 0)  AS TotalExpenses,
                            
                                ISNULL(r.TotalRevenue, 0) - ISNULL(e.TotalExpenses, 0) AS NetProfit
                            
                            FROM RevenueCTE r
                            FULL OUTER JOIN ExpensesCTE e
                                ON r.[Month] = e.[Month]
                            ORDER BY [Month];";
            SqlParameter[] p = { new SqlParameter("@Year", Year) };
            return _ExecuteDataTable(Query, "GetTestsByYear", p);
        }

        public static int AddNewTest(clsSharedclsCarTest dto)
        {
            string Query = @"INSERT INTO Car_Rating_Testing01
                             (RatCrTyp1,ShasiNumber,RatYear1,RatEnginQ1,RatColor1,PlateNumber,
                              RatShasiFR1,RatShasiFL1,RatShasiBR1,RatShasiBL1,RatEngin1,RatEnginPers1,
                              RatGear1,RatBakaks1,RatNote1,RatWorkerNa1,RatCenterNotes1,
                              RatDate1,EntryType1,RatBuyer1,Voucher1,RatPayLatter1,CreatedByUserID)
                             VALUES
                             (@RatCrTyp1,@ShasiNumber,@RatYear1,@RatEnginQ1,@RatColor1,@PlateNumber,
                              @RatShasiFR1,@RatShasiFL1,@RatShasiBR1,@RatShasiBL1,@RatEngin1,@RatEnginPers1,
                              @RatGear1,@RatBakaks1,@RatNote1,@RatWorkerNa1,@RatCenterNotes1,
                              @RatDate1,@EntryType1,@RatBuyer1,@Voucher1,@RatPayLatter1,@CreatedByUserID);
                              SELECT SCOPE_IDENTITY();";

            SqlParameter[] p = {
            new SqlParameter("@RatCrTyp1", dto.CarMakeModel),
            new SqlParameter("@ShasiNumber", dto.CarShassiNumber),
            new SqlParameter("@RatYear1", dto.CarMinufacuringYear),
            new SqlParameter("@RatEnginQ1", dto.CarEnginCapacity),
            new SqlParameter("@RatColor1", dto.CarColor),
            new SqlParameter("@PlateNumber", dto.CarPlateNumber),
            new SqlParameter("@RatShasiFR1", dto.FRShassi),
            new SqlParameter("@RatShasiFL1", dto.FLShassi),
            new SqlParameter("@RatShasiBR1", dto.BRShassi),
            new SqlParameter("@RatShasiBL1", dto.BLShassi),
            new SqlParameter("@RatEngin1", dto.EnginTest),
            new SqlParameter("@RatEnginPers1", dto.EnginTestPerc),
            new SqlParameter("@RatGear1", dto.GearTest),
            new SqlParameter("@RatBakaks1", dto.BakaksTest),
            new SqlParameter("@RatNote1", dto.BodyTest),
            new SqlParameter("@RatWorkerNa1", dto.WorkerNotes),
            new SqlParameter("@RatCenterNotes1", dto.CenterNotes),
            new SqlParameter("@RatDate1", dto.TestDate),
            new SqlParameter("@EntryType1", "فحص مركبة"),
            new SqlParameter("@RatBuyer1", dto.CustumerName),
            new SqlParameter("@Voucher1", dto.TestPrice),
            new SqlParameter("@RatPayLatter1", dto.PayLater),
            new SqlParameter("@CreatedByUserID", (object)dto.CreatedByUserID ?? DBNull.Value)
        };

            return _ExecuteScalar(Query, "AddNewTest", p);
        }

        public static bool UpdateTest(clsSharedclsCarTest dto)
        {
            string Query = @"UPDATE Car_Rating_Testing01
                             SET RatCrTyp1 = @RatCrTyp1,
                             ShasiNumber = @ShasiNumber,
                             RatYear1 = @RatYear1,
                             RatEnginQ1 = @RatEnginQ1,
                             RatColor1 = @RatColor1,
                             PlateNumber = @PlateNumber,
                             RatShasiFR1 = @RatShasiFR1,
                             RatShasiFL1 = @RatShasiFL1,
                             RatShasiBR1 = @RatShasiBR1,
                             RatShasiBL1 = @RatShasiBL1,
                             RatEngin1 = @RatEngin1,
                             RatEnginPers1 = @RatEnginPers1,
                             RatGear1 = @RatGear1,
                             RatBakaks1 = @RatBakaks1,
                             RatNote1 = @RatNote1,
                             RatWorkerNa1 = @RatWorkerNa1,
                             RatBuyer1 = @RatBuyer1,
                             Voucher1 = @Voucher1,
                             RatCenterNotes1 = @RatCenterNotes1,
                             RatPayLatter1 = @RatPayLatter1,
                             ModifiedByUserID = @ModifiedByUserID
                             WHERE ID = @ID";

            SqlParameter[] p = {
            new SqlParameter("@ID", dto.ID),
            new SqlParameter("@RatCrTyp1", dto.CarMakeModel),
            new SqlParameter("@ShasiNumber", dto.CarShassiNumber),
            new SqlParameter("@RatYear1", dto.CarMinufacuringYear),
            new SqlParameter("@RatEnginQ1", dto.CarEnginCapacity),
            new SqlParameter("@RatColor1", dto.CarColor),
            new SqlParameter("@PlateNumber", dto.CarPlateNumber),
            new SqlParameter("@RatShasiFR1", dto.FRShassi),
            new SqlParameter("@RatShasiFL1", dto.FLShassi),
            new SqlParameter("@RatShasiBR1", dto.BRShassi),
            new SqlParameter("@RatShasiBL1", dto.BLShassi),
            new SqlParameter("@RatEngin1", dto.EnginTest),
            new SqlParameter("@RatEnginPers1", dto.EnginTestPerc),
            new SqlParameter("@RatGear1", dto.GearTest),
            new SqlParameter("@RatBakaks1", dto.BakaksTest),
            new SqlParameter("@RatNote1", dto.BodyTest),
            new SqlParameter("@RatWorkerNa1", dto.WorkerNotes),
            new SqlParameter("@RatCenterNotes1", dto.CenterNotes),
            new SqlParameter("@RatBuyer1", dto.CustumerName),
            new SqlParameter("@Voucher1", dto.TestPrice),
            new SqlParameter("@RatPayLatter1", dto.PayLater),
            new SqlParameter("@ModifiedByUserID", (object)dto.ModifiedByUserID ?? DBNull.Value)
        };

            return _ExecuteNonQuery(Query, "UpdateTest", p);
        }

        public static DataTable GetAllTestByDate(DateTime date)
        {
            string Query = @"select * from Car_Rating_Testing01
                                         where RatDate1 = @Date order by ID";
            SqlParameter[] p = { new SqlParameter("@Date", date) };
            return _ExecuteDataTable(Query, "GetAllTestByDate", p);
        }

        public static DataTable GetAllTodayTest()
        {
            string Query = @"select * from Car_Rating_Testing01
                                         where RatDate1 = Format(GETDATE(),'yyyy-MM-dd')
                                          order by ID;";
            return _ExecuteDataTable(Query, "GetAllTodayTests");
        }

        public static int AddNewRating(clsSharedclsCarRating dto)
        {
            string Query = @"INSERT INTO Car_Rating_Testing01 
        (RatCrTyp1, ShasiNumber, RatYear1, RatEnginQ1, RatColor1, PlateNumber, RatShasiFR1, RatShasiFL1, RatShasiBR1, RatShasiBL1, 
         RatEngin1, RatEnginPers1, RatGear1, RatBakaks1, RatNote1, RatWorkerNa1, RatCenterNotes1, RatDate1, EntryType1, RatBuyer1, 
         Voucher1, RatPayLatter1, 
         RatRegNo1, RatMr1, RatUsTyp1, RatInsuranceType1, RatEnginNo1, RatCarOwner1, RatCarCapacity1, CarCountry1, RatGenStatus1, 
         RatBodyRat1, RatStampRat1, RatTotal1, RatTotalChar1, RatOther1,
         ChkItem1, ChkItem2, ChkItem3, ChkItem4, ChkItem5, ChkItem6, ChkItem7, ChkItem8, ChkItem9, RatChkIsGood1, RatChkToBeSale1,CreatedByUserID)
        VALUES 
        (@RatCrTyp1, @ShasiNumber, @RatYear1, @RatEnginQ1, @RatColor1, @PlateNumber, @RatShasiFR1, @RatShasiFL1, @RatShasiBR1, @RatShasiBL1, 
         @RatEngin1, @RatEnginPers1, @RatGear1, @RatBakaks1, @RatNote1, @RatWorkerNa1, @RatCenterNotes1, @RatDate1, @EntryType1, @RatBuyer1, 
         @Voucher1, @RatPayLatter1, 
         @RegNum, @Bank, @UseType, @InsType, @EngNum, @Owner, @Cap, @Country, @Status, 
         @BValue, @SValue, @TValue, @TValueStr, @Other,
         @C1, @C2, @C3, @C4, @C5, @C6, @C7, @C8, @C9, @C10, @C11,@CreatedByUserID);
        SELECT SCOPE_IDENTITY();";

            SqlParameter[] p = {
            new SqlParameter("@RatCrTyp1", dto.CarMakeModel),
            new SqlParameter("@ShasiNumber", dto.CarShassiNumber),
            new SqlParameter("@RatYear1", dto.CarMinufacuringYear),
            new SqlParameter("@RatEnginQ1", dto.CarEnginCapacity),
            new SqlParameter("@RatColor1", dto.CarColor),
            new SqlParameter("@PlateNumber", dto.CarPlateNumber),
            new SqlParameter("@RatShasiFR1", dto.FRShassi),
            new SqlParameter("@RatShasiFL1", dto.FLShassi),
            new SqlParameter("@RatShasiBR1", dto.BRShassi),
            new SqlParameter("@RatShasiBL1", dto.BLShassi),
            new SqlParameter("@RatEngin1", dto.EnginTest),
            new SqlParameter("@RatEnginPers1", dto.EnginTestPerc),
            new SqlParameter("@RatGear1", dto.GearTest),
            new SqlParameter("@RatBakaks1", dto.BakaksTest),
            new SqlParameter("@RatNote1", dto.BodyTest),
            new SqlParameter("@RatWorkerNa1", dto.WorkerNotes),
            new SqlParameter("@RatCenterNotes1", dto.CenterNotes),
            new SqlParameter("@RatDate1", DateTime.Today),
            new SqlParameter("@EntryType1", "تقدير مركبة"),
            new SqlParameter("@RatBuyer1", dto.CustumerName),
            new SqlParameter("@Voucher1", dto.TestPrice),
            new SqlParameter("@RatPayLatter1", dto.PayLater),
            new SqlParameter("@RegNum", dto.RegstrationNumber),
            new SqlParameter("@Bank", dto.Bank),
            new SqlParameter("@UseType", dto.UseType),
            new SqlParameter("@InsType", dto.InsuranceType),
            new SqlParameter("@EngNum", dto.EnginNumber),
            new SqlParameter("@Owner", dto.CarOwner),
            new SqlParameter("@Cap", dto.CarCapacity),
            new SqlParameter("@Country", dto.CarCountry),
            new SqlParameter("@Status", dto.CarStatus),
            new SqlParameter("@BValue", dto.BodyValue),
            new SqlParameter("@SValue", dto.StampValue),
            new SqlParameter("@TValue", dto.TotalValue),
            new SqlParameter("@TValueStr", dto.TotalValueAsString),
            new SqlParameter("@Other", dto.Other),
            new SqlParameter("@C1", dto.ChkItem1),
            new SqlParameter("@C2", dto.ChkItem2),
            new SqlParameter("@C3", dto.ChkItem3),
            new SqlParameter("@C4", dto.ChkItem4),
            new SqlParameter("@C5", dto.ChkItem5),
            new SqlParameter("@C6", dto.ChkItem6),
            new SqlParameter("@C7", dto.ChkItem7),
            new SqlParameter("@C8", dto.ChkItem8),
            new SqlParameter("@C9", dto.ChkItem9),
            new SqlParameter("@C10", dto.ChkItem10),
            new SqlParameter("@C11", dto.ChkItem11),
            new SqlParameter("@CreatedByUserID", (object)dto.CreatedByUserID ?? DBNull.Value)
        };

            return _ExecuteScalar(Query, "AddNewRating", p);
        }

        public static bool UpdateRating(clsSharedclsCarRating dto)
        {
            string Query = @"UPDATE Car_Rating_Testing01 
            SET 
            RatCrTyp1 = @RatCrTyp1, ShasiNumber = @ShasiNumber, RatYear1 = @RatYear1, RatEnginQ1 = @RatEnginQ1, 
            RatColor1 = @RatColor1, PlateNumber = @PlateNumber, RatShasiFR1 = @RatShasiFR1, RatShasiFL1 = @RatShasiFL1, 
            RatShasiBR1 = @RatShasiBR1, RatShasiBL1 = @RatShasiBL1, RatEngin1 = @RatEngin1, RatEnginPers1 = @RatEnginPers1, 
            RatGear1 = @RatGear1, RatBakaks1 = @RatBakaks1, RatNote1 = @RatNote1, RatWorkerNa1 = @RatWorkerNa1, 
            RatCenterNotes1 = @RatCenterNotes1, RatBuyer1 = @RatBuyer1, Voucher1 = @Voucher1, RatPayLatter1 = @RatPayLatter1,
            
            RatRegNo1 = @RegNum, RatMr1 = @Bank, RatUsTyp1 = @UseType, RatInsuranceType1 = @InsType, 
            RatEnginNo1 = @EngNum, RatCarOwner1 = @Owner, RatCarCapacity1 = @Cap, CarCountry1 = @Country, 
            RatGenStatus1 = @Status, RatBodyRat1 = @BValue, RatStampRat1 = @SValue, RatTotal1 = @TValue, 
            RatTotalChar1 = @TValueStr, RatOther1 = @Other,
            
            ChkItem1 = @C1, ChkItem2 = @C2, ChkItem3 = @C3, ChkItem4 = @C4, ChkItem5 = @C5, 
            ChkItem6 = @C6, ChkItem7 = @C7, ChkItem8 = @C8, ChkItem9 = @C9, 
            RatChkIsGood1 = @C10, RatChkToBeSale1 = @C11,ModifiedByUserID = @ModifiedByUserID
            WHERE ID = @ID";

            SqlParameter[] p = {
            new SqlParameter("@ID", dto.ID),
            new SqlParameter("@RatCrTyp1", dto.CarMakeModel),
            new SqlParameter("@ShasiNumber", dto.CarShassiNumber),
            new SqlParameter("@RatYear1", dto.CarMinufacuringYear),
            new SqlParameter("@RatEnginQ1", dto.CarEnginCapacity),
            new SqlParameter("@RatColor1", dto.CarColor),
            new SqlParameter("@PlateNumber", dto.CarPlateNumber),
            new SqlParameter("@RatShasiFR1", dto.FRShassi),
            new SqlParameter("@RatShasiFL1", dto.FLShassi),
            new SqlParameter("@RatShasiBR1", dto.BRShassi),
            new SqlParameter("@RatShasiBL1", dto.BLShassi),
            new SqlParameter("@RatEngin1", dto.EnginTest),
            new SqlParameter("@RatEnginPers1", dto.EnginTestPerc),
            new SqlParameter("@RatGear1", dto.GearTest),
            new SqlParameter("@RatBakaks1", dto.BakaksTest),
            new SqlParameter("@RatNote1", dto.BodyTest),
            new SqlParameter("@RatWorkerNa1", dto.WorkerNotes),
            new SqlParameter("@RatCenterNotes1", dto.CenterNotes),
            new SqlParameter("@RatDate1", dto.TestDate),
            new SqlParameter("@RatBuyer1", dto.CustumerName),
            new SqlParameter("@Voucher1", dto.TestPrice),
            new SqlParameter("@RatPayLatter1", dto.PayLater),
            new SqlParameter("@RegNum", dto.RegstrationNumber),
            new SqlParameter("@Bank", dto.Bank),
            new SqlParameter("@UseType", dto.UseType),
            new SqlParameter("@InsType", dto.InsuranceType),
            new SqlParameter("@EngNum", dto.EnginNumber),
            new SqlParameter("@Owner", dto.CarOwner),
            new SqlParameter("@Cap", dto.CarCapacity),
            new SqlParameter("@Country", dto.CarCountry),
            new SqlParameter("@Status", dto.CarStatus),
            new SqlParameter("@BValue", dto.BodyValue),
            new SqlParameter("@SValue", dto.StampValue),
            new SqlParameter("@TValue", dto.TotalValue),
            new SqlParameter("@TValueStr", dto.TotalValueAsString),
            new SqlParameter("@Other", dto.Other),
            new SqlParameter("@C1", dto.ChkItem1),
            new SqlParameter("@C2", dto.ChkItem2),
            new SqlParameter("@C3", dto.ChkItem3),
            new SqlParameter("@C4", dto.ChkItem4),
            new SqlParameter("@C5", dto.ChkItem5),
            new SqlParameter("@C6", dto.ChkItem6),
            new SqlParameter("@C7", dto.ChkItem7),
            new SqlParameter("@C8", dto.ChkItem8),
            new SqlParameter("@C9", dto.ChkItem9),
            new SqlParameter("@C10", dto.ChkItem10),
            new SqlParameter("@C11", dto.ChkItem11),
            new SqlParameter("@ModifiedByUserID", (object)dto.ModifiedByUserID ?? DBNull.Value)
        };

            return _ExecuteNonQuery(Query, "UpdateRating", p);
        }

    }
}
