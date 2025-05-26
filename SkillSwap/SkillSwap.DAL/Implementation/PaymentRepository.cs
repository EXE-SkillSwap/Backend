using Microsoft.EntityFrameworkCore;
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Data;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Implementation
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly SwapSkillDBContext _dbContext;

        public PaymentRepository(SwapSkillDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<List<Payment>> GetAllPayments()
        {
            return await _dbContext.Payments
                                   .Include(p => p.Order)
                                   .Include(p => p.MembershipSubscription)
                                   .ToListAsync();
        }

        public async Task<Payment> GetPaymentById(Guid id)
        {
            return await _dbContext.Payments
                                   .Include(p => p.Order)
                                   .Include(p => p.MembershipSubscription)
                                   .FirstOrDefaultAsync(p => p.PaymentID == id);
        }

        public async Task<Payment> UpdatePayment(Guid id, Payment payment)
        {
            var existingPayment = await _dbContext.Payments.FindAsync(id);
            if (existingPayment == null)
            {
                throw new Exception("Payment not found");
            }

            existingPayment.PaymentType = payment.PaymentType;
            existingPayment.ReferenceId = payment.ReferenceId;
            existingPayment.TotalPayment = payment.TotalPayment;
            existingPayment.Status = payment.Status;
            existingPayment.PaymentMethod = payment.PaymentMethod;
            existingPayment.UserId = payment.UserId;

            await _dbContext.SaveChangesAsync();
            return existingPayment;
        }
    }
}
