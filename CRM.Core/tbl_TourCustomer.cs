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
    public class tbl_TourCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("tbl_Tour")]
        public int TourId { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Tour tbl_Tour { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }

    }
}
