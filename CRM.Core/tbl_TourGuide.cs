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
    public class tbl_TourGuide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Staff")]
        public int? StaffId { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        [ForeignKey("tbl_Tags")]
        public int TagId { get; set; }
        [ForeignKey("tbl_Tour")]
        public int TourId { get; set; }
        [DefaultValue(false)]
        public Boolean IsVietlike { get; set; }
        public DateTime CreateDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Staff tbl_Staff{ get; set; }
        public virtual tbl_Tags tbl_Tags { get; set; }
        public virtual tbl_Tour tbl_Tour { get; set; }
    }
}
