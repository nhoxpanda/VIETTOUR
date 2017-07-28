using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core
{
    public class tbl_Conversation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId1 { get; set; }
        public string ToUser { get; set; }
        public string IP { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<tbl_ConversationReply> tbl_ConversationReply { get; set; }
    }
}
