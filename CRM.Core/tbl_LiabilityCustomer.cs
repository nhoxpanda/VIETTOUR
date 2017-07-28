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
    public class tbl_LiabilityCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Tour")]
        public int TourId { get; set; }
        [ForeignKey("tbl_Customer")]
        public int? CustomerId { get; set; }
        public Nullable<Decimal> TotalContract { get; set; }
        public Nullable<Decimal> FirstPrice { get; set; }
        public Nullable<DateTime> FirstDate { get; set; }
        public Nullable<Decimal> SecondPrice { get; set; }
        public Nullable<DateTime> SecondDate { get; set; }
        public Nullable<Decimal> TotalLiquidation { get; set; }
        public Nullable<Decimal> TotalRemaining { get; set; }
        public Boolean IsPayment { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public string Note { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        public DateTime CreateDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }
        [DefaultValue(false)]
        public Boolean IsContract { get; set; }
        [DefaultValue(false)]
        public Boolean IsBill { get; set; }
        [DefaultValue(false)]
        public Boolean IsPPVS { get; set; }
        public string FullNote { get; set; }
        public Nullable<decimal> TotalVisa { get; set; }
        public Nullable<decimal> TotalReturn { get; set; }

        public virtual tbl_Tour tbl_Tour { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual tbl_Dictionary tbl_DictionaryCurrency { get; set; }
        public virtual ICollection<tbl_TourCustomerService> tbl_TourCustomerService { get; set; }
    }
}

