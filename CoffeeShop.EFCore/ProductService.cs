using Spectre.Console;

namespace CoffeeShop.EFCore;
internal class ProductService
{
    internal static void DeleteProduct()
    {
        int id = SelectProductId();
        var product = ProductController.ViewProduct(id);
        ProductController.DeleteProduct(product);
    }

    internal static void UpdateProduct()
    {
        int id = SelectProductId();
        var product = ProductController.ViewProduct(id);

        product.Name = AnsiConsole.Confirm("Update the name?") 
            ? AnsiConsole.Ask<string>("Product's new name: ")
            : product.Name;

        product.Price = AnsiConsole.Confirm("Update the price?")
            ? AnsiConsole.Ask<decimal>("Product's new price")
            : product.Price;

        ProductController.UpdateProduct(product);
    }

    internal static void GetAllProducts()
    {
        var products = ProductController.ViewAllProducts();
        UserInterface.ShowProductsTable(products);
    }

    internal static void GetProduct()
    {
        var id = SelectProductId();
        var product = ProductController.ViewProduct(id);
        UserInterface.ShowProduct(product);
    }

    internal static void InsertProduct()
    {
        string name = AnsiConsole.Ask<string>("Product's name: ");
        decimal price = AnsiConsole.Ask<decimal>("Product's price: ");
        Product newProduct = new() { Name = name, Price = price };
        ProductController.AddProduct(newProduct);
    }
    private static int SelectProductId()
    {
        var list = ProductController.ViewAllProducts();
        var products = list.Select(p => p.Name).ToArray();

        var optionName = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose a product")
            .AddChoices(products));

        var id = list.Single(x => x.Name == optionName).Id;

        return id;
    }
}
