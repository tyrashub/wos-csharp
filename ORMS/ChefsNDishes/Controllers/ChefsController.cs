using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Context;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class ChefsController : Controller
    {
        private readonly ApplicationContext _context;

        public ChefsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("chefs")]
        public ViewResult Chefs()
        {
            var chefs = _context.Chefs
                .Include(c => c.Dishes)
                .ToList();
            var chefsPageViewModel = new ChefsPageViewModel()
            {
                Chef = new Chef(),
                Chefs = chefs,
            };

            return View("Chefs", chefsPageViewModel);
        }

        [HttpPost("chefs/create")]
        public IActionResult CreateChef(Chef newChef)
        {
            if (!ModelState.IsValid)
            {
                var chefs = _context.Chefs
                    .Include(c => c.Dishes)
                    .ToList();
                var chefsPageViewModel = new ChefsPageViewModel()
                {
                    Chef = new Chef(),
                    Chefs = chefs,
                };

                return View("Chefs", chefsPageViewModel);
            }

            _context.Chefs.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Chefs");
        }
    }
}
