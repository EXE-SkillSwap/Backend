using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Contract
{
    public interface IOrderService
    {
        Task<ResponseDTO> CreateOrder(Order order);
        Task<ResponseDTO> GetOrderById(Guid orderId);
        Task<ResponseDTO> GetAllOrders(int pageNumber, int pageSize);
        Task<ResponseDTO> UpdateOrder(Order order);
        Task<ResponseDTO> DeleteOrder(Guid orderId);
    }
}
