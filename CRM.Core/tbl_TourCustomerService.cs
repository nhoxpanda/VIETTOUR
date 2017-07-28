using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core
{
    public class tbl_TourCustomerService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("tbl_LiabilityCustomer")]
        public int LiabilityCustomerId { get; set; }
        public string ServiceName { get; set; }
        public int Quantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public Nullable<int> CurrencyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Note { get; set; }

        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }
        public virtual tbl_LiabilityCustomer tbl_LiabilityCustomer { get; set; }
    }
}
