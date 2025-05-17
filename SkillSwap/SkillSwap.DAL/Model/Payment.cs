using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class Payment
    {
        [Key]
        public Guid PaymentID { get; set; }

        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }

        [ForeignKey("UserAccount")]
        public Guid UserID { get; set; }

        [ForeignKey("Order")]
        public Guid OrderID { get; set; }

        public UserAccount UserAccount { get; set; }
        public Order Order { get; set; }
    }

}
