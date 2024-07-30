using Microsoft.AspNetCore.Mvc;
namespace Portfolio2.Controllers;


public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
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
