using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.EFCore;
internal class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=CoffeeShop; Integrated Security=True;");
    }

}
