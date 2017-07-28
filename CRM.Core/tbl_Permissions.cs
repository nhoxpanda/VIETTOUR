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
    public class tbl_Permissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        public virtual ICollection<tbl_AccessData> tbl_AccessData { get; set; }
        public virtual ICollection<tbl_ActionData> tbl_ActionData { get; set; }
        public virtual ICollection<tbl_Staff> tbl_Staff { get; set; }
    }
}
