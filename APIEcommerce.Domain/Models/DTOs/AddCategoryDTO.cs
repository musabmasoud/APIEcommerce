using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace APIEcommerce.Domain.Models.DTOs
{
    public class AddCategoryDTO
    {
        [Required]
        [MinLength(8, ErrorMessage = "the minimus code has been 3 charector")]
        [MaxLength(8, ErrorMessage = "the maximus code has been 3 charector")]
        public string Name { get; set; }
    }
}
