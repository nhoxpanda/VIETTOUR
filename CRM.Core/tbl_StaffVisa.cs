using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Enum;
using System.ComponentModel;

namespace CRM.Core
{
    public class tbl_StaffVisa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        public string VisaNumber { get; set; }
        [ForeignKey("tbl_Tags")]
        public int? TagsId { get; set; }
        public Nullable<DateTime> CreatedDateVisa { get; set; }
        public Nullable<DateTime> ExpiredDateVisa { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public Nullable<int> DictionaryId { get; set; }
        [ForeignKey("tbl_DictionaryType")]
        public Nullable<int> VisaType { get; set; }
        public Nullable<int> Deadline { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        public virtual tbl_Dictionary tbl_DictionaryType { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual tbl_Tags tbl_Tags { get; set; }
    }
}
