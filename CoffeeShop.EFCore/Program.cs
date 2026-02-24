using CoffeeShop.EFCore;
using Spectre.Console;

var isAppRunning = true;

while (isAppRunning)
{
    var option = AnsiConsole.Prompt(
    new SelectionPrompt<MenuOptions>()
    .Title("What would you like to do?")
    .AddChoices(Enum.GetValues<MenuOptions>()));

    switch (option)
    {
        case MenuOptions.AddProduct:
            string name = AnsiConsole.Ask<string>("Product's name: ");
            ProductController.AddProduct(name);
            break;
        case MenuOptions.DeleteProduct:
            ProductController.DeleteProduct();
            break;
        case MenuOptions.UpdateProduct:
            ProductController.UpdateProduct();
            break;
        case MenuOptions.ViewProduct:
            var id = ProductService.SelectProductId();
            var product = ProductController.ViewProduct(id);
            UserInterface.ShowProduct(product);
            break;
        case MenuOptions.ViewAllProducts:
            var products = ProductController.ViewAllProducts();
            UserInterface.ShowProductsTable(products);
            break;
        case MenuOptions.Quit:
            isAppRunning = false;
            break;
    }
}

enum MenuOptions
{
    AddProduct,
    DeleteProduct,
    UpdateProduct,
    ViewProduct,
    ViewAllProducts,
    Quit
}