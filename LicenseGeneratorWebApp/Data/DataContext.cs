using Microsoft.EntityFrameworkCore;


namespace LicenseGeneratorWebApp.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
         
        //to see an entity in your database as a table
        public DbSet<ProductList> Products { get; set; }

    }
}
