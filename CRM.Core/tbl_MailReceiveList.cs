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
    public class tbl_MailReceiveList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_MailReceives")]
        public Nullable<int> MailReceiveId { get; set; }
        [ForeignKey("tbl_Customer")]
        public Nullable<int> CustomerId { get; set; }
        [ForeignKey("tbl_Staff")]
        public Nullable<int> StaffId { get; set; }
        [ForeignKey("tbl_MailImport")]
        public Nullable<int> MailImportId { get; set; }
        public string Vocative { get; set; }
        public string FullName { get; set; }
        public Nullable<DateTime> Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string JobTitte { get; set; }
        public string Department { get; set; }
        public string HomeAddress { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_MailReceives tbl_MailReceives { get; set; }
        public virtual tbl_MailImport tbl_MailImport { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
    }
}
