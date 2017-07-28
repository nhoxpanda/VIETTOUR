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
    public class tbl_CustomerContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string TagsId { get; set; }
        public int NameTypeId { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string OtherMobile { get; set; }
        public string PhoneNR { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public bool SubscribeEmail { get; set; }
        public bool SubscribeSMS { get; set; }
        public string Note { get; set; }
        public string IdentityCard { get; set; }
        public DateTime? CreatedDateIdentity { get; set; }
        public int? IdentityTagId { get; set; }
        public string PassportCard { get; set; }
        public DateTime? CreatedDatePassport { get; set; }
        public DateTime? ExpiredDatePassport { get; set; }
        public int? PassportTagId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public Boolean IsDelete { get; set; }

        public virtual ICollection<tbl_Tour> tbl_Tour { get; set; }
        public virtual ICollection<tbl_CustomerContactVisa> tbl_CustomerContactVisa { get; set; }
        [ForeignKey("CustomerId")]
        public virtual tbl_Customer tbl_Customer { get; set; }
        [ForeignKey("NameTypeId")]
        public virtual tbl_Dictionary tbl_DictionaryNameType { get; set; }
        [ForeignKey("IdentityTagId")]
        public virtual tbl_Tags tbl_TagsIdentity { get; set; }
        [ForeignKey("IdentityTagId")]
        public virtual tbl_Tags tbl_TagsPassport { get; set; }
    }
}
