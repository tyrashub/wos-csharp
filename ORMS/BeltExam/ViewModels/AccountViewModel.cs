using BeltExam.Models;

namespace BeltExam.ViewModels;


public class AccountViewModel
{
    public User? User { get; set; }
    public int PostedCount { get; set; }
    public int UsedCount { get; set; }
    public int UserCouponUses { get; set; }
}