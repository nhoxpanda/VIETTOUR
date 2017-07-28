using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core
{
    public class tbl_AccessData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Permissions")]
        public Nullable<int> PermissionId { get; set; }
        [ForeignKey("tbl_Form")]
        public int FormId { get; set; }
        [ForeignKey("tbl_ShowDataBy")]
        public int ShowDataById { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Permissions tbl_Permissions { get; set; }
        public virtual tbl_Form tbl_Form { get; set; }
        public virtual tbl_ShowDataBy tbl_ShowDataBy { get; set; }
    }
}
