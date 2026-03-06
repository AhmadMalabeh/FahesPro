using CarTestDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTestLogicalLayer
{
    public static class clsCharts
    {

        
            
        public static DataTable DataTableGetTestsAndTotalPriceByYear(int year)
        {
            return clsTestData.GetAllTestsAndTotalPriceByYear(year);
        }
    }
}
