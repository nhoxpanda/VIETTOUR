using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CRM.Core
{
    public class tbl_TourSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> PartnerId { get; set; }
        public Nullable<int> ServicesPartnerId { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public Nullable<int> StaffId { get; set; }
        public Nullable<int> TourGuideId { get; set; }
        public int TourId { get; set; }
        public DateTime CreatedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        [ForeignKey("ServiceId")]
        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        [ForeignKey("PartnerId")]
        public virtual tbl_Partner tbl_Partner { get; set; }
        [ForeignKey("ServicesPartnerId")]
        public virtual tbl_ServicesPartner tbl_ServicesPartner { get; set; }
        [ForeignKey("StaffId")]
        public virtual tbl_Staff tbl_Staff { get; set; }
        [ForeignKey("TourGuideId")]
        public virtual tbl_Staff tbl_TourGuide { get; set; }
        [ForeignKey("TourId")]
        public virtual tbl_Tour tbl_Tour { get; set; }
    }
}
