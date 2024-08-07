using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using ChefsNDishes.Context;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class DishesController : Controller
    {
        private readonly ApplicationContext _context;

        public DishesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("dishes")]
        public ViewResult Dishes()
        {
            var chefs = _context.Chefs.ToList();
            ViewBag.Chefs = chefs;

            var dishes = _context.Dishes
                .Include(d => d.Chef)
                .ToList();
            var dishesPageViewModel = new DishesPageViewModel()
            {
                Dish = new Dishes(),
                Dishes = dishes,
            };
            return View("Dishes", dishesPageViewModel);
        }

        [HttpPost("dishes/create")]
        public IActionResult CreateDish(Dishes newDish)
        {
            if (!ModelState.IsValid)
            {
                var chefs = _context.Chefs.ToList();
                ViewBag.Chefs = chefs;

                var dishes = _context.Dishes
                    .Include(d => d.Chef)
                    .ToList();
                var dishesPageViewModel = new DishesPageViewModel()
                {
                    Dish = new Dishes(),
                    Dishes = dishes,
                };

                return View("Dishes", dishesPageViewModel);
            }

            _context.Dishes.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }

        [HttpGet("dishes/{dishesId:int}")]
        public IActionResult DishesDetail(int dishesId)
        {
            var dish = _context.Dishes
                .Include(d => d.Chef)
                .FirstOrDefault(d => d.DishesId == dishesId);

            if (dish is null)
            {
                return NotFound();
            }

            return View("DishesDetails", dish);
        }
    }
}
