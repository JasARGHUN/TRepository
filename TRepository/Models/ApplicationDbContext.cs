using Microsoft.EntityFrameworkCore;

namespace TRepository.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Item> Items { get; set; }
    }
}
