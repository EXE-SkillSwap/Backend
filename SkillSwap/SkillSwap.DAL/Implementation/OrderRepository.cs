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
    public class OrderRepository : IOrderRepository
    {
        private SwapSkillDBContext _context;
        public OrderRepository(SwapSkillDBContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            order.OrderID = Guid.NewGuid();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public Task<Order> DeleteOrder(Guid id, Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders
                .Include(o => o.MembershipSubscription)
                .Include(o => o.OrderDetails)
                .ToListAsync();
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            var order = await _context.Orders
                .Include(o => o.MembershipSubscription)
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
                throw new KeyNotFoundException("Order not found");

            return order;
        }

        public Task<IEnumerable<Order>> GetOrdersByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrder(Guid id, Order order)
        {
            var existing = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (existing == null)
                throw new KeyNotFoundException("Order not found");

            existing.DateCheckOut = order.DateCheckOut;
            existing.TotalPrice = order.TotalPrice;
            existing.MembershipID = order.MembershipID;
            //something is wrong here, i can feel it

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
