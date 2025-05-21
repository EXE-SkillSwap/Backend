using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSwap.DAL.Model;

namespace SkillSwap.DAL.Contract
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryById(Guid id);
        Task<List<Category>> GetAllCategories();
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Guid id, Category category);
    }
}
