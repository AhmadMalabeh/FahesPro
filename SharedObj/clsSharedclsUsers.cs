using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObj
{
    public class clsSharedclsUsers
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}
