using BackendTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTask.DataAccess.Context
{
    public class AppDb : DbContext
    {
        public AppDb()
        {
        }
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);
        }
    }
}
