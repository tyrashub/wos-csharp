using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class NumbersController : Controller
    {
        public IActionResult Index()
        {
            var model = new ViewModel
            {
                Numbers = new int[] { 1, 2, 3, 10, 43, 5 }
            };
            return View(model);
        }
    }
}
