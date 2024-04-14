using APIEcommerce.Domain.Models;


namespace APIEcommerce.Infrastructure.Repository.IRepository
{
    public interface IShoppingCart
    {
        Task<List<ShoppingCart>> GetAll();
        Task<ShoppingCart> Get(Guid id);
        Task<ShoppingCart> Create(ShoppingCart ShoppingCart);
        Task<ShoppingCart> Update(Guid id, ShoppingCart ShoppingCart);
        Task<ShoppingCart> Delete(Guid id);
    }
}
