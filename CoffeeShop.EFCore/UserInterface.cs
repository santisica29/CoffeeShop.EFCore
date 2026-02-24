using Spectre.Console;

namespace CoffeeShop.EFCore;
public static class UserInterface
{
    public static void ShowProductsTable(List<Product> products)
    {
        Table table = new();   
        table.AddColumns("Id", "Name", "Price");

        foreach (Product product in products)
        {
            table.AddRow(product.Id.ToString(), product.Name, product.Price.ToString());
        }

        AnsiConsole.Write(table);

        AnsiConsole.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
    }

    internal static void ShowProduct(Product? product)
    {
        Panel panel = new(@$"Id: {product.Id}
Name: {product.Name}
Price: { product.Price}");
        panel.Header = new("Product Info");
        panel.Padding = new(2);

        AnsiConsole.Write(panel);

        AnsiConsole.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
    }
}
