using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int _count = 0;
        private static readonly Random _random = new();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        [HttpGet("")]
        public IActionResult Index()
        {

            {
                _count++;
                ViewBag.Count = _count;
            }

            ViewBag.Passcode = GeneratePasscode(14);
            return View("Index");
        }

        private string GeneratePasscode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var passcode = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                passcode.Append(chars[_random.Next(chars.Length)]);
            }
            return passcode.ToString();
        }
    }
}
