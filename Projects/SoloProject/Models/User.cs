#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;
using SoloProject.Attributes;


namespace SoloProject.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Display(Name = "Username:")]
    [Required(ErrorMessage = "Please enter a username.")]
    [MinLength(3, ErrorMessage = "Username must be at least three characters.")]
    public string? Username { get; set; }

    [UniqueEmail]
    [Display(Name = "Email:")]
    [Required(ErrorMessage = "Please enter email.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password:")]
    [Required(ErrorMessage = "Please enter password.")]
    [MinLength(8, ErrorMessage = "Password must be at least eight characters.")]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Password must contain 1 uppercase letter, 1 lowercase letter, and 1 number.")]
    public string? Password { get; set; }

    [NotMapped]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password:")]
    [Required(ErrorMessage = "Please retype password.")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    [MinLength(8, ErrorMessage = "Confirm password must be at least eight characters.")]
    public string? ConfirmPassword { get; set; }
    public string? ProfileImage { get; set; }

    [Required(ErrorMessage = "Please enter a bio.")]
    [MaxLength(500, ErrorMessage = "Bio cannot exceed 500 characters long.")]
    public string? Bio { get; set; }

    // // Navigational Properties
    public List<Collection> Collections { get; set; } = new List<Collection>();
    public List<Engagement> Engagements { get; set; } = new List<Engagement>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
