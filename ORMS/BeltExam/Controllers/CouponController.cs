#pragma warning disable CS8629 // Nullable value type may be null.
using BeltExam.Attributes;
using BeltExam.Context;
using BeltExam.Models;
using BeltExam.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BeltExam.Controllers;
public class CouponController : Controller
{
    private readonly ApplicationContext _context;

    public CouponController(ApplicationContext context)
    {
        _context = context;
    }

    [SessionCheck]
    [HttpGet("coupons")]
    public IActionResult Coupons(string? property)
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

        if (user is null)
        {
            return RedirectToAction("Index");
        }

        var viewModel = new CouponsPageViewModel
        {
            User = user,
            Coupons = GetSearchedCoupons(property ?? "CreatedAt")
        };

        return View("Coupons", viewModel);
    }

    [HttpPost("coupons/search")]
    public RedirectToActionResult SearchCoupons(string property)
    {
        return RedirectToAction("Coupons", new { property });
    }

    private List<Coupon> GetSearchedCoupons(string property)
    {
        return property switch
        {
            "Expiration" => _context.Coupons
                            .Include(c => c.Search)
                            .ThenInclude(s => s.User)
                            .OrderBy(c => c.Expiration)
                            .ToList(),
            _ => _context.Coupons
                            .Include(c => c.Search)
                            .ThenInclude(s => s.User)
                            .OrderBy(c => c.CreatedAt)
                            .ToList(),
        };
    }

    [SessionCheck]
    [HttpGet("coupons/new")]
    public ViewResult NewCoupon()
    {
        var coupon = new Coupon
        {
            UserId = (int)HttpContext.Session.GetInt32("userId"),
        };

        Console.WriteLine("````````````````T3````````````````");
        return View("NewCoupon", coupon);
    }

    [SessionCheck]
    [HttpPost("coupons/create")]
    public IActionResult CreateCoupon(Coupon newCoupon)
    {
        if (!ModelState.IsValid)
        {
            var coupon = new Coupon
            {
                UserId = (int)HttpContext.Session.GetInt32("userId"),
            };


            return View("NewCoupon", coupon);
        }

        Console.WriteLine("````````````````T4````````````````");
        _context.Coupons.Add(newCoupon);
        _context.SaveChanges();
        return RedirectToAction("Coupons");
    }

    [SessionCheck]
    [HttpGet("coupons/{couponId:int}")]
    public IActionResult CouponDetails(int couponId)
    {
        var coupon = _context.Coupons
            .Include(c => c.Search)
            .ThenInclude(s => s.User)
            .FirstOrDefault(c => c.CouponId == couponId);

        if (coupon is null)
        {
            return NotFound();
        }
        var UsersCount = coupon.UsedCoupon();
        ViewBag.UsersCount = UsersCount;
        var viewModel = new CouponDetailsViewModel
        {
            UserId = (int)HttpContext.Session.GetInt32("userId"),
            Coupon = coupon,
            Search = new Search
            {
                UserId = (int)HttpContext.Session.GetInt32("userId"),
                CouponId = couponId,
            }
        };

        return View("CouponDetails", viewModel);
    }


    [SessionCheck]
    [HttpPost("coupons/{couponId:int}/markused")]
    public IActionResult IsUsed(int couponId)
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        var search = new Search
        {
            CouponId = couponId,
            UserId = (int)userId
        };

        _context.Searches.Add(search);
        _context.SaveChanges();


        return RedirectToAction("Coupons", new { couponId });
    }

    [SessionCheck]
    [HttpPost("coupons/{couponId:int}/markexpired")]
    public IActionResult MarkExpired(int couponId)
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        var existingSearch = _context.Searches.FirstOrDefault(s => s.CouponId == couponId && s.UserId == userId);

        if (existingSearch != null)
        {
            _context.Searches.Remove(existingSearch);
            _context.SaveChanges();
        }

        return RedirectToAction("Coupons");
    }

    [SessionCheck]
    [HttpPost("coupons/{couponId:int}/search")]
    public IActionResult Search(int couponId)
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        var search = new Search
        {
            CouponId = couponId,
            UserId = (int)userId
        };

        _context.Searches.Add(search);
        _context.SaveChanges();

        return RedirectToAction("Coupons");
    }

    [SessionCheck]
    [HttpGet("coupons/{couponId:int}/edit")]
    public IActionResult EditCoupon(int couponId)
    {
        var coupon = _context.Coupons.FirstOrDefault(c => c.CouponId == couponId);

        if (coupon is null)
        {
            return NotFound();
        }

        return View("EditCoupon", coupon);
    }

    [SessionCheck]
    [HttpPost("coupons/{couponId:int}/update")]
    public IActionResult UpdateCoupon(int couponId, Coupon updatedCoupon)
    {
        var existingCoupon = _context.Coupons.FirstOrDefault(c => c.CouponId == couponId);
        if (existingCoupon is null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View("EditCoupon", updatedCoupon);
        }

        existingCoupon.CouponCode = updatedCoupon.CouponCode;
        existingCoupon.Website = updatedCoupon.Website;
        existingCoupon.Expiration = updatedCoupon.Expiration;
        existingCoupon.Description = updatedCoupon.Description;
        existingCoupon.UpdatedAt = updatedCoupon.UpdatedAt;

        _context.SaveChanges();
        return RedirectToAction("CouponDetails", new { couponId });
    }


}

