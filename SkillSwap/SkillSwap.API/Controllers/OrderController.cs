using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<ResponseDTO> CreateOrder([FromBody] Order order)
        {
            return await _orderService.CreateOrder(order);
        }

        [HttpGet("get")]
        public async Task<ResponseDTO> GetOrderById([FromQuery] Guid orderId)
        {
            return await _orderService.GetOrderById(orderId);
        }

        [HttpGet("all")]
        public async Task<ResponseDTO> GetAllOrders([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return await _orderService.GetAllOrders(pageNumber, pageSize);
        }

        [HttpPut("update")]
        public async Task<ResponseDTO> UpdateOrder([FromBody] Order order)
        {
            return await _orderService.UpdateOrder(order);
        }

        [HttpDelete("delete")]
        public async Task<ResponseDTO> DeleteOrder([FromQuery] Guid orderId)
        {
            return await _orderService.DeleteOrder(orderId);
        }
    }
}
