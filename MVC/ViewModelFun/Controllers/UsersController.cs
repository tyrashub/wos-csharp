using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;


namespace ViewModelFun.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            var model = new ViewModel
            {
                Users = new List<User>
                {
                    new User { Name = "Moose Phillips" },
                    new User { Name = "Sarah" },
                    new User { Name = "Jerry" },
                    new User { Name = "Rene Ricky" },
                    new User { Name = "Barbarah" }
                }
            };
            return View(model);
        }

        public IActionResult Details(string name)
        {
            var user = new User { Name = name };
            var model = new ViewModel
            {
                SelectedUser = user
            };
            return View(model);
        }
    }
}
