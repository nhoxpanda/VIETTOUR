using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core
{
    public class tbl_MailSendingReceives
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_MailSending")]
        public Nullable<int> SendingId { get; set; }
        [ForeignKey("tbl_MailReceives")]
        public Nullable<int> ReceiveId { get; set; }

        public tbl_MailSending tbl_MailSending { get; set; }
        public tbl_MailReceives tbl_MailReceives { get; set; }
    }
}

