using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Contract
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>> GetAllOrderDetails();
        Task<OrderDetail> GetOrderDetailById(Guid id);
        Task AddOrderDetail(OrderDetail orderDetail);
        Task UpdateOrderDetail(Guid id, OrderDetail orderDetail);
        Task DeleteOrderDetail(Guid id);
    }
}
