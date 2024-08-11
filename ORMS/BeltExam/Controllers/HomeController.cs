using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using BeltExam.Context;
using BeltExam.ViewModels;
using BeltExam.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ApplicationContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index(string? message)
    {
        ViewBag.Message = message;
        Console.WriteLine("````````````````T1````````````````");
        var homePageViewModel = new HomePageViewModel()
        {
            User = new User(),
            LoginUser = new LoginUser(),
        };

        return View("Index", homePageViewModel);
    }

    [HttpPost("register")]
    public IActionResult Register(User newUser)
    {
        if (!ModelState.IsValid)
        {
            var homePageViewModel = new HomePageViewModel()
            {
                User = new User(),
                LoginUser = new LoginUser(),
            };
            return View("Index", homePageViewModel);
        }

        var hasher = new PasswordHasher<User>();
        newUser.Password = hasher.HashPassword(newUser, newUser.Password);

        _context.Users.Add(newUser);
        _context.SaveChanges();

        HttpContext.Session.SetInt32("userId", newUser.UserId);


        return RedirectToAction("Coupons", "Coupon");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (!ModelState.IsValid)
        {
            var homePageViewModel = new HomePageViewModel()
            {
                User = new User(),
                LoginUser = new LoginUser(),
            };
            return View("Index", homePageViewModel);
        }

        var user = _context.Users.SingleOrDefault((user) => user.Email == loginUser.Email);

        if (user is null)
        {
            return RedirectToAction("Index", new { message = "invalid-credentials" });
        }

        var hasher = new PasswordHasher<User>();

        PasswordVerificationResult result = hasher.VerifyHashedPassword(
            user,
            user.Password,
            loginUser.Password
        );

        if (result == 0)
        {
            return RedirectToAction("Index", new { message = "invalid-credentials" });
        }

        HttpContext.Session.SetInt32("userId", user.UserId);

        return RedirectToAction("Coupons", "Coupon");
    }
    [SessionCheck]
    [HttpGet("account")]
    public IActionResult Account()
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        var user = _context.Users
            .Include(u => u.Coupons)
            .ThenInclude(c => c.Search)
            .FirstOrDefault(u => u.UserId == userId);

        if (user is null)
        {
            return RedirectToAction("Index");
        }

        var viewModel = new AccountViewModel
        {
            User = user,
            PostedCount = user.Coupons.Count,
            UserCouponUses = user.Coupons.Count(c => c.Search.Any(s => s.UserId == user.UserId)),
            UsedCount = user.Coupons.Sum(c => c.Search.Count)
        };

        return View("Account", viewModel);
    }


    [HttpGet("logout")]
    public RedirectToActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
