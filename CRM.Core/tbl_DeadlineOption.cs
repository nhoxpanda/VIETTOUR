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
    public class tbl_DeadlineOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_ServicesPartner")]
        public int ServicesPartnerId { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> Time { get; set; }
        public Nullable<Decimal> Deposit { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string Note { get; set; }
        public string FileName { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public DateTime CreatedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        [ForeignKey("StatusId")]
        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        public virtual tbl_ServicesPartner tbl_ServicesPartner { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual tbl_Dictionary tbl_DictionaryCurrency { get; set; }
        public virtual ICollection<tbl_TourOption> tbl_TourOption { get; set; }

    }
}
