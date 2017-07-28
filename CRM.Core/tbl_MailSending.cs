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
    public class tbl_MailSending
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_MailConfig")]
        public Nullable<int> MailConfigId { get; set; }
        [ForeignKey("tbl_MailTemplates")]
        public Nullable<int> MailTemplateId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Nullable<DateTime> SendDate { get; set; }
        [DefaultValue(true)]
        public Boolean Active { get; set; }
        public DateTime CreateDate { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual tbl_MailConfig tbl_MailConfig { get; set; }
        public virtual tbl_MailTemplates tbl_MailTemplates { get; set; }
        public virtual ICollection<tbl_MailSendingList> tbl_MailSendingList { get; set; }
        public virtual ICollection<tbl_MailSendingReceives> tbl_MailSendingReceives { get; set; }
    }
}

