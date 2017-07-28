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
    public class tbl_ServicesPartner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public string StaffContact { get; set; }
        public string Phone { get; set; }
        public string FileName { get; set; }
        public Nullable<int> Standard { get; set; }
        public Nullable<int> NumberRoom { get; set; }
        public Nullable<int> NumberNight { get; set; }
        public Nullable<int> NumberTicket { get; set; }
        public string Position { get; set; }
        public string Flight { get; set; }
        public Nullable<DateTime> Time { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        [ForeignKey("PartnerId")]
        public virtual tbl_Partner tbl_Partner { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual tbl_Dictionary tbl_DictionaryCurrency { get; set; }

        public virtual ICollection<tbl_TourSchedule> tbl_TourSchedule { get; set; }
        public virtual ICollection<tbl_DeadlineOption> tbl_DeadlineOption { get; set; }
        public virtual ICollection<tbl_TourOption> tbl_TourOption { get; set; }
        public virtual ICollection<tbl_InvoicePartner> tbl_InvoicePartner { get; set; }
    }
}
