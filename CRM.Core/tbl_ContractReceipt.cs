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
    public class tbl_ContractReceipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Customer { get; set; }
        public float? Price { get; set; }
        public string ReceiptType { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public int? StaffId { get; set; }
        [ForeignKey("tbl_Contract")]
        public int? ContractId { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public int? DictionaryId { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Contract tbl_Contract { get; set; }
        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
    }
}
