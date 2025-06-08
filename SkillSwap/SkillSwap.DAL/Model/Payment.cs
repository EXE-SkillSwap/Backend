using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSwap.DAL.Enum;
using Microsoft.EntityFrameworkCore;

namespace SkillSwap.DAL.Model
{
    public class Payment
    {
        [Key]
        public Guid PaymentID { get; set; }
        public PaymentType PaymentType { get; set; }
        public Guid ReferenceId { get; set; } // ID dùng chung cho mua Cour hoặc memberShip
        [Precision(18, 4)]
        public decimal TotalPayment { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Unpaid;
        public string PaymentMethod { get; set; } = "VNPay";
        public Guid UserId { get; set; }
        public virtual Order? Order { get; set; }
        public virtual MembershipSubscription? MembershipSubscription { get; set; }
    }

}
