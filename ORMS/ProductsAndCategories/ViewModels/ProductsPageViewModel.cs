namespace ProductsAndCategories.Models;

public class ProductsPageViewModel
{
    public Product? Product { get; set; }
    public List<Product> Products { get; set; } = [];
}
