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
    public class tbl_Form
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Nullable<int> ModuleId { get; set; }
        [DefaultValue(false)]
        public Boolean IsLoadByLevel { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }
        [DefaultValue(false)]
        public Boolean IsMenu { get; set; }

        public virtual tbl_Module tbl_Module { get; set; }
        public virtual ICollection<tbl_FormFunction> tbl_FormFunction { get; set; }
        public virtual ICollection<tbl_AccessData> tbl_AccessData { get; set; }
        public virtual ICollection<tbl_ActionData> tbl_ActionData { get; set; }
        public virtual ICollection<tbl_UpdateHistory> tbl_UpdateHistory { get; set; }
    }
}
