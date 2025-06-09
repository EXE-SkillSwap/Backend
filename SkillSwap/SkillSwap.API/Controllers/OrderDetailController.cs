using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/order-detail")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpPost("create")]
        public async Task<ResponseDTO> CreateOrderDetail([FromBody] OrderDetail orderDetail)
        {
            return await _orderDetailService.CreateOrderDetail(orderDetail);
        }

        [HttpGet("get")]
        public async Task<ResponseDTO> GetOrderDetailById([FromQuery] Guid orderDetailId)
        {
            return await _orderDetailService.GetOrderDetailById(orderDetailId);
        }

        [HttpGet("all")]
        public async Task<ResponseDTO> GetAllOrderDetails([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return await _orderDetailService.GetAllOrderDetails(pageNumber, pageSize);
        }

        [HttpPut("update")]
        public async Task<ResponseDTO> UpdateOrderDetail([FromBody] OrderDetail orderDetail)
        {
            return await _orderDetailService.UpdateOrderDetail(orderDetail);
        }

        [HttpDelete("delete")]
        public async Task<ResponseDTO> DeleteOrderDetail([FromQuery] Guid orderDetailId)
        {
            return await _orderDetailService.DeleteOrderDetail(orderDetailId);
        }
    }
}
