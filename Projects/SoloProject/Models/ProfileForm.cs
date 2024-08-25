using System.ComponentModel.DataAnnotations;
using SoloProject.Attributes;

namespace SoloProject.Models;

public class ProfileForm

{

    [Key]
    public int UserId { get; set; }

    [Display(Name = "New Username:")]
    [Required(ErrorMessage = "Please enter a new username.")]
    [MinLength(3, ErrorMessage = "Username must be at least three characters.")]
    public string? Username { get; set; }

    [UniqueEmail]
    [Display(Name = "Email:")]
    [Required(ErrorMessage = "Please enter email.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }

    [ImageFile]
    [Required(ErrorMessage = "Please select a profile image.")]
    public IFormFile? ProfileImage { get; set; }

    [Required(ErrorMessage = "Please enter a new bio.")]
    [MaxLength(500, ErrorMessage = "Bio cannot exceed 500 characters long.")]
    public string? Bio { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password:")]
    [Required(ErrorMessage = "Please enter password.")]
    [MinLength(8, ErrorMessage = "Password must be at least eight characters.")]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Password must contain 1 uppercase letter, 1 lowercase letter, and 1 number.")]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password:")]
    [Required(ErrorMessage = "Please retype password.")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    [MinLength(8, ErrorMessage = "Confirm password must be at least eight characters.")]
    public string? ConfirmPassword { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
