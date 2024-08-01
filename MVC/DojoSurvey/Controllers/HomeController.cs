using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;
using System.Reflection.Metadata.Ecma335;

namespace DojoSurvey.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        return View();
    }
    [HttpPost("Result")]
    public IActionResult Result(string Name, string Dojo, string FavLang, string Message)
    {
        ViewBag.Name = Name;
        ViewBag.Dojo = Dojo;
        ViewBag.FavLang = FavLang;
        ViewBag.Message = Message;

        return View();
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
