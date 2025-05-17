using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }

        public double OrderPrice { get; set; }

        [ForeignKey("MembershipSubscription")]
        public Guid? MembershipID { get; set; }

        [ForeignKey("Course")]
        public Guid? CourseID { get; set; }

        public MembershipSubscription MembershipSubscription { get; set; }
        public Course Course { get; set; }
    }

}
