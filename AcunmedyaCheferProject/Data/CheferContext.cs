using AcunmedyaCheferProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcunmedyaCheferProject.Data
{
    public class CheferContext : DbContext
    {
        public CheferContext(DbContextOptions<CheferContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
