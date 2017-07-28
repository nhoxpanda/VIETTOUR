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
    public class tbl_Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? TaskTypeId { get; set; }
        public int? TaskStatusId { get; set; }
        public int? TaskPriorityId { get; set; }
        public string CodeTour { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Time { get; set; }
        public string TimeType { get; set; }
        public string Ring { get; set; }
        [DefaultValue(false)]
        public Boolean IsRing { get; set; }
        [DefaultValue(false)]
        public Boolean IsNotify { get; set; }
        public Nullable<int> Notify { get; set; }
        public Nullable<DateTime> NotifyDate { get; set; }
        public Nullable<DateTime> FinishDate { get; set; }
        public Nullable<int> PercentFinish { get; set; }
        public string Note { get; set; }
        [ForeignKey("tbl_Customer")]
        public Nullable<int> CustomerId { get; set; }
        [ForeignKey("tbl_Tour")]
        public Nullable<int> TourId { get; set; }
        public string Permission { get; set; }
        public int StaffId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        [ForeignKey("TaskTypeId")]
        public tbl_Dictionary tbl_DictionaryTaskType { get; set; }
        [ForeignKey("TaskStatusId")]
        public tbl_Dictionary tbl_DictionaryTaskStatus { get; set; }
        [ForeignKey("TaskPriorityId")]
        public tbl_Dictionary tbl_DictionaryTaskPriority { get; set; }
        public tbl_Customer tbl_Customer { get; set; }
        public tbl_Tour tbl_Tour { get; set; }
        [ForeignKey("StaffId")]
        public tbl_Staff tbl_Staff { get; set; }

        public virtual ICollection<tbl_AppointmentHistory> tbl_AppointmentHistory { get; set; }
        public virtual ICollection<tbl_TaskHandling> tbl_TaskHandling { get; set; }
        public virtual ICollection<tbl_DocumentFile> tbl_DocumentFile { get; set; }
        public virtual ICollection<tbl_TaskNote> tbl_TaskNote { get; set; }
        public virtual ICollection<tbl_UpdateHistory> tbl_UpdateHistory { get; set; }
    }
}
