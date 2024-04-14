using System.ComponentModel.DataAnnotations.Schema;


namespace APIEcommerce.Domain.Models.DTOs
{
    public class OrderDetailDTO
    {
        public Guid Id { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
