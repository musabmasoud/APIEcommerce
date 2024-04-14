
namespace APIEcommerce.Domain.Models.DTOs
{
    internal class ShoppingCartDTO
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public double price { get; set; }
    }
}
