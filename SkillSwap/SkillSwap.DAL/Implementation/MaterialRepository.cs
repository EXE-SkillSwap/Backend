using Microsoft.EntityFrameworkCore;
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
    public class MaterialRepository : IMaterialRepository
    {
        private SwapSkillDBContext _context;

        public MaterialRepository(SwapSkillDBContext context)
        {
            _context = context;
        }

        public async Task<Material> AddMaterial(Material material)
        {
            material.MaterialID = Guid.NewGuid();
            material.CreatedDate = DateTime.UtcNow;
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }

        public async Task<List<Material>> GetAllMaterials()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<Material> UpdateMaterial(Guid id, Material material)
        {
            var existing = await _context.Materials.FindAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Material not found");

            existing.MaterialName = material.MaterialName;
            existing.Quiz = material.Quiz;
            existing.Video = material.Video;
            // Do not update CreatedDate

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
