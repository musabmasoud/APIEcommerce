
namespace APIEcommerce.Domain.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public double price { get; set; }
    }
}
