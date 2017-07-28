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
    public class tbl_AppointmentHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public Nullable<int> DictionaryId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        [ForeignKey("tbl_Staff")]
        public Nullable<int> StaffId { get; set; }
        [ForeignKey("tbl_Customer")]
        public Nullable<int> CustomerId { get; set; }
        [ForeignKey("tbl_Partner")]
        public Nullable<int> PartnerId { get; set; }
        [ForeignKey("tbl_Program")]
        public Nullable<int> ProgramId { get; set; }
        [ForeignKey("tbl_Task")]
        public Nullable<int> TaskId { get; set; }
        [ForeignKey("tbl_Contract")]
        public Nullable<int> ContractId { get; set; }
        [ForeignKey("tbl_Tour")]
        public Nullable<int> TourId { get; set; }
        [ForeignKey("tbl_Opportunity")]
        public Nullable<int> OpportunityId { get; set; }
        public string Note { get; set; }
        public string Ring { get; set; }
        public Boolean IsNotify { get; set; }
        public Boolean IsRepeat { get; set; }
        public Nullable<int> Notify { get; set; }
        public Nullable<int> Repeat { get; set; }
        public string OtherStaff { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public tbl_Task tbl_Task { get; set; }
        [ForeignKey("StatusId")]
        public tbl_Dictionary tbl_DictionaryStatus { get; set; }
        [ForeignKey("ServiceId")]
        public tbl_Dictionary tbl_DictionaryService { get; set; }
        [ForeignKey("DictionaryId")]
        public tbl_Dictionary tbl_Dictionary { get; set; }
        public tbl_Staff tbl_Staff { get; set; }
        public tbl_Customer tbl_Customer { get; set; }
        public tbl_Partner tbl_Partner { get; set; }
        public tbl_Program tbl_Program { get; set; }
        public tbl_Contract tbl_Contract { get; set; }
        public tbl_Tour tbl_Tour { get; set; }
        public tbl_Opportunity tbl_Opportunity { get; set; }
        public virtual ICollection<tbl_UpdateHistory> tbl_UpdateHistory { get; set; }
    }
}
