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
    public class tbl_MailImport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StaffId { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        [ForeignKey("StaffId")]
        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual ICollection<tbl_MailReceiveList> tbl_MailReceiveList { get; set; }
    }
}
