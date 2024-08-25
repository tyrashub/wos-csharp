#pragma warning disable CS8629 // Nullable value type may be null.
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoloProject.Context;
using SoloProject.Models;
using SoloProject.ViewModels;

namespace SoloProject.Controllers;

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
    public IActionResult Curator(string? message)
    {
        ViewBag.Message = message;
        Console.WriteLine("````````````````T1````````````````");
        var curatorPageViewModel = new CuratorPageViewModel()
        {
            User = new User(),
            LoginUser = new LoginUser(),
        };

        return View("Curator", curatorPageViewModel);
    }
    [HttpGet("index")]
    public IActionResult Index(string? message)
    {
        ViewBag.Message = message;
        Console.WriteLine("````````````````T1````````````````");
        var indexPageViewModel = new IndexPageViewModel()
        {
            User = new User(),
            LoginUser = new LoginUser(),
        };

        return View("Index", indexPageViewModel);
    }
    [HttpPost("register")]
    public IActionResult Register(User newUser)
    {
        if (!ModelState.IsValid)
        {
            var indexPageViewModel = new IndexPageViewModel()
            {
                User = new User(),
                LoginUser = new LoginUser()
            };
            return View("Index", indexPageViewModel);
        }

        var hasher = new PasswordHasher<User>();
        newUser.Password = hasher.HashPassword(newUser, newUser.Password);

        _context.Users.Add(newUser);
        _context.SaveChanges();

        HttpContext.Session.SetInt32("userId", newUser.UserId);

        return RedirectToAction("Collections", "Collection");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (!ModelState.IsValid)
        {
            var indexPageViewModel = new IndexPageViewModel()
            {
                User = new User(),
                LoginUser = new LoginUser(),
            };
            return View("Collections", indexPageViewModel);
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

        return RedirectToAction("Collections", "Collection");
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
