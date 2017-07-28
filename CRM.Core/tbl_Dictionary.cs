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
    public class tbl_Dictionary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DictionaryCategoryId { get; set; }
        public string Note { get; set; }
        public string Icon { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_DictionaryCategory tbl_DictionaryCategory { get; set; }
        public virtual ICollection<tbl_ContractReceipt> tbl_ContractReceipt { get; set; }
        public virtual ICollection<tbl_DeadlineOption> tbl_DeadlineOption { get; set; }
        public virtual ICollection<tbl_DeadlineOption> tbl_DeadlineOptionCurrency { get; set; }

        public virtual ICollection<tbl_DocumentFile> tbl_DocumentFile { get; set; }
        public virtual ICollection<tbl_Partner> tbl_Partner { get; set; }
        public virtual ICollection<tbl_CustomerContact> tbl_CustomerContact { get; set; }
        public virtual ICollection<tbl_Quotation> tbl_Quotation { get; set; }
        public virtual ICollection<tbl_Quotation> tbl_QuotationCurrency { get; set; }
        public virtual ICollection<tbl_QuotationForm> tbl_QuotationForm { get; set; }
        public virtual ICollection<tbl_ReviewTour> tbl_ReviewTour { get; set; }
        public virtual ICollection<tbl_ContactHistory> tbl_ContactHistory { get; set; }
        public virtual ICollection<tbl_UpdateHistory> tbl_UpdateHistory { get; set; }
        public virtual ICollection<tbl_AppointmentHistory> tbl_AppointmentHistory { get; set; }
        public virtual ICollection<tbl_AppointmentHistory> tbl_AppointmentHistoryStatus { get; set; }
        public virtual ICollection<tbl_AppointmentHistory> tbl_AppointmentHistoryService { get; set; }
        public virtual ICollection<tbl_TourOption> tbl_TourOption { get; set; }
        public virtual ICollection<tbl_InvoicePartner> tbl_InvoicePartner { get; set; }
        public virtual ICollection<tbl_TourCustomerService> tbl_TourCustomerService { get; set; }

        public virtual ICollection<tbl_Customer> tbl_CustomerCustomerGroup { get; set; }
        public virtual ICollection<tbl_Customer> tbl_CustomerOrigin { get; set; }
        public virtual ICollection<tbl_Customer> tbl_CustomerCareer { get; set; }
        public virtual ICollection<tbl_Customer> tbl_CustomerNameType { get; set; }
        public virtual ICollection<tbl_Customer> tbl_CustomerGender { get; set; }

        public virtual ICollection<tbl_Staff> tbl_StaffGroup { get; set; }
        public virtual ICollection<tbl_Staff> tbl_StaffNameType { get; set; }
        public virtual ICollection<tbl_Staff> tbl_StaffPosition { get; set; }
        public virtual ICollection<tbl_Staff> tbl_StaffDepartment { get; set; }
        public virtual ICollection<tbl_Staff> tbl_StaffNational { get; set; }
        public virtual ICollection<tbl_Staff> tbl_StaffReligion { get; set; }
        public virtual ICollection<tbl_Staff> tbl_StaffCertificate { get; set; }

        public virtual ICollection<tbl_Tour> tbl_TourTypeTour { get; set; }
        public virtual ICollection<tbl_Tour> tbl_TourStatus { get; set; }
        public virtual ICollection<tbl_TourSchedule> tbl_TourSchedule { get; set; }

        public virtual ICollection<tbl_Contract> tbl_ContractCurrency { get; set; }
        public virtual ICollection<tbl_Contract> tbl_ContractDictionary { get; set; }
        public virtual ICollection<tbl_Contract> tbl_ContractStatus { get; set; }
        public virtual ICollection<tbl_Contract> tbl_ContractCurrencyTDK { get; set; }
        public virtual ICollection<tbl_Contract> tbl_ContractCurrencyLNDK { get; set; }

        public virtual ICollection<tbl_Program> tbl_Program { get; set; }
        public virtual ICollection<tbl_Program> tbl_ProgramStatus { get; set; }
        public virtual ICollection<tbl_Program> tbl_ProgramCurrency { get; set; }

        public virtual ICollection<tbl_Promotion> tbl_Promotion { get; set; }

        public virtual ICollection<tbl_StaffVisa> tbl_StaffVisa { get; set; }
        public virtual ICollection<tbl_StaffVisa> tbl_StaffVisaType { get; set; }
        public virtual ICollection<tbl_CustomerVisa> tbl_CustomerVisa { get; set; }
        public virtual ICollection<tbl_CustomerVisa> tbl_CustomerVisaType { get; set; }
        public virtual ICollection<tbl_CustomerContactVisa> tbl_CustomerContactVisa { get; set; }

        public virtual ICollection<tbl_VisaInfomation> tbl_VisaInfomation { get; set; }
        public virtual ICollection<tbl_VisaInfomation> tbl_VisaInfomationService { get; set; }
        public virtual ICollection<tbl_VisaInfomation> tbl_VisaInfomationCategory { get; set; }

        public virtual ICollection<tbl_TaskHandling> tbl_TaskHandling { get; set; }
        public virtual ICollection<tbl_ServicesPartner> tbl_ServicesPartner { get; set; }
        public virtual ICollection<tbl_LiabilityCustomer> tbl_LiabilityCustomer { get; set; }

        public virtual ICollection<tbl_Task> tbl_TaskType { get; set; }
        public virtual ICollection<tbl_Task> tbl_TaskStatus { get; set; }
        public virtual ICollection<tbl_Task> tbl_TaskPriority { get; set; }

        public virtual ICollection<tbl_LiabilityPartner> tbl_LiabilityPartner1 { get; set; }
        public virtual ICollection<tbl_LiabilityPartner> tbl_LiabilityPartner2 { get; set; }
        public virtual ICollection<tbl_LiabilityPartner> tbl_LiabilityPartnerService { get; set; }

        public virtual ICollection<tbl_Ticket> tbl_TicketType { get; set; }
        public virtual ICollection<tbl_Ticket> tbl_TicketStatus { get; set; }
        public virtual ICollection<tbl_Ticket> tbl_TicketCurrency { get; set; }

        public virtual ICollection<tbl_Opportunity> tbl_OpportunityStatus { get; set; }
        public virtual ICollection<tbl_Opportunity> tbl_OpportunityFormContact { get; set; }
        public virtual ICollection<tbl_Opportunity> tbl_OpportunityGroup { get; set; }
        public virtual ICollection<tbl_OpportunityTransaction> tbl_OpportunityTransaction { get; set; }

    }
}
