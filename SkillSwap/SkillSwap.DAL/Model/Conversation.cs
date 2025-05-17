using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class Conversation
    {
        [Key]
        public Guid ConversationID { get; set; }

        [ForeignKey("UserAccount")]
        public Guid UserID { get; set; }

        public string ConversationName { get; set; }
        public DateTime LastMessageAt { get; set; }

        public UserAccount UserAccount { get; set; }
    }

}
