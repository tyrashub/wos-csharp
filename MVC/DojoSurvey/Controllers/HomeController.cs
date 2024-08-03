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

    [HttpGet("")]
    public IActionResult Index()
    {

        return View("Index");
    }

    [HttpPost("results")]
    public ViewResult Results(Ninja ninja)
    {
        if (!ModelState.IsValid)
        {
            // the form is invalid
            _logger.LogInformation("The form is invalid.");
            return View("Index");
        }

        // the form is valid
        _logger.LogInformation("The form is valid");
        return View("Results", ninja);
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

