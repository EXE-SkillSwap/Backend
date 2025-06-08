using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Contract
{
    public interface IPhotoService
    {
        Task<ResponseDTO> CreatePhoto(Photo photo);
        Task<ResponseDTO> GetPhotoById(Guid photoId);
        Task<ResponseDTO> GetAllPhotos(int pageNumber, int pageSize);
        Task<ResponseDTO> UpdatePhoto(Photo photo);
        Task<ResponseDTO> DeletePhoto(Guid photoId);
    }
}
