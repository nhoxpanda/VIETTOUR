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
    public class tbl_Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Nullable<int> StartPlace { get; set; }
        public Nullable<int> DestinationPlace { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> TypeTourId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> NumberCustomer { get; set; }
        public Nullable<int> NumberDay { get; set; }
        public Nullable<int> StaffId { get; set; }
        public Nullable<int> ContactId { get; set; }
        public Nullable<double> FirstPrice { get; set; }
        public Nullable<double> SecondPrice { get; set; }
        public string Request { get; set; }
        public string Permission { get; set; }
        [DefaultValue(false)]
        public Boolean IsUpdate { get; set; }
        public Nullable<int> CreateStaffId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }
        public string NoteFlight { get; set; }

        [ForeignKey("StartPlace")]
        public virtual tbl_Tags tbl_TagsStartPlace { get; set; }
        [ForeignKey("DestinationPlace")]
        public virtual tbl_Tags tbl_TagsDestinationPlace { get; set; }
        [ForeignKey("TypeTourId")]
        public virtual tbl_Dictionary tbl_DictionaryTypeTour { get; set; }
        [ForeignKey("StatusId")]
        public virtual tbl_Dictionary tbl_DictionaryStatus { get; set; }
        [ForeignKey("CreateStaffId")]
        public virtual tbl_Staff tbl_StaffCreate { get; set; }
        [ForeignKey("StaffId")]
        public virtual tbl_Staff tbl_Staff { get; set; }
        [ForeignKey("CustomerId")]
        public virtual tbl_Customer tbl_Customer { get; set; }
        [ForeignKey("ContactId")]
        public virtual tbl_CustomerContact tbl_CustomerContact { get; set; }

        public virtual ICollection<tbl_Promotion> tbl_Promotion { get; set; }
        public virtual ICollection<tbl_ReviewTour> tbl_ReviewTour { get; set; }
        public virtual ICollection<tbl_Program> tbl_Program { get; set; }
        public virtual ICollection<tbl_ContactHistory> tbl_ContactHistory { get; set; }
        public virtual ICollection<tbl_UpdateHistory> tbl_UpdateHistory { get; set; }
        public virtual ICollection<tbl_AppointmentHistory> tbl_AppointmentHistory { get; set; }
        public virtual ICollection<tbl_TourGuide> tbl_TourGuide { get; set; }
        public virtual ICollection<tbl_TourSchedule> tbl_TourSchedule { get; set; }
        public virtual ICollection<tbl_CustomerVisa> tbl_CustomerVisa { get; set; }
        public virtual ICollection<tbl_DocumentFile> tbl_DocumentFile { get; set; }
        public virtual ICollection<tbl_LiabilityCustomer> tbl_LiabilityCustomer { get; set; }
        public virtual ICollection<tbl_LiabilityPartner> tbl_LiabilityPartner { get; set; }
        public virtual ICollection<tbl_TourCustomer> tbl_TourCustomer { get; set; }
        public virtual ICollection<tbl_TourCustomerVisa> tbl_TourCustomerVisa { get; set; }
        public virtual ICollection<tbl_InvoicePartner> tbl_InvoicePartner { get; set; }
        public virtual ICollection<tbl_Ticket> tbl_Ticket { get; set; }
        public virtual ICollection<tbl_Task> tbl_Task { get; set; }
    }
}
