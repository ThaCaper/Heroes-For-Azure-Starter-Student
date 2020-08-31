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

            modelBuilder.Entity<Pet>()
                .HasKey(p => new {p.Id});

            modelBuilder.Entity<Hero>()
                .HasKey(h => new {h.Id});

            modelBuilder.Entity<Hero>()
                .HasMany<Pet>()
                .WithOne(h => h.Hero);
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Hero> Heroes { get; set; }

    }
}