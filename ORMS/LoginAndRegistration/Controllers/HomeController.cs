using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;
using LoginAndRegistration.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using LoginAndRegistration.Attributes;

namespace LoginAndRegistration.Controllers
{
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

            var homeView = new HomeView
            {
                User = new User(),
                Login = new Login()
            };

            return View("Index", homeView);
        }

        [HttpPost("registration")]
        public IActionResult Registration(User newUser)
        {
            if (!ModelState.IsValid)
            {
                var homeView = new HomeView
                {
                    User = new User(),
                    Login = new Login()
                };
                return View("Index", homeView);
            }

            var hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            _context.Users.Add(newUser);
            _context.SaveChanges();

            HttpContext.Session.SetInt32("userId", newUser.UserId);

            return RedirectToAction("Profile");
        }

        [HttpPost("login")]
        public IActionResult Login(Login Login)
        {
            if (!ModelState.IsValid)
            {
                var homeView = new HomeView
                {
                    User = new User(),
                    Login = new Login()
                };
                return View("Index", homeView);
            }

            var user = _context.Users.SingleOrDefault(u => u.Email == Login.Email);

            if (user is null)
            {
                return RedirectToAction("Index", new { message = "invalid-credentials" });
            }

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.Password, Login.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return RedirectToAction("Index", new { message = "invalid-credentials" });
            }

            HttpContext.Session.SetInt32("userId", user.UserId);

            return RedirectToAction("Profile");
        }

        [SessionCheck]
        [HttpGet("Profile")]
        public IActionResult Profile()
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

            return View("Profile", user);
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
}
