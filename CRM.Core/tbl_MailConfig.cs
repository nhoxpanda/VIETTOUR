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
    public class tbl_MailConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        [DefaultValue(false)]
        public Boolean EnableSsl { get; set; }
        public Nullable<int> SendMax { get; set; }
        public Nullable<int> Port { get; set; }
        public string Username { get; set; }
        [ForeignKey("tbl_Staff")]
        public Nullable<int> StaffId { get; set; }
        public DateTime DateModify { get; set; }
        [DefaultValue(false)]
        public Boolean IsForgotPassword { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual ICollection<tbl_MailSending> tbl_MailSending { get; set; }
    }
}
