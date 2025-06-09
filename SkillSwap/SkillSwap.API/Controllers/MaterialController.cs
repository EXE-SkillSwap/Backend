using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/material")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpPost("create")]
        public async Task<ResponseDTO> CreateMaterial([FromBody] Material material)
        {
            return await _materialService.CreateMaterial(material);
        }

        [HttpGet("get")]
        public async Task<ResponseDTO> GetMaterialById([FromQuery] Guid materialId)
        {
            return await _materialService.GetMaterialById(materialId);
        }

        [HttpGet("all")]
        public async Task<ResponseDTO> GetAllMaterials([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return await _materialService.GetAllMaterials(pageNumber, pageSize);
        }

        [HttpPut("update")]
        public async Task<ResponseDTO> UpdateMaterial([FromBody] Material material)
        {
            return await _materialService.UpdateMaterial(material);
        }

        [HttpDelete("delete")]
        public async Task<ResponseDTO> DeleteMaterial([FromQuery] Guid materialId)
        {
            return await _materialService.DeleteMaterial(materialId);
        }
    }
}
