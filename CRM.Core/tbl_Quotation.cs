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
    public class tbl_Quotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string FileName { get; set; }
        [ForeignKey("tbl_Tour")]
        public Nullable<int> TourId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string TagsId { get; set; }
        public Nullable<DateTime> QuotationDate { get; set; }
        public Double? PriceTour { get; set; }
        [ForeignKey("tbl_Customer")]
        public Nullable<int> CustomerId { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public int DictionaryId { get; set; }
        public string Note { get; set; }
        public Nullable<int> StaffId { get; set; }
        public Nullable<int> StaffQuotationId { get; set; }
        public string Permission { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Nullable<int> NumberDay { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Tour tbl_Tour { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }
        public virtual tbl_Dictionary tbl_Dictionary { get; set; }

        [ForeignKey("StaffId")]
        public virtual tbl_Staff tbl_Staff { get; set; }
        [ForeignKey("StaffQuotationId")]
        public virtual tbl_Staff tbl_StaffQuotation { get; set; }
        [ForeignKey("CountryId")]
        public virtual tbl_Tags tbl_TagsCountry { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual tbl_Dictionary tbl_DictionaryCurrency { get; set; }
    }
}

