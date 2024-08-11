using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models;

public class Search
{
    [Key]
    public int SearchId { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public int CouponId { get; set; }
    public Coupon? Coupon { get; set; }
    // public List<Coupon> Coupons { get; set; } = new List<Coupon>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
