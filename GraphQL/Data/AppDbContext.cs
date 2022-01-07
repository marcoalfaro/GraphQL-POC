using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Make>()
                .HasMany(c => c.Cars)
                .WithOne(m => m.Make!)
                .HasForeignKey(c => c.MakeId);
            
            modelBuilder
                .Entity<Car>()
                .HasOne(c => c.Make)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.MakeId);
        }
    }
}