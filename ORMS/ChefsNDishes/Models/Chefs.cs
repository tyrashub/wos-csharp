#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [MaxLength(45)]
        [Display(Name = "First name")]
        [MinLength(2, ErrorMessage = "First name must be at least two characters.")]
        [Required(ErrorMessage = "Please enter first name.")]
        public string FirstName { get; set; }

        [MaxLength(45)]
        [Display(Name = "Last name")]
        [MinLength(2, ErrorMessage = "Last name must be at least two characters.")]
        [Required(ErrorMessage = "Please enter last name.")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "Please choose your date of birth.")]

        public DateOnly? DateOfBirth { get; set; }
        public List<Dishes> Dishes { get; set; } = new List<Dishes>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // public int Age
        // {
        //     get
        //     {
        //         if (!DateOfBirth.HasValue)
        //             throw new InvalidOperationException("Date of Birth is not set.");

        //         var today = DateOnly.FromDateTime(DateTime.Now);
        //         var age = today.Year - DateOfBirth.Value.Year;

        //         if (DateOfBirth.Value > today.AddYears(-age))
        //             age--;

        //         return age;
        //     }
    }
}

