using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ViewModel
            {
                Message = "Lorem ipsum odor amet, consectetuer adipiscing elit. Inceptos condimentum pulvinar maximus accumsan primis orci ornare. Ac congue fermentum ultricies convallis mollis eleifend litora. Congue neque etiam interdum primis bibendum morbi torquent odio. Ultricies fames mi magnis netus blandit dis, magnis felis facilisis. Dui aliquet suspendisse nisi dapibus quam neque venenatis? Massa eu nostra sagittis faucibus taciti sapien. Augue class vel habitant mus pellentesque ac consequat mollis.Fames cursus quam vel mus nullam mattis nam. Volutpat placerat litora mattis rhoncus torquent facilisis vestibulum vulputate. Volutpat nam mus suspendisse nulla eros nisl faucibus lobortis netus. Hendrerit a venenatis ad efficitur libero non et. Habitasse laoreet laoreet porta ut pellentesque? Suscipit tristique ac nam placerat aliquet. Risus ridiculus conubia erat mauris senectus. Donec ex gravida platea varius; pellentesque fringilla lectus nam. Ultrices facilisis ridiculus est; elit lectus lacus. Afinibus mollis ultrices taciti venenatis magnis per. "
            };
            return View(model);
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
}
