using BeltExam.Models;
namespace BeltExam.ViewModels;

public class CouponDetailsViewModel
{
    public int? UserId { get; set; }
    public Coupon? Coupon { get; set; }
    public Search? Search { get; set; }
}
