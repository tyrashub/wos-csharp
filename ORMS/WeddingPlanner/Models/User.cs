#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeddingPlanner.Attributes;


namespace WeddingPlanner.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Display(Name = "First name:")]
    [Required(ErrorMessage = "Please enter first name.")]
    [MinLength(2, ErrorMessage = "First name must be at least two characters.")]
    public string FirstName { get; set; }

    [Display(Name = "Last name:")]
    [Required(ErrorMessage = "Please enter last name.")]
    [MinLength(2, ErrorMessage = "Last name must be at least two characters.")]
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    [UniqueEmail]
    [Display(Name = "Email:")]
    [Required(ErrorMessage = "Please enter email.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password:")]
    [Required(ErrorMessage = "Please enter password.")]
    [MinLength(8, ErrorMessage = "Password must be at least eight characters.")]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Password must contain 1 uppercase letter, 1 lowercase letter, and 1 number.")]
    public string Password { get; set; }

    [NotMapped]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password:")]
    [Required(ErrorMessage = "Please retype password.")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    [MinLength(8, ErrorMessage = "Confirm password must be at least eight characters.")]
    public string ConfirmPassword { get; set; }

    // Navigational Properties
    public List<Wedding> Weddings { get; set; } = new List<Wedding>();
    public List<Rsvp> Rsvps { get; set; } = new List<Rsvp>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
