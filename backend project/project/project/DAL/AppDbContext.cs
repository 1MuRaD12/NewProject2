using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>()
                .HasIndex(u => u.Key)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
       public DbSet<Setting> settings { get; set; }
       public DbSet<Details> details { get; set; }
       public DbSet<Information> Information { get; set; }
        public DbSet<Slider> sliders { get; set; }
    }
}
