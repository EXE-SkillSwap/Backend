using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Enum
{
    public enum PaymentStatus
    {
        Unpaid = 0,
        Paid = 1,
        ProcessingRefund = 2,
        Refunded = 3,
        Failed = 4,
    }
}
