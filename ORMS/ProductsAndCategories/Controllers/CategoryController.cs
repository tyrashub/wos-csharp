using ProductsAndCategories.Context;
using ProductsAndCategories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationContext _context;

    public CategoryController(ApplicationContext context)
    {
        _context = context;
    }


    [HttpGet("categories")]
    public ViewResult Categories()
    {
        var categories = _context.Categories.ToList();
        var categoriesPageViewModel = new CategoriesPageViewModel()
        {
            Category = new Category(),
            Categories = categories,
        };

        return View("Categories", categoriesPageViewModel);
    }

    [HttpPost("categories/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        // if (!ModelState.IsValid)
        // {
        //     var message = string.Join(" | ", ModelState.Values
        //         .SelectMany(v => v.Errors)
        //         .Select(e => e.ErrorMessage));
        //     Console.WriteLine(message);
        // }
        Console.WriteLine("~~~~~~~~~~~~~TEST1~~~~~~~~~");
        if (!ModelState.IsValid)
        {
            Console.WriteLine("~~~~~~~~~~~~~TEST2~~~~~~~~~");
            var categories = _context.Categories.ToList();
            var categoriesPageViewModel = new CategoriesPageViewModel()
            {
                Category = new Category(),
                Categories = categories,
            };

            return View("Categories", categoriesPageViewModel);
        }
        Console.WriteLine("~~~~~~~~~~~~~TEST~~~~~~~~~");
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
        return RedirectToAction("Categories");
    }

    [HttpGet("categories/{categoryId:int}")]
    public IActionResult CategoryDetails(int categoryId)
    {
        var category = _context.Categories
            .Include((c) => c.AssociatedProducts)
            .ThenInclude((a) => a.Product)
            .FirstOrDefault((c) => c.CategoryId == categoryId);

        if (category is null)
        {
            return NotFound();
        }

        var unassociatedProducts = _context.Products
            .Where((p) => !p.AssociatedCategories.Any((a) => a.CategoryId == categoryId))
            .ToList();

        var viewModel = new CategoryDetailsPageViewModel()
        {
            Category = category,
            Association = new Association()
            {
                CategoryId = categoryId
            },
            Products = unassociatedProducts,
        };

        return View("CategoryDetails", viewModel);
    }

    [HttpPost("categories/add-product")]
    public IActionResult AddProductToCategory(int categoryId, int productId)
    {
        var newAssociation = new Association()
        {
            CategoryId = categoryId,
            ProductId = productId,
        };
        _context.Associations.Add(newAssociation);
        _context.SaveChanges();
        return RedirectToAction("CategoryDetails", new { categoryId });
    }

}
