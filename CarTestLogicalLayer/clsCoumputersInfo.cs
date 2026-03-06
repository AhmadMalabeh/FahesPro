using CarTestDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTestLogicalLayer
{
    public class clsCoumputersInfo
    {
        
        public static bool IsValidComputer(string CpuID,string MatherBordID)
        {
            string currentCpuId = "";
            string CurrentMatherBordID = "";

            clsTestData.GetCpuAndMatherBordIDs(ref currentCpuId, ref CurrentMatherBordID);
            if (string.IsNullOrEmpty(currentCpuId) || string.IsNullOrEmpty(CurrentMatherBordID))
            {
                return false; // إذا لم يتمكن من الحصول على المعلومات، يعتبر الكمبيوتر غير صالح
            }
            if (currentCpuId == CpuID && CurrentMatherBordID == MatherBordID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
