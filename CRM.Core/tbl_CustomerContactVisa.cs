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
    public class tbl_CustomerContactVisa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_CustomerContact")]
        public int CustomerContactId { get; set; }
        public string VisaNumber { get; set; }
        [ForeignKey("tbl_Tags")]
        public int? TagsId { get; set; }
        public Nullable<DateTime> CreatedDateVisa { get; set; }
        public Nullable<DateTime> ExpiredDateVisa { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public Nullable<int> DictionaryId { get; set; }
        public Nullable<VisaType> VisaType { get; set; }
        public Nullable<int> Deadline { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        public virtual tbl_CustomerContact tbl_CustomerContact { get; set; }
        public virtual tbl_Tags tbl_Tags { get; set; }
    }
}
