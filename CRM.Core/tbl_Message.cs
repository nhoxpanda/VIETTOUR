using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core
{
    public class tbl_Message
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string UserID { get; set; }
        public int GroupID { get; set; }
        public string Status { get; set; }
        public string UserConnectID { get; set; }
        public string UserName { get; set; }
    }
}
