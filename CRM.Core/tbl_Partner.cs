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
    public class tbl_Partner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public int DictionaryId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Director { get; set; }
        public string TagsLocationId { get; set; }
        public Nullable<int> StyleId { get; set; }
        public string StaffContact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Note { get; set; }
        public string xMap { get; set; }
        public string yMap { get; set; }
        public string AddressMap { get; set; }
        public string QuyMoDoiTac { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> StaffId { get; set; }
        [DefaultValue(false)]
        public Boolean Outbound { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }
        public string Icon { get; set; }

        [ForeignKey("DictionaryId")]
        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        [ForeignKey("CountryId")]
        public virtual tbl_Tags tbl_TagsCountry { get; set; }
        [ForeignKey("StyleId")]
        public virtual tbl_Tags tbl_TagsStyle { get; set; }
        [ForeignKey("StaffId")]
        public virtual tbl_Staff tbl_Staff { get; set; }

        public virtual ICollection<tbl_TourOption> tbl_TourOption { get; set; }
        public virtual ICollection<tbl_ServicesPartner> tbl_ServicesPartner { get; set; }
        public virtual ICollection<tbl_PartnerNote> tbl_PartnerNote { get; set; }
        public virtual ICollection<tbl_ContactHistory> tbl_ContactHistory { get; set; }
        public virtual ICollection<tbl_UpdateHistory> tbl_UpdateHistory { get; set; }
        public virtual ICollection<tbl_AppointmentHistory> tbl_AppointmentHistory { get; set; }
        public virtual ICollection<tbl_LiabilityPartner> tbl_LiabilityPartner { get; set; }
        public virtual ICollection<tbl_TourSchedule> tbl_TourSchedule { get; set; }
        public virtual ICollection<tbl_InvoicePartner> tbl_InvoicePartner { get; set; }
    }
}
