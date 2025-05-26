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
    public class PhotoRepository : IPhotoRepository
    {
        private readonly SwapSkillDBContext _context;
        public PhotoRepository(SwapSkillDBContext context)
        {
            _context = context;
        }

        public async Task<Photo> AddPhoto(Photo photo)
        {
            photo.PhotoID = Guid.NewGuid();
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();
            return photo;
        }

        public async Task<Photo> UpdatePhoto(Guid id, Photo photo)
        {
            var existing = await _context.Photos.FindAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Photo not found");

            existing.URL = photo.URL;
            existing.IsMain = photo.IsMain;
            //existing.UserID = photo.UserID; do not change UserID

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
