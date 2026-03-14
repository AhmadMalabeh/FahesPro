using SharedObj;
using SharedLogging;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarTestDataAccessLayer
{
    public class clsEmployeeData
    {
        public static DataTable GetAllEmployees()
        {
            string query = @"SELECT EmployeeID, FullName, NationalID, 
                                    PhoneNumber, Salary, HireDate, 
                                    TerminationDate, IsActive
                             FROM Employees
                             ORDER BY EmployeeID DESC";

            return _ExecuteDataTable(query, "GetAllEmployees");
        }

        public static bool ReactivateEmployee(int employeeID)
        {
            string query = @"UPDATE Employees
                     SET IsActive        = 1,
                         TerminationDate = NULL
                     WHERE EmployeeID = @EmployeeID";

            SqlParameter[] p = {
        new SqlParameter("@EmployeeID", employeeID)
    };

            return _ExecuteNonQuery(query, "ReactivateEmployee", p);
        }

        public static DataTable GetActiveEmployees()
        {
            string query = @"SELECT EmployeeID, FullName, NationalID,
                                    PhoneNumber, Salary, HireDate
                             FROM Employees
                             WHERE IsActive = 1
                             ORDER BY EmployeeID DESC";

            return _ExecuteDataTable(query, "GetActiveEmployees");
        }

        public static clsSharedEmployee GetEmployeeByID(int employeeID)
        {
            string query = @"SELECT EmployeeID, FullName, NationalID,
                                    PhoneNumber, Salary, HireDate,
                                    TerminationDate, IsActive
                             FROM Employees
                             WHERE EmployeeID = @EmployeeID";

            SqlParameter[] p = {
                new SqlParameter("@EmployeeID", employeeID)
            };

            return _GetSingleEmployee(query, "GetEmployeeByID", p);
        }

        public static clsSharedEmployee GetEmployeeByNationalID(string nationalID)
        {
            string query = @"SELECT EmployeeID, FullName, NationalID,
                                    PhoneNumber, Salary, HireDate,
                                    TerminationDate, IsActive
                             FROM Employees
                             WHERE NationalID = @NationalID";

            SqlParameter[] p = {
                new SqlParameter("@NationalID", nationalID)
            };

            return _GetSingleEmployee(query, "GetEmployeeByNationalID", p);
        }

        public static int AddEmployee(clsSharedEmployee dto)
        {
            string query = @"INSERT INTO Employees 
                                (FullName, NationalID, PhoneNumber, 
                                 Salary, HireDate, IsActive)
                             VALUES 
                                (@FullName, @NationalID, @PhoneNumber,
                                 @Salary, @HireDate, 1);
                             SELECT SCOPE_IDENTITY();";

            SqlParameter[] p = {
                new SqlParameter("@FullName",    dto.FullName),
                new SqlParameter("@NationalID",  dto.NationalID),
                new SqlParameter("@PhoneNumber", (object)dto.PhoneNumber ?? DBNull.Value),
                new SqlParameter("@Salary",      dto.Salary),
                new SqlParameter("@HireDate",    dto.HireDate)
            };

            return _ExecuteScalar(query, "AddEmployee", p);
        }

        public static bool UpdateEmployee(clsSharedEmployee dto)
        {
            string query = @"UPDATE Employees
                             SET FullName    = @FullName,
                                 NationalID  = @NationalID,
                                 PhoneNumber = @PhoneNumber,
                                 Salary      = @Salary,
                                 HireDate    = @HireDate
                             WHERE EmployeeID = @EmployeeID";

            SqlParameter[] p = {
                new SqlParameter("@EmployeeID",  dto.EmployeeID),
                new SqlParameter("@FullName",    dto.FullName),
                new SqlParameter("@NationalID",  dto.NationalID),
                new SqlParameter("@PhoneNumber", (object)dto.PhoneNumber ?? DBNull.Value),
                new SqlParameter("@Salary",      dto.Salary),
                new SqlParameter("@HireDate",    dto.HireDate)
            };

            return _ExecuteNonQuery(query, "UpdateEmployee", p);
        }

        public static bool DeactivateEmployee(int employeeID, DateTime terminationDate)
        {
            string query = @"UPDATE Employees
                             SET IsActive        = 0,
                                 TerminationDate = @TerminationDate
                             WHERE EmployeeID = @EmployeeID";

            SqlParameter[] p = {
                new SqlParameter("@EmployeeID",      employeeID),
                new SqlParameter("@TerminationDate", terminationDate)
            };

            return _ExecuteNonQuery(query, "DeactivateEmployee", p);
        }

        public static bool IsNationalIDExist(string nationalID, int excludeEmployeeID = -1)
        {
            string query = @"SELECT COUNT(*) FROM Employees
                             WHERE NationalID = @NationalID
                             AND EmployeeID  != @ExcludeID";

            SqlParameter[] p = {
                new SqlParameter("@NationalID", nationalID),
                new SqlParameter("@ExcludeID",  excludeEmployeeID)
            };

            return _ExecuteCount(query, "IsNationalIDExist", p) > 0;
        }

        // ===== Helper Methods =====

        private static clsSharedEmployee _MapToEmployee(SqlDataReader reader)
        {
            return new clsSharedEmployee
            {
                EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                FullName = reader["FullName"].ToString(),
                NationalID = reader["NationalID"].ToString(),
                PhoneNumber = reader["PhoneNumber"] != DBNull.Value
                                  ? reader["PhoneNumber"].ToString() : null,
                Salary = reader["Salary"] != DBNull.Value
                                  ? Convert.ToDecimal(reader["Salary"]) : 0,
                HireDate = Convert.ToDateTime(reader["HireDate"]),
                TerminationDate = reader["TerminationDate"] != DBNull.Value
                                  ? (DateTime?)Convert.ToDateTime(reader["TerminationDate"]) : null,
                IsActive = Convert.ToBoolean(reader["IsActive"])
            };
        }

        private static clsSharedEmployee _GetSingleEmployee(string query,
                                                             string methodName,
                                                             SqlParameter[] parameters)
        {
            clsSharedEmployee dto = null;
            using (SqlConnection connection = new SqlConnection(
                       clsDataAccessLayerSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null) command.Parameters.AddRange(parameters);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            dto = _MapToEmployee(reader);
                    }
                }
                catch (Exception ex)
                {
                    clsLogger.LogError(ex, "DAL -> " + methodName);
                    throw;
                }
            }
            return dto;
        }

        private static DataTable _ExecuteDataTable(string query, string methodName,
                                                    SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(
                       clsDataAccessLayerSettings.connectionString))
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
            return dt;
        }

        private static int _ExecuteScalar(string query, string methodName,
                                           SqlParameter[] parameters)
        {
            int id = -1;
            using (SqlConnection connection = new SqlConnection(
                       clsDataAccessLayerSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null) command.Parameters.AddRange(parameters);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        id = insertedID;
                }
                catch (Exception ex)
                {
                    clsLogger.LogError(ex, "DAL -> " + methodName);
                    throw;
                }
            }
            return id;
        }

        private static bool _ExecuteNonQuery(string query, string methodName,
                                              SqlParameter[] parameters)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(
                       clsDataAccessLayerSettings.connectionString))
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
            return rowsAffected > 0;
        }

        private static int _ExecuteCount(string query, string methodName,
                                          SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(
                       clsDataAccessLayerSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null) command.Parameters.AddRange(parameters);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null) count = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    clsLogger.LogError(ex, "DAL -> " + methodName);
                    throw;
                }
            }
            return count;
        }
    }
}
