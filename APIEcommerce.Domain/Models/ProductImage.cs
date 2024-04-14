
namespace APIEcommerce.Domain.Models
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
