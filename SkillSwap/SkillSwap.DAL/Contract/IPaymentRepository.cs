using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Contract
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentById(Guid id);
        Task<List<Payment>> GetAllPayments();
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> UpdatePayment(Guid id, Payment payment);
    }
}
