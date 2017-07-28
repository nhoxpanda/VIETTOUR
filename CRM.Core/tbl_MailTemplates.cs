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
    public class tbl_MailTemplates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        [ForeignKey("tbl_MailCategory")]
        public Nullable<int> MailCategoryId { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        public DateTime CreateDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_MailCategory tbl_MailCategory { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual ICollection<tbl_MailSending> tbl_MailSending { get; set; }
    }
}
