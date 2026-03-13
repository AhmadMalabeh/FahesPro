using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObj
{
    public class clsSharedclsCarTest
    {
        public int ID { get; set; }
        public string CustumerName { get; set; }
        public string FRShassi { get; set; }
        public string FLShassi { get; set; }
        public string BRShassi { get; set; }
        public string BLShassi { get; set; }
        public string EnginTest { get; set; }
        public string EnginTestPerc { get; set; }
        public string GearTest { get; set; }
        public string BakaksTest { get; set; }
        public string BodyTest { get; set; }
        public string WorkerNotes { get; set; }
        public DateTime TestDate { get; set; }
        public double TestPrice { get; set; }
        public string CenterNotes { get; set; }
        public bool PayLater { get; set; }
        public string CarPlateNumber { get; set; }
        public string CarShassiNumber { get; set; }
        public string CarMakeModel { get; set; }
        public string CarMinufacuringYear { get; set; }
        public string CarColor { get; set; }
        public string CarEnginCapacity { get; set; }

        public int? CreatedByUserID { get; set; }
        public int? ModifiedByUserID { get; set; }
    }
}
