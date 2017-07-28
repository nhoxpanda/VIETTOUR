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
    public class tbl_InvoicePartner
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> PartnerId { get; set; }
        public Nullable<int> ServicePartnerId { get; set; }
        public DateTime Date { get; set; }
        public string Request { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> TourId { get; set; }
        public string TourName { get; set; }
        public int StaffId { get; set; }
        public DateTime CreateDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }
        public string Note { get; set; }
        public Nullable<int> ContractId { get; set; }
        public Nullable<int> ProgramId { get; set; }

        [ForeignKey("PartnerId")]
        public tbl_Partner tbl_Partner { get; set; }
        [ForeignKey("ServicePartnerId")]
        public tbl_ServicesPartner tbl_ServicesPartner { get; set; }
        [ForeignKey("StatusId")]
        public tbl_Dictionary tbl_Dictionary { get; set; }
        [ForeignKey("TourId")]
        public tbl_Tour tbl_Tour { get; set; }
        [ForeignKey("StaffId")]
        public tbl_Staff tbl_Staff { get; set; }
        [ForeignKey("ContractId")]
        public tbl_Contract tbl_Contract { get; set; }
        [ForeignKey("ProgramId")]
        public tbl_Program tbl_Program { get; set; }
    }
}
