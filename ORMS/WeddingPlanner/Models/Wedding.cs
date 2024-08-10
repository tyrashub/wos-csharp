#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Attributes;

namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }

    [Required(ErrorMessage = "Please enter the first wedder.")]
    [MinLength(2)]
    public string WedderOne { get; set; }

    [Required(ErrorMessage = "Please enter the second wedder.")]
    [MinLength(2)]
    public string WedderTwo { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Please enter a valid date.")]
    [FutureDate]
    public DateTime? Date { get; set; }

    [Required(ErrorMessage = "Please enter a valid address.")]
    [MinLength(10)]
    public string Address { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public List<Rsvp> Rsvp { get; set; } = new List<Rsvp>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public bool IsAttending(int userId)
    {
        var attending = false;
        foreach (var rsvp in Rsvp)
        {
            if (rsvp.UserId == userId)
                attending = true;
        }
        return attending;
    }
}
