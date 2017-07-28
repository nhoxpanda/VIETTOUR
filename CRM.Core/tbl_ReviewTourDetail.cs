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
    public class tbl_ReviewTourDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Mark { get; set; }
        [ForeignKey("tbl_Dictionary")]
        public int DictionaryId { get; set; }
        [ForeignKey("tbl_ReviewTour")]
        public int ReviewTourId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual tbl_Dictionary tbl_Dictionary { get; set; }
        public virtual tbl_ReviewTour tbl_ReviewTour { get; set; }
    }
}
