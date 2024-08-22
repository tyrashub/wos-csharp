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

    [ImageFile]
    [Required(ErrorMessage = "Please select a profile image.")]
    public IFormFile? ProfileImage { get; set; }

    [Required(ErrorMessage = "Please enter a new bio.")]
    [MaxLength(500, ErrorMessage = "Bio cannot exceed 500 characters long.")]
    public string? Bio { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
