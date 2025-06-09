using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Contract
{
    public interface IOrderDetailService
    {
        Task<ResponseDTO> CreateOrderDetail(OrderDetail orderDetail);
        Task<ResponseDTO> GetOrderDetailById(Guid orderDetailId);
        Task<ResponseDTO> GetAllOrderDetails(int pageNumber, int pageSize);
        Task<ResponseDTO> UpdateOrderDetail(OrderDetail orderDetail);
        Task<ResponseDTO> DeleteOrderDetail(Guid orderDetailId);
    }
}
