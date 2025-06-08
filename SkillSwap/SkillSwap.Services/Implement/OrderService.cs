using SkillSwap.Commons.DTO;
using SkillSwap.Commons.DTO.BusinessCode;
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Implement
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(
            IGenericRepository<Order> orderRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO> CreateOrder(Order order)
        {
            var dto = new ResponseDTO();
            try
            {
                order.OrderID = Guid.NewGuid();
                order.DateCheckOut = DateTime.UtcNow;

                await _orderRepository.Insert(order);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.INSERT_SUCESSFULLY;
                dto.Data = order;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetOrderById(Guid orderId)
        {
            var dto = new ResponseDTO();
            try
            {
                var order = await _orderRepository.GetById(orderId);
                if (order == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = order;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetAllOrders(int pageNumber, int pageSize)
        {
            var dto = new ResponseDTO();
            try
            {
                var result = await _orderRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    orderBy: o => o.DateCheckOut,
                    isAscending: false
                );

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = result;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> UpdateOrder(Order order)
        {
            var dto = new ResponseDTO();
            try
            {
                var existing = await _orderRepository.GetById(order.OrderID);
                if (existing == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                //existing.DateCheckOut = order.DateCheckOut;
                // Not change DateCheckOut
                existing.TotalPrice = order.TotalPrice;
                existing.OrderDetails = order.OrderDetails;

                await _orderRepository.Update(existing);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.UPDATE_SUCCESSFULLY;
                dto.Data = existing;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> DeleteOrder(Guid orderId)
        {
            var dto = new ResponseDTO();
            try
            {
                var deleted = await _orderRepository.DeleteById(orderId);
                if (deleted == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                await _unitOfWork.SaveChangeAsync();
                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.CANCEL_SUCCESSFULLY;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }
    }
}
