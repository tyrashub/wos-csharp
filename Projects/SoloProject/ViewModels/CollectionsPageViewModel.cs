using SoloProject.Models;
namespace SoloProject.ViewModels;

public class CollectionsPageViewModel
{
    public User? User { get; set; }
    public Collection? Collection { get; set; }
    public List<Collection> Collections { get; set; } = new List<Collection>();

}

