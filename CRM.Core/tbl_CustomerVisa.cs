using CRM.Enum;
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
    public class tbl_CustomerVisa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Customer")]
        public int CustomerId { get; set; }
        public string VisaNumber { get; set; }
        [ForeignKey("tbl_Tags")]
        public int? TagsId { get; set; }
        public Nullable<DateTime> CreatedDateVisa { get; set; }
        public Nullable<DateTime> ExpiredDateVisa { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> DictionaryId { get; set; }
        [ForeignKey("tbl_Tour")]
        public Nullable<int> TourId { get; set; }
        public Nullable<int> VisaTypeId { get; set; }
        public Nullable<int> Deadline { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Tour tbl_Tour { get; set; }
        [ForeignKey("DictionaryId")]
        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        [ForeignKey("VisaTypeId")]
        public virtual tbl_Dictionary tbl_DictionaryType { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }
        public virtual tbl_Tags tbl_Tags { get; set; }

        public virtual ICollection<tbl_TourCustomerVisa> tbl_TourCustomerVisa { get; set; }
    }
}
