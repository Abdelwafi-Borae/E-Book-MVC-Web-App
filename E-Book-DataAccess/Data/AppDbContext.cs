using E_Book_Model;
using Microsoft.EntityFrameworkCore;

namespace E_Book_DataAccess.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Catogery> Catogeries { get; set; }
        public DbSet<Cover_type> Cover_Types { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
