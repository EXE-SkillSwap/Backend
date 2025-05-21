using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Data;
using SkillSwap.DAL.Model;

namespace SkillSwap.DAL.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private SwapSkillDBContext _dbContext;
        public CategoryRepository (SwapSkillDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            categories = await _dbContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateCategory(Guid id, Category category)
        {
            var isExistCategory = await _dbContext.Categories.FindAsync(id);
            if (isExistCategory != null)
            {
                isExistCategory.CategoryName = category.CategoryName;
            }
            else
            {
                throw new Exception("key not found");
            }
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
