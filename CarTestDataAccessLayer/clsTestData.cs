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
namespace CarTestDataAccessLayer
{
    public class clsTestData
    {
        
        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);
            string Query = @"select * from Car_Rating_Testing01;";

            SqlCommand command = new SqlCommand(Query,connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }

            return dt;
        }

        public static DataTable GetTestByPlateNumber(string PlateNumber)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);
            string Query = @"select * from Car_Rating_Testing01
                                          where PlateNumber =  @PlateNumber";


            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@PlateNumber", PlateNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }

            return dt;
        }



        public static clsSharedclsCarTest GetCarTestDTOByID(int carID)
        {
            clsSharedclsCarTest dto = new clsSharedclsCarTest(); 

            using (SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString))
            {
                string query = @"SELECT * FROM Car_Rating_Testing01 WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", carID);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dto.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        dto.CarPlateNumber = reader["PlateNumber"].ToString();
                        dto.CarShassiNumber = reader["ShasiNumber"].ToString();
                        dto.CarMakeModel = reader["RatCrTyp1"].ToString();
                        dto.CarMinufacuringYear = reader["RatYear1"].ToString();
                        dto.CarColor = reader["RatColor1"].ToString();
                        dto.CarEnginCapacity = reader["RatEnginQ1"].ToString();

                        dto.CustumerName = reader["RatBuyer1"].ToString();
                        dto.FRShassi = reader["RatShasiFR1"].ToString();
                        dto.FLShassi = reader["RatShasiFL1"].ToString();
                        dto.BRShassi = reader["RatShasiBR1"].ToString();
                        dto.BLShassi = reader["RatShasiBL1"].ToString();

                        dto.EnginTest = reader["RatEngin1"].ToString();
                        dto.EnginTestPerc = reader["RatEnginPers1"].ToString();
                        dto.GearTest = reader["RatGear1"].ToString();
                        dto.BakaksTest = reader["RatBakaks1"].ToString();
                        dto.BodyTest = reader["RatNote1"].ToString();

                        dto.WorkerNotes = reader["RatWorkerNa1"].ToString();
                        dto.CenterNotes = reader["RatCenterNotes1"].ToString();
                        dto.TestDate = Convert.ToDateTime(reader["RatDate1"]);
                        dto.TestPrice = Convert.ToDouble(reader["Voucher1"]);
                        dto.PayLater = Convert.ToBoolean(reader["RatPayLatter1"]);
                    }
                }
            }

            return dto;
        }




        public static clsSharedclsCarRating GetCarRatingDTOByID(int carID)
        {
            clsSharedclsCarRating dto = new clsSharedclsCarRating();

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessLayerSettings.connectionString))
            {
                string query = @"SELECT *
                 FROM Car_Rating_Testing01
                 WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", carID);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {


                        dto.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                            dto.CarPlateNumber = reader["PlateNumber"].ToString();
                        dto.CarShassiNumber = reader["ShasiNumber"].ToString();
                        dto.CarMakeModel = reader["RatCrTyp1"].ToString();
                        dto.CarMinufacuringYear = reader["RatYear1"].ToString();
                        dto.CarColor = reader["RatColor1"].ToString();
                        dto.CarEnginCapacity = reader["RatEnginQ1"].ToString();

                        dto.CustumerName = reader["RatBuyer1"].ToString();
                        dto.FRShassi = reader["RatShasiFR1"].ToString();
                        dto.FLShassi = reader["RatShasiFL1"].ToString();
                        dto.BRShassi = reader["RatShasiBR1"].ToString();
                        dto.BLShassi = reader["RatShasiBL1"].ToString();

                        dto.EnginTest = reader["RatEngin1"].ToString();
                        dto.EnginTestPerc = reader["RatEnginPers1"].ToString();
                        dto.GearTest = reader["RatGear1"].ToString();
                        dto.BakaksTest = reader["RatBakaks1"].ToString();
                        dto.BodyTest = reader["RatNote1"].ToString();

                        dto.WorkerNotes = reader["RatWorkerNa1"].ToString();
                        dto.CenterNotes = reader["RatCenterNotes1"].ToString();
                        dto.TestDate = Convert.ToDateTime(reader["RatDate1"]);
                        dto.TestPrice = reader["Voucher1"] != DBNull.Value ? Convert.ToDouble(reader["Voucher1"]) : 0;
                        dto.PayLater = reader["RatPayLatter1"] != DBNull.Value && Convert.ToBoolean(reader["RatPayLatter1"]);


                        dto.RegstrationNumber = reader["RatRegNo1"].ToString();
                        dto.Bank = reader["RatMr1"].ToString();
                        dto.UseType = reader["RatUsTyp1"].ToString();
                        dto.InsuranceType = reader["RatInsuranceType1"].ToString();
                        dto.EnginNumber = reader["RatEnginNo1"].ToString();
                        dto.CarOwner = reader["RatCarOwner1"].ToString();
                        dto.CarCapacity = reader["RatCarCapacity1"].ToString();
                        dto.CarCountry = reader["CarCountry1"].ToString();
                        dto.CarStatus = reader["RatGenStatus1"].ToString();
                        dto.BodyValue = reader["RatBodyRat1"] != DBNull.Value ? Convert.ToDouble(reader["RatBodyRat1"]) : 0;
                        dto.StampValue = reader["RatStampRat1"] != DBNull.Value ? Convert.ToDouble(reader["RatStampRat1"]) : 0;
                        dto.TotalValue = reader["RatTotal1"] != DBNull.Value ? Convert.ToDouble(reader["RatTotal1"]) : 0;
                        dto.TotalValueAsString = reader["RatTotalChar1"].ToString();
                        dto.ChkItem1 = reader["ChkItem1"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem1"]);
                        dto.ChkItem2 = reader["ChkItem2"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem2"]);
                        dto.ChkItem3 = reader["ChkItem3"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem3"]);
                        dto.ChkItem4 = reader["ChkItem4"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem4"]);
                        dto.ChkItem5 = reader["ChkItem5"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem5"]);
                        dto.ChkItem6 = reader["ChkItem6"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem6"]);
                        dto.ChkItem7 = reader["ChkItem7"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem7"]);
                        dto.ChkItem8 = reader["ChkItem8"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem8"]);
                        dto.ChkItem9 = reader["ChkItem9"] != DBNull.Value && Convert.ToBoolean(reader["ChkItem9"]);
                        dto.ChkItem10 = reader["RatChkIsGood1"] != DBNull.Value && Convert.ToBoolean(reader["RatChkIsGood1"]);
                        dto.ChkItem11 = reader["RatChkToBeSale1"] != DBNull.Value && Convert.ToBoolean(reader["RatChkToBeSale1"]);
                        dto.Other = reader["RatOther1"].ToString();

                    }
                }
            }
            return dto;
        }



        public static DataTable GetInfoByShasiNumber(string ShasiNumber)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string Query = @"select * from Car_Rating_Testing01 Where ShasiNumber = @ShasiNumber";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ShasiNumber", ShasiNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {

                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }

            return dt;
        }

        public static DataTable GetInfoFromDateToDate(string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string Query = @"select * from Car_Rating_Testing01
                                 where RatDate1 between @FromDate and @ToDate;";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@FromDate",FromDate);
            Command.Parameters.AddWithValue("@ToDate", ToDate);

            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {

                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }

            return dt;
        }



        public static int AddNewTest(clsSharedclsCarTest dto)
        {
            int ID = -1;

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessLayerSettings.connectionString))
            {
                string Query = @"INSERT INTO Car_Rating_Testing01
        (RatCrTyp1,ShasiNumber,RatYear1,RatEnginQ1,RatColor1,PlateNumber,
         RatShasiFR1,RatShasiFL1,RatShasiBR1,RatShasiBL1,RatEngin1,RatEnginPers1,
         RatGear1,RatBakaks1,RatNote1,RatWorkerNa1,RatCenterNotes1,
         RatDate1,EntryType1,RatBuyer1,Voucher1,RatPayLatter1)
        VALUES
        (@RatCrTyp1,@ShasiNumber,@RatYear1,@RatEnginQ1,@RatColor1,@PlateNumber,
         @RatShasiFR1,@RatShasiFL1,@RatShasiBR1,@RatShasiBL1,@RatEngin1,@RatEnginPers1,
         @RatGear1,@RatBakaks1,@RatNote1,@RatWorkerNa1,@RatCenterNotes1,
         @RatDate1,@EntryType1,@RatBuyer1,@Voucher1,@RatPayLatter1);
         SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(Query, connection);

                command.Parameters.AddWithValue("@RatCrTyp1", dto.CarMakeModel);
                command.Parameters.AddWithValue("@ShasiNumber", dto.CarShassiNumber);
                command.Parameters.AddWithValue("@RatYear1", dto.CarMinufacuringYear);
                command.Parameters.AddWithValue("@RatEnginQ1", dto.CarEnginCapacity);
                command.Parameters.AddWithValue("@RatColor1", dto.CarColor);
                command.Parameters.AddWithValue("@PlateNumber", dto.CarPlateNumber);

                command.Parameters.AddWithValue("@RatShasiFR1", dto.FRShassi);
                command.Parameters.AddWithValue("@RatShasiFL1", dto.FLShassi);
                command.Parameters.AddWithValue("@RatShasiBR1", dto.BRShassi);
                command.Parameters.AddWithValue("@RatShasiBL1", dto.BLShassi);

                command.Parameters.AddWithValue("@RatEngin1", dto.EnginTest);
                command.Parameters.AddWithValue("@RatEnginPers1", dto.EnginTestPerc);
                command.Parameters.AddWithValue("@RatGear1", dto.GearTest);
                command.Parameters.AddWithValue("@RatBakaks1", dto.BakaksTest);
                command.Parameters.AddWithValue("@RatNote1", dto.BodyTest);

                command.Parameters.AddWithValue("@RatWorkerNa1", dto.WorkerNotes);
                command.Parameters.AddWithValue("@RatCenterNotes1", dto.CenterNotes);
                command.Parameters.AddWithValue("@RatDate1", dto.TestDate);
                command.Parameters.AddWithValue("@EntryType1", "فحص مركبة");
                command.Parameters.AddWithValue("@RatBuyer1", dto.CustumerName);
                command.Parameters.AddWithValue("@Voucher1", dto.TestPrice);
                command.Parameters.AddWithValue("@RatPayLatter1", dto.PayLater);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    ID = insertedID;
            }

            return ID;
        }


        public static bool UpdateTest(clsSharedclsCarTest dto)
        {
            int RowsAffected = 0;

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessLayerSettings.connectionString))
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
            RatPayLatter1 = @RatPayLatter1
            WHERE ID = @ID";

                SqlCommand command = new SqlCommand(Query, connection);

                command.Parameters.AddWithValue("@ID", dto.ID);
                command.Parameters.AddWithValue("@RatCrTyp1", dto.CarMakeModel);
                command.Parameters.AddWithValue("@ShasiNumber", dto.CarShassiNumber);
                command.Parameters.AddWithValue("@RatYear1", dto.CarMinufacuringYear);
                command.Parameters.AddWithValue("@RatEnginQ1", dto.CarEnginCapacity);
                command.Parameters.AddWithValue("@RatColor1", dto.CarColor);
                command.Parameters.AddWithValue("@PlateNumber", dto.CarPlateNumber);

                command.Parameters.AddWithValue("@RatShasiFR1", dto.FRShassi);
                command.Parameters.AddWithValue("@RatShasiFL1", dto.FLShassi);
                command.Parameters.AddWithValue("@RatShasiBR1", dto.BRShassi);
                command.Parameters.AddWithValue("@RatShasiBL1", dto.BLShassi);

                command.Parameters.AddWithValue("@RatEngin1", dto.EnginTest);
                command.Parameters.AddWithValue("@RatEnginPers1", dto.EnginTestPerc);
                command.Parameters.AddWithValue("@RatGear1", dto.GearTest);
                command.Parameters.AddWithValue("@RatBakaks1", dto.BakaksTest);
                command.Parameters.AddWithValue("@RatNote1", dto.BodyTest);

                command.Parameters.AddWithValue("@RatWorkerNa1", dto.WorkerNotes);
                command.Parameters.AddWithValue("@RatCenterNotes1", dto.CenterNotes);
                command.Parameters.AddWithValue("@RatBuyer1", dto.CustumerName);
                command.Parameters.AddWithValue("@Voucher1", dto.TestPrice);
                command.Parameters.AddWithValue("@RatPayLatter1", dto.PayLater);

                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }

            return RowsAffected > 0;
        }


        public static DataTable GetAllTodayTest()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string Query = @"select * from Car_Rating_Testing01
                                        where RatDate1 = Format(GETDATE(),'yyyy-MM-dd');";

            SqlCommand Command = new SqlCommand(Query, connection);
            

            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {

                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }

            return dt;
        }



        public static int AddNewRating(clsSharedclsCarRating dto)
        {
            int ID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString))
            {

                string Query = @"INSERT INTO Car_Rating_Testing01 
            (RatCrTyp1, ShasiNumber, RatYear1, RatEnginQ1, RatColor1, PlateNumber, RatShasiFR1, RatShasiFL1, RatShasiBR1, RatShasiBL1, 
             RatEngin1, RatEnginPers1, RatGear1, RatBakaks1, RatNote1, RatWorkerNa1, RatCenterNotes1, RatDate1, EntryType1, RatBuyer1, 
             Voucher1, RatPayLatter1, 
             RatRegNo1, RatMr1, RatUsTyp1, RatInsuranceType1, RatEnginNo1, RatCarOwner1, RatCarCapacity1, CarCountry1, RatGenStatus1, 
             RatBodyRat1, RatStampRat1, RatTotal1, RatTotalChar1, RatOther1,
             ChkItem1, ChkItem2, ChkItem3, ChkItem4, ChkItem5, ChkItem6, ChkItem7, ChkItem8, ChkItem9, RatChkIsGood1, RatChkToBeSale1)
            VALUES 
            (@RatCrTyp1, @ShasiNumber, @RatYear1, @RatEnginQ1, @RatColor1, @PlateNumber, @RatShasiFR1, @RatShasiFL1, @RatShasiBR1, @RatShasiBL1, 
             @RatEngin1, @RatEnginPers1, @RatGear1, @RatBakaks1, @RatNote1, @RatWorkerNa1, @RatCenterNotes1, @RatDate1, @EntryType1, @RatBuyer1, 
             @Voucher1, @RatPayLatter1, 
             @RegNum, @Bank, @UseType, @InsType, @EngNum, @Owner, @Cap, @Country, @Status, 
             @BValue, @SValue, @TValue, @TValueStr, @Other,
             @C1, @C2, @C3, @C4, @C5, @C6, @C7, @C8, @C9, @C10, @C11);
            SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(Query, connection);


                command.Parameters.AddWithValue("@RatCrTyp1", dto.CarMakeModel);
                command.Parameters.AddWithValue("@ShasiNumber", dto.CarShassiNumber);
                command.Parameters.AddWithValue("@RatYear1", dto.CarMinufacuringYear);
                command.Parameters.AddWithValue("@RatEnginQ1", dto.CarEnginCapacity);
                command.Parameters.AddWithValue("@RatColor1", dto.CarColor);
                command.Parameters.AddWithValue("@PlateNumber", dto.CarPlateNumber);
                command.Parameters.AddWithValue("@RatShasiFR1", dto.FRShassi);
                command.Parameters.AddWithValue("@RatShasiFL1", dto.FLShassi);
                command.Parameters.AddWithValue("@RatShasiBR1", dto.BRShassi);
                command.Parameters.AddWithValue("@RatShasiBL1", dto.BLShassi);
                command.Parameters.AddWithValue("@RatEngin1", dto.EnginTest);
                command.Parameters.AddWithValue("@RatEnginPers1", dto.EnginTestPerc);
                command.Parameters.AddWithValue("@RatGear1", dto.GearTest);
                command.Parameters.AddWithValue("@RatBakaks1", dto.BakaksTest);
                command.Parameters.AddWithValue("@RatNote1", dto.BodyTest);
                command.Parameters.AddWithValue("@RatWorkerNa1", dto.WorkerNotes);
                command.Parameters.AddWithValue("@RatCenterNotes1", dto.CenterNotes);
                command.Parameters.AddWithValue("@RatDate1", DateTime.Today);
                command.Parameters.AddWithValue("@EntryType1", "تقدير مركبة");
                command.Parameters.AddWithValue("@RatBuyer1", dto.CustumerName);
                command.Parameters.AddWithValue("@Voucher1", dto.TestPrice);
                command.Parameters.AddWithValue("@RatPayLatter1", dto.PayLater);


                command.Parameters.AddWithValue("@RegNum", dto.RegstrationNumber);
                command.Parameters.AddWithValue("@Bank", dto.Bank);
                command.Parameters.AddWithValue("@UseType", dto.UseType);
                command.Parameters.AddWithValue("@InsType", dto.InsuranceType);
                command.Parameters.AddWithValue("@EngNum", dto.EnginNumber);
                command.Parameters.AddWithValue("@Owner", dto.CarOwner);
                command.Parameters.AddWithValue("@Cap", dto.CarCapacity);
                command.Parameters.AddWithValue("@Country", dto.CarCountry);
                command.Parameters.AddWithValue("@Status", dto.CarStatus);
                command.Parameters.AddWithValue("@BValue", dto.BodyValue);
                command.Parameters.AddWithValue("@SValue", dto.StampValue);
                command.Parameters.AddWithValue("@TValue", dto.TotalValue);
                command.Parameters.AddWithValue("@TValueStr", dto.TotalValueAsString);
                command.Parameters.AddWithValue("@Other", dto.Other);

                // إسناد قيم الـ CheckBoxes (True/False)
                command.Parameters.AddWithValue("@C1", dto.ChkItem1);
                command.Parameters.AddWithValue("@C2", dto.ChkItem2);
                command.Parameters.AddWithValue("@C3", dto.ChkItem3);
                command.Parameters.AddWithValue("@C4", dto.ChkItem4);
                command.Parameters.AddWithValue("@C5", dto.ChkItem5);
                command.Parameters.AddWithValue("@C6", dto.ChkItem6);
                command.Parameters.AddWithValue("@C7", dto.ChkItem7);
                command.Parameters.AddWithValue("@C8", dto.ChkItem8);
                command.Parameters.AddWithValue("@C9", dto.ChkItem9);
                command.Parameters.AddWithValue("@C10", dto.ChkItem10);
                command.Parameters.AddWithValue("@C11", dto.ChkItem11);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        ID = InsertedID;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return ID;
        }


        public static bool UpdateRating(clsSharedclsCarRating dto)
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString))
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
                RatChkIsGood1 = @C10, RatChkToBeSale1 = @C11
                WHERE ID = @ID";

                SqlCommand command = new SqlCommand(Query, connection);

                command.Parameters.AddWithValue("@ID", dto.ID);

                command.Parameters.AddWithValue("@RatCrTyp1", dto.CarMakeModel);
                command.Parameters.AddWithValue("@ShasiNumber", dto.CarShassiNumber);
                command.Parameters.AddWithValue("@RatYear1", dto.CarMinufacuringYear);
                command.Parameters.AddWithValue("@RatEnginQ1", dto.CarEnginCapacity);
                command.Parameters.AddWithValue("@RatColor1", dto.CarColor);
                command.Parameters.AddWithValue("@PlateNumber", dto.CarPlateNumber);
                command.Parameters.AddWithValue("@RatShasiFR1", dto.FRShassi);
                command.Parameters.AddWithValue("@RatShasiFL1", dto.FLShassi);
                command.Parameters.AddWithValue("@RatShasiBR1", dto.BRShassi);
                command.Parameters.AddWithValue("@RatShasiBL1", dto.BLShassi);
                command.Parameters.AddWithValue("@RatEngin1", dto.EnginTest);
                command.Parameters.AddWithValue("@RatEnginPers1", dto.EnginTestPerc);
                command.Parameters.AddWithValue("@RatGear1", dto.GearTest);
                command.Parameters.AddWithValue("@RatBakaks1", dto.BakaksTest);
                command.Parameters.AddWithValue("@RatNote1", dto.BodyTest);
                command.Parameters.AddWithValue("@RatWorkerNa1", dto.WorkerNotes);
                command.Parameters.AddWithValue("@RatCenterNotes1", dto.CenterNotes);
                command.Parameters.AddWithValue("@RatDate1", DateTime.Today);
                command.Parameters.AddWithValue("@EntryType1", "تقدير مركبة");
                command.Parameters.AddWithValue("@RatBuyer1", dto.CustumerName);
                command.Parameters.AddWithValue("@Voucher1", dto.TestPrice);
                command.Parameters.AddWithValue("@RatPayLatter1", dto.PayLater);


                command.Parameters.AddWithValue("@RegNum", dto.RegstrationNumber);
                command.Parameters.AddWithValue("@Bank", dto.Bank);
                command.Parameters.AddWithValue("@UseType", dto.UseType);
                command.Parameters.AddWithValue("@InsType", dto.InsuranceType);
                command.Parameters.AddWithValue("@EngNum", dto.EnginNumber);
                command.Parameters.AddWithValue("@Owner", dto.CarOwner);
                command.Parameters.AddWithValue("@Cap", dto.CarCapacity);
                command.Parameters.AddWithValue("@Country", dto.CarCountry);
                command.Parameters.AddWithValue("@Status", dto.CarStatus);
                command.Parameters.AddWithValue("@BValue", dto.BodyValue);
                command.Parameters.AddWithValue("@SValue", dto.StampValue);
                command.Parameters.AddWithValue("@TValue", dto.TotalValue);
                command.Parameters.AddWithValue("@TValueStr", dto.TotalValueAsString);
                command.Parameters.AddWithValue("@Other", dto.Other);

                // إسناد قيم الـ CheckBoxes (True/False)
                command.Parameters.AddWithValue("@C1", dto.ChkItem1);
                command.Parameters.AddWithValue("@C2", dto.ChkItem2);
                command.Parameters.AddWithValue("@C3", dto.ChkItem3);
                command.Parameters.AddWithValue("@C4", dto.ChkItem4);
                command.Parameters.AddWithValue("@C5", dto.ChkItem5);
                command.Parameters.AddWithValue("@C6", dto.ChkItem6);
                command.Parameters.AddWithValue("@C7", dto.ChkItem7);
                command.Parameters.AddWithValue("@C8", dto.ChkItem8);
                command.Parameters.AddWithValue("@C9", dto.ChkItem9);
                command.Parameters.AddWithValue("@C10", dto.ChkItem10);
                command.Parameters.AddWithValue("@C11", dto.ChkItem11);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
            return (RowsAffected > 0);
        }
        

    }
}
