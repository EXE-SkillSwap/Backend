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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private SwapSkillDBContext _dbContext;

        public OrderDetailRepository(SwapSkillDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddOrderDetail(OrderDetail orderDetail)
        {
            orderDetail.Id = Guid.NewGuid();
            _dbContext.OrderDetails.Add(orderDetail);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteOrderDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDetail>> GetAllOrderDetails()
        {
            return await _dbContext.OrderDetails
                .Include(od => od.Course)
                .Include(od => od.Order)
                .ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(Guid id)
        {
            var orderDetail = await _dbContext.OrderDetails
                .Include(od => od.Course)
                .Include(od => od.Order)
                .FirstOrDefaultAsync(od => od.Id == id);

            if (orderDetail == null)
                throw new KeyNotFoundException("OrderDetail not found");

            return orderDetail;
        }

        public async Task UpdateOrderDetail(Guid id, OrderDetail orderDetail)
        {
            var existing = await _dbContext.OrderDetails.FindAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("OrderDetail not found");

            existing.Quantity = orderDetail.Quantity;
            existing.CourseID = orderDetail.CourseID;
            existing.OrderId = orderDetail.OrderId;

            await _dbContext.SaveChangesAsync();
        }
    }
}
