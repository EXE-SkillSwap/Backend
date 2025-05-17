using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class PartnerShip
    {
        [Key]
        public Guid PartnerID { get; set; }

        [ForeignKey("User1")]
        public Guid UserID1 { get; set; }

        [ForeignKey("User2")]
        public Guid UserID2 { get; set; }

        public string Status { get; set; }

        public UserAccount User1 { get; set; }
        public UserAccount User2 { get; set; }
    }

}
