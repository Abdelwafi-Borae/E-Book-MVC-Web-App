using E_Book_Model;
using Microsoft.EntityFrameworkCore;

namespace E_BookWeb.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Catogery> Catogeries { get; set; }
    }
}
