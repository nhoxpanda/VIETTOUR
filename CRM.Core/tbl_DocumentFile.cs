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
    public class tbl_DocumentFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string TagsId { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public int? DictionaryId { get; set; }
        public string Note { get; set; }
        public bool IsRead { get; set; }
        [ForeignKey("tbl_Customer")]
        public Nullable<int> CustomerId { get; set; }
        [ForeignKey("tbl_Staff")]
        public Nullable<int> StaffId { get; set; }
        [ForeignKey("tbl_Partner")]
        public Nullable<int> PartnerId { get; set; }
        [ForeignKey("tbl_Program")]
        public Nullable<int> ProgramId { get; set; }
        [ForeignKey("tbl_Contract")]
        public Nullable<int> ContractId { get; set; }
        [ForeignKey("tbl_Task")]
        public Nullable<int> TaskId { get; set; }
        [ForeignKey("tbl_Tour")]
        public Nullable<int> TourId { get; set; }
        [ForeignKey("tbl_Opportunity")]
        public Nullable<int> OpportunityId { get; set; }
        [DefaultValue(false)]
        public bool IsCustomer { get; set; }
        public string PermissionStaff { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual tbl_Partner tbl_Partner { get; set; }
        public virtual tbl_Program tbl_Program { get; set; }
        public virtual tbl_Contract tbl_Contract { get; set; }
        public virtual tbl_Task tbl_Task { get; set; }
        public virtual tbl_Tour tbl_Tour { get; set; }
        public virtual tbl_Opportunity tbl_Opportunity { get; set; }
    }
}
