using Lima.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Lima.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
