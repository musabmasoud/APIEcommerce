using APIEcommerce.Domain.Models;

namespace APIEcommerce.Infrastructure.Repository.IRepository
{
    public interface IProduct
    {
        Task<List<IProduct>> GetAllProduct();
        Task<IProduct> GetProduct(Guid id);
        Task<IProduct> Create(IProduct Product);
        Task<IProduct> Update(Guid id, IProduct Product);
        Task<IProduct> Delete(Guid id);
    }
}
