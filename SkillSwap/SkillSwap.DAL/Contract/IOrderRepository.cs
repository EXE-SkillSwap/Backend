using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Contract
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order);
        Task<Order> UpdateOrder(Guid id, Order order);
        Task<Order> DeleteOrder(Guid id, Order order);
        Task<Order> GetOrderById(Guid id);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<IEnumerable<Order>> GetOrdersByUserId(Guid userId);
    }
}
