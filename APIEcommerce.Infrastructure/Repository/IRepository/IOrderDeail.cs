using APIEcommerce.Domain.Models;

namespace APIEcommerce.Infrastructure.Repository.IRepository
{
    public interface IOrderDeail
    {
        Task<List<OrderDetail>> GetAllOrderDetail();
        Task<OrderDetail> GetOrderDetail(Guid id);
        Task<OrderDetail> Create(OrderDetail OrderDetail);
        Task<OrderDetail> Update(Guid id, OrderDetail OrderDetail);
        Task<OrderDetail> Delete(Guid id);
    }
}
