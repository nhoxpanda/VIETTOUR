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
    public class tbl_Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        [ForeignKey("tbl_TagsStart")]
        public int? StartPlace { get; set; }
        [ForeignKey("tbl_TagsEnd")]
        public int? EndPlace { get; set; }
        [ForeignKey("tbl_Customer")]
        public int? CustomerId { get; set; }
        [ForeignKey("tbl_DictionaryType")]
        public Nullable<int> TypeId { get; set; }
        [ForeignKey("tbl_DictionaryStatus")]
        public Nullable<int> StatusId { get; set; }
        [ForeignKey("tbl_Staff")]
        public int Staff { get; set; }
        public decimal? Price { get; set; }
        [ForeignKey("tbl_DictionaryCurrency")]
        public Nullable<int> CurrencyId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [ForeignKey("tbl_Contract")]
        public int? ContractId { get; set; }
        [ForeignKey("tbl_Tour")]
        public int? TourId { get; set; }
        [ForeignKey("tbl_Program")]
        public int? ProgramId { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Dictionary tbl_DictionaryType { get; set; }
        public virtual tbl_Dictionary tbl_DictionaryStatus { get; set; }
        public virtual tbl_Dictionary tbl_DictionaryCurrency { get; set; }
        public virtual tbl_Tags tbl_TagsStart { get; set; }
        public virtual tbl_Tags tbl_TagsEnd { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual tbl_Contract tbl_Contract { get; set; }
        public virtual tbl_Tour tbl_Tour { get; set; }
        public virtual tbl_Program tbl_Program { get; set; }
    }
}

