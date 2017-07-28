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
    public class tbl_Opportunity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<int> FormContactId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<double> TiemNang { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> ManagerId { get; set; }
        public Nullable<int> StaffId { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        [ForeignKey("GroupId")]
        public virtual tbl_Dictionary tbl_DictionaryGroup { get; set; }
        [ForeignKey("FormContactId")]
        public virtual tbl_Dictionary tbl_DictionaryFormContact { get; set; }
        [ForeignKey("StatusId")]
        public virtual tbl_Dictionary tbl_DictionaryStatus { get; set; }
        [ForeignKey("CustomerId")]
        public virtual tbl_Customer tbl_Customer { get; set; }
        [ForeignKey("ManagerId")]
        public virtual tbl_Staff tbl_StaffManager { get; set; }
        [ForeignKey("StaffId")]
        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual ICollection<tbl_ContactHistory> tbl_ContactHistory { get; set; }
        public virtual ICollection<tbl_UpdateHistory> tbl_UpdateHistory { get; set; }
        public virtual ICollection<tbl_AppointmentHistory> tbl_AppointmentHistory { get; set; }
        public virtual ICollection<tbl_DocumentFile> tbl_DocumentFile { get; set; }
        public virtual ICollection<tbl_OpportunityRequest> tbl_OpportunityRequest { get; set; }
        public virtual ICollection<tbl_Competitor> tbl_Competitor { get; set; }
        public virtual ICollection<tbl_OpportunityTransaction> tbl_OpportunityTransaction { get; set; }
    }
}
