using APIEcommerce.Domain.Models;

namespace APIEcommerce.Infrastructure.Repository.IRepository
{
    public interface ICategory
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategories(Guid id);
        Task<Category>Create(Category category);
        Task<Category> Update(Guid id, Category category);
        Task<Category> Delete(Guid id);
    }
}
