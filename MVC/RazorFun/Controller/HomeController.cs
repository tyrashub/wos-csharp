using Microsoft.AspNetCore.Mvc;

namespace RazorFun.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }


}