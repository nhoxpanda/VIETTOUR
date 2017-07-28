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
    public class tbl_Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public System.Nullable<CustomerType> CustomerType { get; set; }
        public string Address { get; set; }
        public string TagsId { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> WardId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string PersonalEmail { get; set; }
        public string CompanyEmail { get; set; }
        public System.Nullable<int> CustomerGroupId { get; set; }
        public System.Nullable<int> OriginId { get; set; }
        public string Note { get; set; }
        public string TaxCode { get; set; }
        public System.Nullable<DateTime> CreatedDateTaxCode { get; set; }
        public string CreatedPlaceTaxCode { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
        public string BusinessLicense { get; set; }
        public System.Nullable<DateTime> FoundingDate { get; set; }
        public System.Nullable<int> CareerId { get; set; }
        [DefaultValue(true)]
        public Boolean SubscribeEmail { get; set; }
        [DefaultValue(true)]
        public Boolean SubscribeSMS { get; set; }
        public int? ParentId { get; set; }
        public System.Nullable<int> NameTypeId { get; set; }
        public string FullName { get; set; }
        public string MobilePhone { get; set; }
        public System.Nullable<DateTime> Birthday { get; set; }
        public string Skype { get; set; }
        public string OtherCompany { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Director { get; set; }
        public Nullable<int> GenderId { get; set; }
        public string IdentityCard { get; set; }
        public Nullable<DateTime> CreatedDateIdentity { get; set; }
        public System.Nullable<int> IdentityTagId { get; set; }
        public string PassportCard { get; set; }
        public Nullable<DateTime> CreatedDatePassport { get; set; }
        public Nullable<DateTime> ExpiredDatePassport { get; set; }
        public System.Nullable<int> PassportTagId { get; set; }
        [DefaultValue(false)]
        public Boolean IsTemp { get; set; }
        public Nullable<int> StaffManager { get; set; }
        public Nullable<int> StaffId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }
        public string NoteVisa { get; set; }
        public string NoteTour { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [DefaultValue(false)]
        public Boolean IsSendAccount { get; set; }
        [DefaultValue(false)]
        public Boolean IsTour { get; set; }

        public virtual ICollection<tbl_ReviewTour> tbl_ReviewTour { get; set; }
        public virtual ICollection<tbl_Tour> tbl_Tour { get; set; }
        public virtual ICollection<tbl_CustomerVisa> tbl_CustomerVisa { get; set; }
        public virtual ICollection<tbl_CustomerContact> tbl_CustomerContact { get; set; }
        public virtual ICollection<tbl_ContactHistory> tbl_ContactHistory { get; set; }
        public virtual ICollection<tbl_UpdateHistory> tbl_UpdateHistory { get; set; }
        public virtual ICollection<tbl_AppointmentHistory> tbl_AppointmentHistory { get; set; }
        public virtual ICollection<tbl_LiabilityCustomer> tbl_LiabilityCustomer { get; set; }
        public virtual ICollection<tbl_TourCustomer> tbl_TourCustomer { get; set; }
        public virtual ICollection<tbl_MailReceiveList> tbl_MailReceiveList { get; set; }
        public virtual ICollection<tbl_Ticket> tbl_Ticket { get; set; }
        public virtual ICollection<tbl_Opportunity> tbl_Opportunity { get; set; }
        public virtual ICollection<tbl_TourCustomerService> tbl_TourCustomerService { get; set; }

        [ForeignKey("CustomerGroupId")]
        public virtual tbl_Dictionary tbl_DictionaryCustomerGroup { get; set; }
        [ForeignKey("OriginId")]
        public virtual tbl_Dictionary tbl_DictionaryOrigin { get; set; }
        [ForeignKey("CareerId")]
        public virtual tbl_Dictionary tbl_DictionaryCareer { get; set; }
        [ForeignKey("NameTypeId")]
        public virtual tbl_Dictionary tbl_DictionaryNameType { get; set; }
        [ForeignKey("GenderId")]
        public virtual tbl_Dictionary tbl_DictionaryGender { get; set; }
        [ForeignKey("IdentityTagId")]
        public virtual tbl_Tags tbl_TagsIdentity { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual tbl_Tags tbl_TagsProvince { get; set; }
        [ForeignKey("DistrictId")]
        public virtual tbl_Tags tbl_TagsDistrict { get; set; }
        [ForeignKey("WardId")]
        public virtual tbl_Tags tbl_TagsWard { get; set; }
        [ForeignKey("StaffManager")]
        public virtual tbl_Staff tbl_StaffManager { get; set; }
        [ForeignKey("StaffId")]
        public virtual tbl_Staff tbl_Staff { get; set; }
        [ForeignKey("IdentityTagId")]
        public virtual tbl_Tags tbl_TagsPassport { get; set; }
    }
}
