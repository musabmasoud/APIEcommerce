using APIEcommerce.Domain.Models;

namespace APIEcommerce.Infrastructure.Repository.IRepository
{
    public interface IProduct
    {
        Task<List<Product>> GetAllProduct(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true);
        Task<Product> GetProduct(Guid id);
        Task<Product> Create(Product Product);
        Task<Product> Update(Guid id, Product Product);
        Task<Product> Delete(Guid id);
    }
}
