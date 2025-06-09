using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Contract
{
    public interface IMaterialService
    {
        Task<ResponseDTO> CreateMaterial(Material material);
        Task<ResponseDTO> GetMaterialById(Guid materialId);
        Task<ResponseDTO> GetAllMaterials(int pageNumber, int pageSize);
        Task<ResponseDTO> UpdateMaterial(Material material);
        Task<ResponseDTO> DeleteMaterial(Guid materialId);
    }
}
