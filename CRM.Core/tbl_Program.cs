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
    public class tbl_Program
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [ForeignKey("tbl_Tour")]
        public Nullable<int> TourId { get; set; }
        public Nullable<int> DictionaryId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string TagsId { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NumberDay { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [ForeignKey("tbl_Staff")]
        public int StaffId { get; set; }
        [ForeignKey("tbl_Customer")]
        public Nullable<int> CustomerId { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public string Permission { get; set; }
        public string Note { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        [ForeignKey("DictionaryId")]
        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        [ForeignKey("StatusId")]
        public virtual tbl_Dictionary tbl_DictionaryStatus { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual tbl_Dictionary tbl_DictionaryCurrency { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }
        public virtual tbl_Tour tbl_Tour { get; set; }
        public virtual tbl_Staff tbl_Staff { get; set; }
        public virtual ICollection<tbl_DocumentFile> tbl_DocumentFile { get; set; }
        public virtual ICollection<tbl_ContactHistory> tbl_ContactHistory { get; set; }
        public virtual ICollection<tbl_UpdateHistory> tbl_UpdateHistory { get; set; }
        public virtual ICollection<tbl_AppointmentHistory> tbl_AppointmentHistory { get; set; }
        public virtual ICollection<tbl_Promotion> tbl_Promotion { get; set; }
        public virtual ICollection<tbl_InvoicePartner> tbl_InvoicePartner { get; set; }
        public virtual ICollection<tbl_Ticket> tbl_Ticket { get; set; }
    }
}
