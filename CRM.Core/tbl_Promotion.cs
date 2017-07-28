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
    public class tbl_Promotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("tbl_Program")]
        public Nullable<int> ProgramId { get; set; }
        [ForeignKey("tbl_Tour")]
        public Nullable<int> TourId { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public Nullable<int> CustomerGroupId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Boolean Expired { get; set; }
        public string Awards { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        public virtual tbl_Program tbl_Program { get; set; }
        public virtual tbl_Tour tbl_Tour { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
    }
}
