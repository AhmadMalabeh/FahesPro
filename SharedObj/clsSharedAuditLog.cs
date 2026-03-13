using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObj
{
    public class clsSharedAuditLog
    {
        public int LogID { get; set; }
        public string TableName { get; set; }
        public int RecordID { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string ActionType { get; set; }
        public int ChangedByUserID { get; set; }
        public DateTime ChangedDate { get; set; }
        public string EntryType { get; set; }
    }
}
