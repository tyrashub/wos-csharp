using System.Security.Permissions;
using SoloProject.Models;

namespace SoloProject.ViewModels;

public class ExplorePageViewModel
{
    public int UserId { get; set; }
    public User? User { get; set; }
    public Collection? Collection { get; set; }
    public Profile? Profile { get; set; }
    public List<Collection> Collections { get; set; } = new List<Collection>();
    public List<User> Users { get; set; } = new List<User>();
}
