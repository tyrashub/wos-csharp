using WeddingPlanner.Models;

namespace WeddingPlanner.ViewModels;

public class WeddingsPageViewModel
{
    public User? User { get; set; }
    public List<Wedding> Weddings { get; set; } = new List<Wedding>();
}
