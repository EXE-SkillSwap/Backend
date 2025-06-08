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
    public class MaterialService : IMaterialService
    {
        private readonly IGenericRepository<Material> _materialRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MaterialService(
            IGenericRepository<Material> materialRepository,
            IUnitOfWork unitOfWork)
        {
            _materialRepository = materialRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO> CreateMaterial(Material material)
        {
            var dto = new ResponseDTO();
            try
            {
                material.MaterialID = Guid.NewGuid();
                material.CreatedDate = DateTime.UtcNow;

                await _materialRepository.Insert(material);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.INSERT_SUCESSFULLY;
                dto.Data = material;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetMaterialById(Guid materialId)
        {
            var dto = new ResponseDTO();
            try
            {
                var material = await _materialRepository.GetById(materialId);
                if (material == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = material;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetAllMaterials(int pageNumber, int pageSize)
        {
            var dto = new ResponseDTO();
            try
            {
                var result = await _materialRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    orderBy: m => m.CreatedDate,
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

        public async Task<ResponseDTO> UpdateMaterial(Material material)
        {
            var dto = new ResponseDTO();
            try
            {
                var existing = await _materialRepository.GetById(material.MaterialID);
                if (existing == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                existing.MaterialName = material.MaterialName;
                existing.Quiz = material.Quiz;
                existing.Video = material.Video;
                // Not update CreatedDate

                await _materialRepository.Update(existing);
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

        public async Task<ResponseDTO> DeleteMaterial(Guid materialId)
        {
            var dto = new ResponseDTO();
            try
            {
                var deleted = await _materialRepository.DeleteById(materialId);
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
