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
    public class PhotoService : IPhotoService
    {
        private readonly IGenericRepository<Photo> _photoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PhotoService(
            IGenericRepository<Photo> photoRepository,
            IUnitOfWork unitOfWork)
        {
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO> CreatePhoto(Photo photo)
        {
            var dto = new ResponseDTO();
            try
            {
                photo.PhotoID = Guid.NewGuid();

                await _photoRepository.Insert(photo);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.INSERT_SUCESSFULLY;
                dto.Data = photo;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetPhotoById(Guid photoId)
        {
            var dto = new ResponseDTO();
            try
            {
                var photo = await _photoRepository.GetById(photoId);
                if (photo == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = photo;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetAllPhotos(int pageNumber, int pageSize)
        {
            var dto = new ResponseDTO();
            try
            {
                var result = await _photoRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    orderBy: p => p.PhotoID,
                    isAscending: false,
                    includes: new System.Linq.Expressions.Expression<Func<Photo, object>>[]
                    {
                            p => p.UserAccount
                    }
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

        public async Task<ResponseDTO> UpdatePhoto(Photo photo)
        {
            var dto = new ResponseDTO();
            try
            {
                var existing = await _photoRepository.GetById(photo.PhotoID);
                if (existing == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                existing.UserID = photo.UserID;
                existing.URL = photo.URL;
                existing.IsMain = photo.IsMain;

                await _photoRepository.Update(existing);
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

        public async Task<ResponseDTO> DeletePhoto(Guid photoId)
        {
            var dto = new ResponseDTO();
            try
            {
                var deleted = await _photoRepository.DeleteById(photoId);
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
