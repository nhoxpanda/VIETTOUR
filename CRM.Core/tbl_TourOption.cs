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
    public class tbl_TourOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Tour")]
        public int TourId { get; set; }
        [ForeignKey("tbl_Partner")]
        public int PartnerId { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public int ServiceId { get; set; }
        [ForeignKey("tbl_ServicesPartner")]
        public Nullable<int> ServicePartnerId { get; set; }
        [ForeignKey("tbl_DeadlineOption")]
        public Nullable<int> DeadlineId { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Tour tbl_Tour { get; set; }
        public virtual tbl_Partner tbl_Partner { get; set; }
        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        public virtual tbl_ServicesPartner tbl_ServicesPartner { get; set; }
        public virtual tbl_DeadlineOption tbl_DeadlineOption { get; set; }
    }
}
