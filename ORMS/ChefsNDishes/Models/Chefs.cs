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

        // [Required(ErrorMessage = "Date of birth is required!")]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // [Display(Name = "Date of Birth")]
        // public DateTime DateOfBirth { get; set; }

        // [Required(ErrorMessage = "Age required!")]
        // [Range(18, int.MaxValue, ErrorMessage = "You must be 18 years of older to be a chef!!")]
        // public int Age => (int)(DateTime.Now.Subtract(DateOfBirth).TotalDays / 365);
        public List<Dishes> Dishes { get; set; } = new List<Dishes>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // public int GetAge()
        // {
        //     if (DateOfBirth == null)
        //     {
        //         throw new InvalidOperationException("Birthdate is not set.");
        //     }
        //     var today = DateTime.Today.Date;
        //     var age = today.Year - DateOfBirth.Value.Year;
        //     // Adjust if the birthdate hasn't occurred yet this year
        //     if (DateOfBirth.Value > today.AddYears(-age)) age--;
        //     return age;
        // }
    }
}

