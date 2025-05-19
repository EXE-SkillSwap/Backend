using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSwap.DAL.Enum;

namespace SkillSwap.DAL.Model
{
    public class Message
    {
        [Key]
        public Guid MessageID { get; set; }

        [ForeignKey("Sender")]
        public Guid SenderID { get; set; }

        public string Content { get; set; } = null!;
        public MessageStatus Status { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("Conversation")]
        public Guid ConversationID { get; set; }

        public UserAccount? Sender { get; set; }
        public Conversation? Conversation { get; set; }
    }

}
