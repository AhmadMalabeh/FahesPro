using CarTestDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTestLogicalLayer
{
    public class clsAuditing
    {
        public static DataTable GetTodayAuditing()
        {
                return clsTestData.GetTodayAuditLogs();
        }

        public static DataTable GetAuditingBetweenTowDates(DateTime fromDate, DateTime toDate)
        {
            return clsTestData.GetAuditLogBetweenTwoDates(fromDate, toDate);
        }
        public static DataTable GetAudidingLogByDate(DateTime Date)
        {
            return clsTestData.GetAllAuditingLogByDate(Date);
        }
    }
}
