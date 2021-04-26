using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WNWN.Models;

namespace WNWN.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<FoodGroup> Groups { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
        }
    }
}
