using airtel.Model;
using Microsoft.EntityFrameworkCore;

namespace airtel.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Packs> packs { get; set; }
        
        public DbSet<User> user { get; set; }

    }
}