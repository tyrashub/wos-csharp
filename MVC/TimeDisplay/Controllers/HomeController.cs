using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {

        DateTime currentTime = DateTime.Now;


        DateTime endTime = new(2024, 10, 4, 0, 0, 0);


        TimeSpan timeRemaining = endTime - currentTime;


        ViewBag.StartTime = currentTime.ToString("MMMM dd, yyyy hh:mm tt");
        ViewBag.EndTime = endTime.ToString("MMMM dd, yyyy hh:mm tt");
        ViewBag.TimeRemaining = string.Format("{0} Day(s), {1} Hour(s), {2} Minute(s) Remaining",
            timeRemaining.Days,
            timeRemaining.Hours,
            timeRemaining.Minutes);


        return View();
    }

}