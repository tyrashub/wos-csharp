#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using BeltExam.Attributes;

namespace BeltExam.Models;

public class Coupon
{
    [Key]
    public int CouponId { get; set; }


    [Required(ErrorMessage = "Please enter the coupon code.")]
    [MinLength(2, ErrorMessage = "Coupon code must be at least 2 characters long.")]
    public string CouponCode { get; set; }

    [Required(ErrorMessage = "Please enter the website for this code.")]
    [MinLength(2, ErrorMessage = "Website must be at least 2 characters long.")]
    public string Website { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Please enter a valid date.")]
    [FutureDate]
    public DateTime? Expiration { get; set; }

    [Required(ErrorMessage = "Please enter a valid description.")]
    [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
    public string Description { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }

    public int TimesUsed { get; set; }
    public List<Search> Search { get; set; } = new List<Search>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public bool IsUsed(int userId)
    {
        var used = false;
        foreach (var search in Search)
        {
            if (search.UserId == userId)
                used = true;
        }
        return used;
    }

    public bool IsExpired(int userId)
    {
        var expired = false;
        foreach (var search in Search)
        {
            if (search.UserId == userId)
                expired = true;
        }
        return expired;
    }


    public int UsedCoupon()
    {
        return Search.Select(s => s.UserId).Distinct().Count();
    }


}