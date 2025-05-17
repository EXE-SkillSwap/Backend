using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class UserAccount
    {
        [Key]
        public Guid UserID { get; set; }
        public string Gender { get; set; }
        public string FullName { get; set; }

        [ForeignKey("Role")]
        public Guid RoleID { get; set; }

        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PasswordHash { get; set; }
        public string Address { get; set; }

        [ForeignKey("Interest")]
        public Guid? InterestID { get; set; }

        public int PartnerAmount { get; set; }
        public string Status { get; set; }

        public Role Role { get; set; }
        public Interest Interest { get; set; }
    }

}
