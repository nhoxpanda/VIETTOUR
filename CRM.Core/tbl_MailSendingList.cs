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
    public class tbl_MailSendingList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_MailSending")]
        public Nullable<int> MailSendingId { get; set; }
        public Nullable<int> ListId { get; set; }
        public Nullable<DateTime> DateSend { get; set; }
        public string Vocative { get; set; }
        public string FullName { get; set; }
        public Nullable<DateTime> Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string HomeAddress { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_MailSending tbl_MailSending { get; set; }
    }
}
