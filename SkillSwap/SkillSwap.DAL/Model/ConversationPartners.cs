using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class ConversationPartners
    {
        [Key]
        public Guid ConversationPartnersID { get; set; }

        [ForeignKey("UserAccount")]
        public Guid UserID { get; set; }

        [ForeignKey("Conversation")]
        public Guid ConversationID { get; set; }

        public UserAccount UserAccount { get; set; }
        public Conversation Conversation { get; set; }
    }

}
