#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [MaxLength(45)]
        [MinLength(2, ErrorMessage = "Name must be at least two characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a price.")]
        [Range(0.01, 1000.00, ErrorMessage = "Please enter a price between 0.01 and 1000.00.")]
        public double Price { get; set; }

        public List<Association> AssociatedCategories { get; set; } = [];

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
