using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEcommerce.Domain.Models
{
    public class Category
    {
        public Guid id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
