using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projetNet.Models;

namespace projetNet.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle
            {
                Id = Guid.NewGuid(),
                Vin = "VIN1234567890",
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2022,
                OwnerId = "owner1",
                ImageUrl = "/images/cars/toyota_corolla.jpg",
                Price = 15000,
                Description = "Reliable sedan, low mileage.",
                Mileage = 12000,
                Location = "Paris"
            },
            new Vehicle
            {
                Id = Guid.NewGuid(),
                Vin = "VIN0987654321",
                Brand = "BMW",
                Model = "X5",
                Year = 2021,
                OwnerId = "owner2",
                ImageUrl = "/images/cars/bmw_x5.jpg",
                Price = 35000,
                Description = "Luxury SUV, fully loaded.",
                Mileage = 8000,
                Location = "Lyon"
            },
            new Vehicle
            {
                Id = Guid.NewGuid(),
                Vin = "VIN1122334455",
                Brand = "Renault",
                Model = "Clio",
                Year = 2020,
                OwnerId = "owner3",
                ImageUrl = "/images/cars/renault_clio.jpg",
                Price = 9000,
                Description = "Compact city car, economical.",
                Mileage = 20000,
                Location = "Marseille"
            }
        );
    }
 
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<Offer> Offers { get; set; } = null!;
    public DbSet<Inspection> Inspections { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;
}
