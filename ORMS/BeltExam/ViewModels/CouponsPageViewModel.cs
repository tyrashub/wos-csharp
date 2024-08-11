using BeltExam.Models;

namespace BeltExam.ViewModels;

public class CouponsPageViewModel
{
    public User? User { get; set; }
    public List<Coupon> Coupons { get; set; } = [];
}
