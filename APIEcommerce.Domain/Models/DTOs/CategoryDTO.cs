using System.ComponentModel.DataAnnotations;


namespace APIEcommerce.Domain.Models.DTOs
{
    public class CategoryDTO
    {
        public Guid id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
