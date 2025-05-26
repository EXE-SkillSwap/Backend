using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Contract
{
    public interface IPhotoRepository
    {
        Task<Photo> AddPhoto(Photo photo);
        Task<Photo> UpdatePhoto(Guid id, Photo photo);
    }
}
