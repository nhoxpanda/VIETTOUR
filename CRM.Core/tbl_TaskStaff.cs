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
    public class tbl_TaskStaff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Task")]
        public int TaskId { get; set; }
        public int StaffId { get; set; }
        public int CreateStaffId { get; set; }
        public string Role { get; set; }
        public string Note { get; set; }
        public Boolean IsUse { get; set; }
        public DateTime CreateDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Task tbl_Task{ get; set; }
        [ForeignKey("TaskId")]
        public virtual tbl_Staff tbl_Staff { get; set; }
        [ForeignKey("CreateStaffId")]
        public virtual tbl_Staff tbl_StaffCreate { get; set; }
    }
}
