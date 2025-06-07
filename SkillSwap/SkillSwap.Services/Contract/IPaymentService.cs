using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Contract
{
    public interface IPaymentService
    {
        Task<ResponseDTO> CreatePayment(Payment payment);
        Task<ResponseDTO> GetPaymentById(Guid paymentId);
        Task<ResponseDTO> GetAllPayments(int pageNumber, int pageSize);
        Task<ResponseDTO> UpdatePayment(Payment payment);
        Task<ResponseDTO> DeletePayment(Guid paymentId);
    }
}
