using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/photo")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost("create")]
        public async Task<ResponseDTO> CreatePhoto([FromBody] Photo photo)
        {
            return await _photoService.CreatePhoto(photo);
        }

        [HttpGet("get")]
        public async Task<ResponseDTO> GetPhotoById([FromQuery] Guid photoId)
        {
            return await _photoService.GetPhotoById(photoId);
        }

        [HttpGet("all")]
        public async Task<ResponseDTO> GetAllPhotos([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return await _photoService.GetAllPhotos(pageNumber, pageSize);
        }

        [HttpPut("update")]
        public async Task<ResponseDTO> UpdatePhoto([FromBody] Photo photo)
        {
            return await _photoService.UpdatePhoto(photo);
        }

        [HttpDelete("delete")]
        public async Task<ResponseDTO> DeletePhoto([FromQuery] Guid photoId)
        {
            return await _photoService.DeletePhoto(photoId);
        }
    }
}
