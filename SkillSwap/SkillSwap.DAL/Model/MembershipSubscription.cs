using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class MembershipSubscription
    {
        [Key]
        public Guid MembershipID { get; set; }

        public string MembershipName { get; set; }
        public string MembershipDetail { get; set; }
        public bool IsEIDocument { get; set; }
        public double Price { get; set; }

        [ForeignKey("UserMembership")]
        public Guid? UserMembershipID { get; set; }

        public UserMembership UserMembership { get; set; }
    }

}
