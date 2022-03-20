using ASPNET6Tutorial.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPNET6Tutorial.DbContexts
{
    public class CityInfoContext : DbContext
    {
        // Warnings for nullable can be ignored as DbContexts make sure that everything runs fine
        public DbSet<City> Cities { get; set; }  = null!;
        public DbSet<PointOfInterest> PointOfInterest { get; set; }  = null!;

        public CityInfoContext (DbContextOptions<CityInfoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                    new City("Test city 1")
                    {
                        Id = 1,
                        Description = "Description"
                    },
                    new City("Test city 2")
                    {
                        Id = 2,
                        Description = "Description"
                    }
                );
            modelBuilder.Entity<PointOfInterest>().HasData(
                    new PointOfInterest("Point of interest 1")
                    {
                        Id = 1,
                        CityId = 1,
                        Description = "Description"
                    },
                    new PointOfInterest("Point of interest 2")
                    {
                        Id = 2,
                        CityId = 2,
                        Description = "Description"
                    }
                );
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
