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
    public class tbl_LiabilityPartner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_DictionaryService")]
        public Nullable<int> ServiceId { get; set; }
        [ForeignKey("tbl_Partner")]
        public Nullable<int> PartnerId { get; set; }
        public Nullable<Decimal> FirstPayment { get; set; }
        [ForeignKey("tbl_DictionaryCurrencyType1")]
        public Nullable<int> FirstCurrencyType { get; set; }
        public Nullable<Decimal> SecondPayment { get; set; }
        [ForeignKey("tbl_DictionaryCurrencyType2")]
        public Nullable<int> SecondCurrencyType { get; set; }
        public int PaymentMethod { get; set; }
        public Nullable<Decimal> ServicePrice { get; set; }
        public Nullable<Decimal> TotalRemaining { get; set; }
        public string Note { get; set; }
        [ForeignKey("tbl_Tour")]
        public int TourId { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Partner tbl_Partner { get; set; }
        public virtual tbl_Tour tbl_Tour { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual tbl_Dictionary tbl_DictionaryCurrencyType1 { get; set; }
        public virtual tbl_Dictionary tbl_DictionaryCurrencyType2 { get; set; }
        public virtual tbl_Dictionary tbl_DictionaryService { get; set; }
        
    }
}
