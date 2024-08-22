#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using SoloProject.Attributes;

namespace SoloProject.Models;

public class Collection
{
    [Key]
    public int CollectionId { get; set; }

    [Required(ErrorMessage = "Please enter the collection name.")]
    [MinLength(2, ErrorMessage = "Collection name must be at least 2 characters long.")]
    public string CollectionName { get; set; }

    [Required(ErrorMessage = "Please enter a journal entry.")]
    [MaxLength(3000, ErrorMessage = "Journal entry cannot exceed 3000 characters long.")]
    public string JournalEntry { get; set; }

    [Display(Name = "Upload image (up to 6 images)")]
    public List<string>? ImagePaths { get; set; } = new List<string>();

    public string? CoverImage { get; set; }
    public string? ProfileImage { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Please enter a valid date.")]
    [PastDate]
    public DateTime? Date { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }

    public List<Engagement> Engagements { get; set; } = new List<Engagement>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


}