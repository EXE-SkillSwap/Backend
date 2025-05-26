using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Contract
{
    public interface IMaterialRepository
    {
        Task<Material> AddMaterial(Material material);
        Task<List<Material>> GetAllMaterials();

        Task<Material> UpdateMaterial(Guid id, Material material);
    }
}
