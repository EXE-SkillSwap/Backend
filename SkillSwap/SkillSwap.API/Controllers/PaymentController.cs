using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create")]
        public async Task<ResponseDTO> CreatePayment([FromBody] Payment payment)
        {
            return await _paymentService.CreatePayment(payment);
        }

        [HttpGet("get")]
        public async Task<ResponseDTO> GetPaymentById([FromQuery] Guid paymentId)
        {
            return await _paymentService.GetPaymentById(paymentId);
        }

        [HttpGet("all")]
        public async Task<ResponseDTO> GetAllPayments([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return await _paymentService.GetAllPayments(pageNumber, pageSize);
        }

        [HttpPut("update")]
        public async Task<ResponseDTO> UpdatePayment([FromBody] Payment payment)
        {
            return await _paymentService.UpdatePayment(payment);
        }

        [HttpDelete("delete")]
        public async Task<ResponseDTO> DeletePayment([FromQuery] Guid paymentId)
        {
            return await _paymentService.DeletePayment(paymentId);
        }
    }
}
