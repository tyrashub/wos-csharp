
namespace ProductsAndCategories.Models;

public class CategoryDetailsPageViewModel
{
    public Category? Category { get; set; }
    public Association? Association { get; set; }
    public List<Product> Products { get; set; } = [];
}
