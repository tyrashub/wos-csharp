using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using CRUDelicious.Context;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationContext _context;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        var dishes = _context.Dishes.ToList();
        return View("Index", dishes);
    }


    [HttpGet("dishes/new")]
    public ViewResult NewDish()
    {
        return View("NewDish");
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dishes newDish)
    {
        if (!ModelState.IsValid)
        {
            return View("NewDish");
        }

        _context.Dishes.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("dishes/{dishesId:int}")]
    public IActionResult ShowDish(int dishesId)
    {
        var dish = _context.Dishes
            .FirstOrDefault(d => d.DishesId == dishesId);

        if (dish == null)
        {
            return RedirectToAction("DishNotFound");
        }
        return View("ShowDish", dish);
    }

    [HttpGet("dishes/{dishesId:int}/edit")]
    public IActionResult EditDish(int dishesId)
    {
        var dish = _context.Dishes
            .FirstOrDefault(d => d.DishesId == dishesId);

        if (dish == null)
        {
            return RedirectToAction("DishNotFound");
        }

        return View("EditDish", dish);
    }

    [HttpPost("dishes/{dishesId:int}/update")]
    public IActionResult UpdateDish(int dishesId, Dishes updatedDish)
    {
        var existingDish = _context.Dishes
            .FirstOrDefault(d => d.DishesId == dishesId);

        if (existingDish == null)
        {
            return RedirectToAction("DishNotFound");
        }

        existingDish.Name = updatedDish.Name;
        existingDish.Chef = updatedDish.Chef;
        existingDish.Tastiness = updatedDish.Tastiness;
        existingDish.Calories = updatedDish.Calories;
        existingDish.Description = updatedDish.Description;
        existingDish.UpdatedAt = DateTime.Now;

        _context.SaveChanges();
        return RedirectToAction("ShowDish", new { dishesId });
    }

    [HttpPost("dishes/{dishesId:int}/delete")]
    public IActionResult DeleteDish(int dishesId)
    {
        var existingDish = _context.Dishes
            .FirstOrDefault(d => d.DishesId == dishesId);

        if (existingDish == null)
        {
            return RedirectToAction("DishNotFound");
        }

        _context.Dishes.Remove(existingDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("/dishes/not-found")]
    public ViewResult DishNotFound()
    {
        return View("NotFound");
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
