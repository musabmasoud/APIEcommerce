
namespace APIEcommerce.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public double OfferPrice { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
