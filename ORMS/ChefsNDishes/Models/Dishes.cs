#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models;

public class Dishes
{
    [Key]
    public int DishesId { get; set; }

    [Required(ErrorMessage = "Please enter the name of the dish.")]
    [MinLength(2, ErrorMessage = "Name must be at least two characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please choose a tastinesss rating of 1 to 5.")]
    [Range(1, 6, ErrorMessage = "Rating must be between 1 and 5.")]
    public double Tastiness { get; set; }

    [Required(ErrorMessage = "Please choose the amount of calories")]
    [Range(1, 1500, ErrorMessage = "Calories must be between 1 and 1500.")]
    public double Calories { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int ChefId { get; set; }

    public Chef? Chef { get; set; }

}