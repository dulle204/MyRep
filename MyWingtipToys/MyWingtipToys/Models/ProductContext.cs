using System.Data.Entity;


namespace MyWingtipToys.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(): base("MyWingtipToys")
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }    
}