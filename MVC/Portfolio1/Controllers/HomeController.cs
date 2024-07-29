using Microsoft.AspNetCore.Mvc;

namespace Portfolio1.Controllers;

public class HomeController : Controller
{
    // attribute
    [HttpGet("")]

    // action method 
    public string Index()
    {
        return "This is my Index!";
    }

    // attribute
    [HttpGet("projects")]

    // action method 
    public string Projects()
    {
        return "These are my projects!";
    }

    // attribute
    [HttpGet("contact")]

    // action method 
    public string Contact()
    {
        return "This is my contact!";
    }

}