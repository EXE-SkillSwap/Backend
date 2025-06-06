using SkillSwap.Commons.DTO.BusinessCode;
using SkillSwap.Commons.DTO;
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
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Payment> _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IGenericRepository<Payment> paymentRepository, IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO> CreatePayment(Payment payment)
        {
            var dto = new ResponseDTO();
            try
            {
                payment.PaymentID = Guid.NewGuid();

                await _paymentRepository.Insert(payment);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.INSERT_SUCESSFULLY;
                dto.Data = payment;
            }
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetPaymentById(Guid paymentId)
        {
            var dto = new ResponseDTO();
            try
            {
                var payment = await _paymentRepository.GetById(paymentId);
                if (payment == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = payment;
            }
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetAllPayments(int pageNumber, int pageSize)
        {
            var dto = new ResponseDTO();
            try
            {
                var result = await _paymentRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    orderBy: p => p.PaymentID,
                    isAscending: false,
                    includes: p => p.Order
                );

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = result;
            }
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> UpdatePayment(Payment payment)
        {
            var dto = new ResponseDTO();
            try
            {
                var existing = await _paymentRepository.GetById(payment.PaymentID);
                if (existing == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                existing.PaymentType = payment.PaymentType;
                existing.ReferenceId = payment.ReferenceId;
                existing.TotalPayment = payment.TotalPayment;
                existing.Status = payment.Status;
                existing.PaymentMethod = payment.PaymentMethod;
                existing.UserId = payment.UserId;

                await _paymentRepository.Update(existing);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.UPDATE_SUCCESSFULLY;
                dto.Data = existing;
            }
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> DeletePayment(Guid paymentId)
        {
            var dto = new ResponseDTO();
            try
            {
                var deleted = await _paymentRepository.DeleteById(paymentId);
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
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }
    }
}
