using Microsoft.EntityFrameworkCore;
using NETDEMO_RAZOR.Models;

namespace NETDEMO_RAZOR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "KKR", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "SHR", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "RCB", DisplayOrder = 3 }
                );
        }

    }
}
