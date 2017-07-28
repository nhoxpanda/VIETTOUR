﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core
{
    public class tbl_ActionData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Permissions")]
        public int PermissionsId { get; set; }
        [ForeignKey("tbl_Form")]
        public int FormId { get; set; }
        [ForeignKey("tbl_Function")]
        public int FunctionId { get; set; }

        public virtual tbl_Permissions tbl_Permissions { get; set; }
        public virtual tbl_Form tbl_Form { get; set; }
        public virtual tbl_Function tbl_Function { get; set; }
    }
}
