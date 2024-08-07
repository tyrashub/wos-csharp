#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace LoginAndRegistration.Models;

public class Login
{
    [Display(Name = "Email:")]
    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password:")]
    [Required(ErrorMessage = "Please enter your password.")]
    [MinLength(8, ErrorMessage = "Password must be at least eight unique characters.")]
    public string Password { get; set; }
}