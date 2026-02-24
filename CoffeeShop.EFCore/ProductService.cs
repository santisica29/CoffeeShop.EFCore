using Spectre.Console;

namespace CoffeeShop.EFCore;
internal class ProductService
{
    internal static int SelectProductId()
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
