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
    public class tbl_ReviewTour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double? AverageMark { get; set; }
        [ForeignKey("tbl_Tour")]
        public int TourId { get; set; }
        [ForeignKey("tbl_Customer")]
        public Nullable<int> CustomerId { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Tour tbl_Tour { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }

        public virtual List<tbl_ReviewTourDetail> tbl_ReviewTourDetail { get; set; }
    }
}

