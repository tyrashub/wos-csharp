#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using DojoSurvey.Controllers;

namespace DojoSurvey.Models;

public class Ninja
{
    [Display()]
    [Required(ErrorMessage = "Please enter your name.")]
    [MinLength(3, ErrorMessage = "Name must be at least three characters.")]
    public string Name { get; set; }

    [Display()]
    [Required(ErrorMessage = "Please enter your dojo location.")]
    public string Dojo { get; set; }

    [Display()]
    [Required(ErrorMessage = "Please enter your favorite language, or the one you feel most comfortable with.")]
    public string FavLang { get; set; }

    public string? Message { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Please enter a valid date.")]
    [FutureDate]
    public DateTime? FutureDate { get; set; }
}
