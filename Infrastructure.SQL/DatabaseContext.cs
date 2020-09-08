using Heroes.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Hero>()
                .HasMany(h => h.Pets)
                .WithOne(p => p.Hero)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Hero> Heroes { get; set; }

    }
}