using System.ComponentModel.DataAnnotations;
using SoloProject.Attributes;

namespace SoloProject.Models;

public class CollectionForm

{
    [Key]
    public int CollectionId { get; set; }

    [Required(ErrorMessage = "Please enter the collection name.")]
    [MinLength(2, ErrorMessage = "Collection name must be at least 2 characters long.")]
    public string? CollectionName { get; set; }

    [Required(ErrorMessage = "Please enter a journal entry.")]
    [MaxLength(3000, ErrorMessage = "Journal entry cannot exceed 3000 characters long.")]
    public string? JournalEntry { get; set; }

    [ImageFile]
    [Required(ErrorMessage = "Please select at least 1 image.")]
    [Display(Name = "Upload up to 6 image(s)")]
    public List<IFormFile>? Images { get; set; }

    [ImageFile]
    [Required(ErrorMessage = "Please select an image.")]
    public IFormFile? CoverImage { get; set; }


    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Please enter a valid date.")]
    [PastDate]
    public DateTime? Date { get; set; }

    public int UserId { get; set; }


}