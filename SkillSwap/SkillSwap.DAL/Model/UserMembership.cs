using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class UserMembership
    {
        [Key]
        public Guid UserMembershipID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("Membership")]
        public Guid MembershipID { get; set; }

        [ForeignKey("UserAccount")]
        public Guid UserID { get; set; }

        public MembershipSubscription Membership { get; set; }
        public UserAccount UserAccount { get; set; }
    }

}
