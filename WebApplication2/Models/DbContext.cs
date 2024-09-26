using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
    {
        public class PointDbContext : DbContext
        {
            public PointDbContext(DbContextOptions<PointDbContext> options) : base(options)
            {
            }

            public DbSet<Point> Points { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                // Burada model konfigürasyonları yapılabilir
            }
        }
    }

