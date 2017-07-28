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
    public class tbl_OpportunityTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public Nullable<int> TypeId { get; set; }
        [ForeignKey("tbl_Opportunity")]
        public Nullable<int> OpportunityId { get; set; }
        [ForeignKey("tbl_Staff")]
        public Nullable<int> StaffId { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        public virtual tbl_Opportunity tbl_Opportunity { get; set; }
    }
}
