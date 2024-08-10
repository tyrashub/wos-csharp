using WeddingPlanner.Models;
namespace WeddingPlanner.ViewModels;

public class WeddingDetailsViewModel
{
    public int? UserId { get; set; }
    public Wedding? Wedding { get; set; }
    public Rsvp? Rsvp { get; set; }
}
