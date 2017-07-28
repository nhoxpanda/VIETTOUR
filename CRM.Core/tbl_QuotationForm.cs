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
    public class tbl_QuotationForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string FileName { get; set; }
        public Nullable<int> OptionNumber { get; set; }
        public Nullable<int> DownloadNumber { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public int DictionaryId { get; set; }
        public string  Note { get; set; }
        public string Permission { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
    }
}
