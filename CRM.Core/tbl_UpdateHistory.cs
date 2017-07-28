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
    public class tbl_UpdateHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public int DictionaryId { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        [ForeignKey("tbl_Customer")]
        public Nullable<int> CustomerId { get; set; }
        [ForeignKey("tbl_Partner")]
        public Nullable<int> PartnerId { get; set; }
        [ForeignKey("tbl_Program")]
        public Nullable<int> ProgramId { get; set; }
        [ForeignKey("tbl_Contract")]
        public Nullable<int> ContractId { get; set; }
        [ForeignKey("tbl_Tour")]
        public Nullable<int> TourId { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }
        [ForeignKey("tbl_Form")]
        public Nullable<int> FormId { get; set; }
        [ForeignKey("tbl_Module")]
        public Nullable<int> ModuleId { get; set; }
        [ForeignKey("tbl_AppointmentHistory")]
        public Nullable<int> AppointmentId { get; set; }
        [ForeignKey("tbl_Task")]
        public Nullable<int> TaskdId { get; set; }
        [ForeignKey("tbl_Opportunity")]
        public Nullable<int> OpportunityId { get; set; }

        public tbl_Contract tbl_Contract { get; set; }
        public tbl_AppointmentHistory tbl_AppointmentHistory { get; set; }
        public tbl_Task tbl_Task { get; set; }
        public tbl_Dictionary tbl_Dictionary { get; set; }
        public tbl_Staff tbl_Staff { get; set; }
        public tbl_Customer tbl_Customer { get; set; }
        public tbl_Partner tbl_Partner { get; set; }
        public tbl_Program tbl_Program { get; set; }
        public tbl_Tour tbl_Tour { get; set; }
        public tbl_Form tbl_Form { get; set; }
        public tbl_Module tbl_Module { get; set; }
        public tbl_Opportunity tbl_Opportunity { get; set; }
    }
}
