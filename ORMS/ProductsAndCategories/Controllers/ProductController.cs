using ProductsAndCategories.Context;
using ProductsAndCategories.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductsAndCategories.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationContext _context;

    public ProductController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("products")]
    public ViewResult Products()
    {
        var products = _context.Products.ToList();
        var productsPageViewModel = new ProductsPageViewModel()
        {
            Product = new Product(),
            Products = products,
        };

        return View("Products", productsPageViewModel);
    }

    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        // if (!ModelState.IsValid)
        // {
        //     var message = string.Join(" | ", ModelState.Values
        //         .SelectMany(v => v.Errors)
        //         .Select(e => e.ErrorMessage));
        //     Console.WriteLine(message);
        // }
        if (!ModelState.IsValid)
        {
            var products = _context.Products.ToList();
            var productsPageViewModel = new ProductsPageViewModel()
            {
                Product = new Product(),
                Products = products,
            };

            return View("Products", productsPageViewModel);
        }

        _context.Products.Add(newProduct);
        _context.SaveChanges();
        return RedirectToAction("Products");
    }
}
