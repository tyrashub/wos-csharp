using SoloProject.Models;
namespace SoloProject.ViewModels;

public class CollectionDetailsViewModel
{
    public int UserId { get; set; }
    public User? User { get; set; }
    public Collection? Collection { get; set; }
    public Engagement? Engagement { get; set; }
    public List<Engagement> Engagements { get; set; } = new List<Engagement>();
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public bool IsLiked { get; set; }

}
