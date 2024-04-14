using APIEcommerce.Domain.Models;

namespace APIEcommerce.Infrastructure.Repository.IRepository
{
    public interface IProductImage
    {
        Task<List<ProductImage>> GetAll();
        Task<ProductImage> Get(Guid id);
        Task<ProductImage> Create(ProductImage ProductImage);
        Task<ProductImage> Update(Guid id, ProductImage ProductImage);
        Task<ProductImage> Delete(Guid id);
    }
}
