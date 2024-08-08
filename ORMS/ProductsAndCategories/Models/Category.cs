#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter the name of the category.")]
        [MaxLength(45)]
        [MinLength(2, ErrorMessage = "Category name must be at least two characters.")]
        public string Name { get; set; }

        public List<Association> AssociatedProducts { get; set; } = [];

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
