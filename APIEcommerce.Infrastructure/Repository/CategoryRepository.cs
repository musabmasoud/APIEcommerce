using APIEcommerce.Domain.Models;
using APIEcommerce.Infrastructure.Data;
using APIEcommerce.Infrastructure.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEcommerce.Infrastructure.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly APIEcommerceDbContext dbContext;

        public CategoryRepository(APIEcommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> Create(Category category)
        {
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;    
        }

        public async Task<Category> Delete(Guid id)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.id == id);
            if (existingCategory == null)
            {
                return null;
            }
            dbContext.Categories.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategories(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Category> Update(Guid id, Category category)
        {
            var existingCategory= await dbContext.Categories.FirstOrDefaultAsync(x=>x.id == id);
            if (existingCategory == null)
            {
                return null;
            }
            existingCategory.Name = category.Name;
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }
    }
}
