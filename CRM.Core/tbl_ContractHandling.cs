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
    public class tbl_ContractHandling
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public int? StatusId { get; set; }
        public int? PercentFinish { get; set; }
        public string Note { get; set; }
        public string File { get; set; }
        [ForeignKey("tbl_Contract")]
        public int? ContractId { get; set; }
        public DateTime CreateDate { get; set; }
        [ForeignKey("tbl_Staff")]
        public Nullable<int> StaffId { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public tbl_Dictionary tbl_Dictionary { get; set; }
        public tbl_Contract tbl_Contract { get; set; }
        public tbl_Staff tbl_Staff { get; set; }
    }
}
