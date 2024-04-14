using APIEcommerce.Domain.Models;


namespace APIEcommerce.Infrastructure.Repository.IRepository
{
    public interface IOrderHeader
    {
        Task<List<OrderHeader>> GetAll();
        Task<OrderHeader> Get(Guid id);
        Task<OrderHeader> Create(OrderHeader OrderHeader);
        Task<OrderHeader> Update(Guid id, OrderHeader OrderHeader);
        Task<OrderHeader> Delete(Guid id);
    }
}
