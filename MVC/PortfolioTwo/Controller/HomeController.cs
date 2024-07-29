using Microsoft.AspNetCore.Mvc;
namespace PortfolioTwo.Controllers;


public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Home()
    {
        return View();
    }


    [HttpGet("myprojects")]
    public ViewResult MyProjects()
    {
        return View();
    }

    [HttpGet("contactme")]
    public ViewResult ContactMe()
    {
        return View();
    }


}
