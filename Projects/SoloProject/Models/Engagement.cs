#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using SoloProject.Attributes;

namespace SoloProject.Models;
public class Engagement
{
    [Key]
    public int EngagementId { get; set; }
    public int CollectionId { get; set; }
    public Collection? Collection { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public bool Like { get; set; }

    [MaxLength(250, ErrorMessage = "Comment cannot exceed 250 characters long.")]
    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public void ToggleLike()
    {
        Like = !Like;
    }
}