using Spectre.Console;

namespace CoffeeShop.EFCore;

internal class ProductController
{
    internal static void AddProduct(string name)
    {
        using var db = new ProductContext();
        db.Add(new Product { Name = name });
        db.SaveChanges();
    }

    internal static void DeleteProduct()
    {
        throw new NotImplementedException();
    }

    internal static void UpdateProduct()
    {
        throw new NotImplementedException();
    }

    internal static List<Product> ViewAllProducts()
    {
        using var db = new ProductContext();
        List<Product> products = db.Products.ToList();

        return products;
    }

    internal static Product? ViewProduct(int id)
    {
        using var db = new ProductContext();

        Product? product = db.Products.SingleOrDefault(x => x.Id == id);

        return product;
    }
}
