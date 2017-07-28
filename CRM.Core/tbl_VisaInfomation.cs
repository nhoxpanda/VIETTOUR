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
    public class tbl_VisaInfomation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? TagId { get; set; }
        public Nullable<float> BasicPrice { get; set; }
        public Nullable<float> BasicService { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<int> CurrencyServiceId { get; set; }
        public Nullable<int> CategoryVisaId { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }
        public int? NumberDay { get; set; }
        public string Address { get; set; }
        public string PlaceIn { get; set; }
        public int? ExpirationDay { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        [ForeignKey("TagId")]
        public virtual tbl_Tags tbl_Tags { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual tbl_Dictionary tbl_DictionaryCurrency { get; set; }
        [ForeignKey("CurrencyServiceId")]
        public virtual tbl_Dictionary tbl_DictionaryCurrencyService { get; set; }
        [ForeignKey("CategoryVisaId")]
        public virtual tbl_Dictionary tbl_DictionaryCategoryVisa { get; set; }
    }
}
