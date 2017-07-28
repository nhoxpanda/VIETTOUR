using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Enum;
using System.ComponentModel;

namespace CRM.Core
{
    public class tbl_Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string TaxCode { get; set; }
        public Nullable<int> NameTypeId { get; set; }
        public string FullName { get; set; }
        public Boolean Gender { get; set; }
        public Nullable<DateTime> Birthday { get; set; }
        public Nullable<int> Birthplace { get; set; }
        public string Address { get; set; }
        public string TagsId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsLock { get; set; }
        public Nullable<int> PositionId { get; set; }
        public Nullable<int> StaffGroupId { get; set; }
        [ForeignKey("tbl_Headquater")]
        public Nullable<int> HeadquarterId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public string IdentityCard { get; set; }
        public Nullable<DateTime> CreatedDateIdentity { get; set; }
        public Nullable<int> IdentityTagId { get; set; }
        public Nullable<int> NationalId { get; set; }
        public Nullable<int> ReligionId { get; set; }
        public string HouseholdAdress { get; set; }
        public Nullable<Marriage> Marriage { get; set; }
        public Nullable<int> InternalNumber { get; set; }
        public Nullable<int> CertificateId { get; set; }
        public string Technique { get; set; }
        public string Language { get; set; }
        public string InformationTechnology { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
        public string PassportCard { get; set; }
        public Nullable<DateTime> CreatedDatePassport { get; set; }
        public Nullable<DateTime> ExpiredDatePassport { get; set; }
        public Nullable<int> PassportTagId { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> RoleGroupId { get; set; }
        public string Skype { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }
        public Nullable<int> PermissionId { get; set; }
        public Nullable<int> StaffId { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
        public string CodeGuide { get; set; }
        [DefaultValue(false)]
        public Boolean IsGuide { get; set; }
        [DefaultValue(true)]
        public Boolean IsVietlike { get; set; }
        public string Password { get; set; }

        public virtual ICollection<tbl_OpportunityRequest> tbl_OpportunityRequest { get; set; }
        public virtual ICollection<tbl_OpportunityTransaction> tbl_OpportunityTransaction { get; set; }
        public virtual ICollection<tbl_Ticket> tbl_Ticket { get; set; }
        public virtual ICollection<tbl_DeadlineOption> tbl_DeadlineOption { get; set; }
        public virtual ICollection<tbl_Task> tbl_Task { get; set; }
        public virtual ICollection<tbl_Tour> tbl_TourStaff { get; set; }
        public virtual ICollection<tbl_Tour> tbl_TourCreateStaff { get; set; }
        public virtual ICollection<tbl_TourSchedule> tbl_TourSchedule { get; set; }
        public virtual ICollection<tbl_TourSchedule> tbl_TourScheduleGuide { get; set; }
        public virtual ICollection<tbl_Quotation> tbl_QuotationStaff { get; set; }
        public virtual ICollection<tbl_Quotation> tbl_QuotationStaffQ { get; set; }
        public virtual ICollection<tbl_QuotationForm> tbl_QuotationForm { get; set; }
        public virtual ICollection<tbl_DocumentFile> tbl_DocumentFile { get; set; }
        public virtual ICollection<tbl_StaffVisa> tbl_StaffVisa { get; set; }
        public virtual ICollection<tbl_Headquater> tbl_Headquater { get; set; }
        public virtual ICollection<tbl_ReviewTour> tbl_ReviewTour { get; set; }
        public virtual ICollection<tbl_Program> tbl_Program { get; set; }
        public virtual ICollection<tbl_ContactHistory> tbl_ContactHistory { get; set; }
        public virtual ICollection<tbl_ContactHistory> tbl_ContactHistoryOther { get; set; }
        public virtual ICollection<tbl_UpdateHistory> tbl_UpdateHistory { get; set; }
        public virtual ICollection<tbl_AppointmentHistory> tbl_AppointmentHistory { get; set; }
        public virtual ICollection<tbl_Promotion> tbl_Promotion { get; set; }
        public virtual ICollection<tbl_TaskHandling> tbl_TaskHandling { get; set; }
        public virtual ICollection<tbl_TaskStaff> tbl_TaskStaff { get; set; }
        public virtual ICollection<tbl_TaskStaff> tbl_TaskStaffCreate { get; set; }
        public virtual ICollection<tbl_TaskNote> tbl_TaskNote { get; set; }
        public virtual ICollection<tbl_TourGuide> tbl_TourGuide { get; set; }
        public virtual ICollection<tbl_LiabilityCustomer> tbl_LiabilityCustomer { get; set; }
        public virtual ICollection<tbl_LiabilityPartner> tbl_LiabilityPartner { get; set; }
        public virtual ICollection<tbl_Partner> tbl_Partner { get; set; }
        public virtual ICollection<tbl_ContractReceipt> tbl_ContractReceipt { get; set; }
        public virtual ICollection<tbl_Customer> tbl_Customer { get; set; }
        public virtual ICollection<tbl_Customer> tbl_ManageCustomer { get; set; }
        public virtual ICollection<tbl_InvoicePartner> tbl_InvoicePartner { get; set; }
        public virtual ICollection<tbl_MailConfig> tbl_MailConfig { get; set; }
        public virtual ICollection<tbl_MailReceives> tbl_MailReceives { get; set; }
        public virtual ICollection<tbl_MailReceiveList> tbl_MailReceiveList { get; set; }
        public virtual ICollection<tbl_MailSending> tbl_MailSending { get; set; }
        public virtual ICollection<tbl_MailTemplates> tbl_MailTemplates { get; set; }
        public virtual ICollection<tbl_MailImport> tbl_MailImport { get; set; }
        public virtual ICollection<tbl_Opportunity> tbl_Opportunity { get; set; }
        public virtual ICollection<tbl_Opportunity> tbl_OpportunityManager { get; set; }
        public virtual ICollection<tbl_Competitor> tbl_Competitor { get; set; }

        [ForeignKey("StaffGroupId")]
        public virtual tbl_Dictionary tbl_DictionaryStaffGroup { get; set; }
        [ForeignKey("NameTypeId")]
        public virtual tbl_Dictionary tbl_DictionaryNameType { get; set; }
        [ForeignKey("PositionId")]
        public virtual tbl_Dictionary tbl_DictionaryPosition { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual tbl_Dictionary tbl_DictionaryDepartment { get; set; }
        [ForeignKey("NationalId")]
        public virtual tbl_Dictionary tbl_DictionaryNational { get; set; }
        [ForeignKey("ReligionId")]
        public virtual tbl_Dictionary tbl_DictionaryReligion { get; set; }
        [ForeignKey("CertificateId")]
        public virtual tbl_Dictionary tbl_DictionaryCertificate { get; set; }
        [ForeignKey("PermissionId")]
        public virtual tbl_Permissions tbl_Permissions { get; set; }
        [ForeignKey("Birthplace")]
        public virtual tbl_Tags tbl_TagsBirthplace { get; set; }
        [ForeignKey("IdentityTagId")]
        public virtual tbl_Tags tbl_TagsIdentity { get; set; }
        [ForeignKey("PassportTagId")]
        public virtual tbl_Tags tbl_TagsPassport { get; set; }
    }
}
