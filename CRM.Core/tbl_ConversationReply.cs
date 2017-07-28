using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core
{
    public class tbl_ConversationReply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tbl_Conversation")]
        public int ConversationId { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public string IP { get; set; }
        public DateTime CreateDate { get; set; }
        public Boolean IsRead { get; set; }

        public virtual tbl_Conversation tbl_Conversation { get; set; }
    }
}
