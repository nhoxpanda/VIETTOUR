using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMVIETTOUR.Models
{
    public class CookieUser
    {
        public int StaffID { get; set; }
        public int BranchID { get; set; }
        public int DepartmentID { get; set; }
        public int GroupID { get; set; }
        public int PermissionID { get; set; }
    }
}