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
        var seller1 = new ApplicationUser { Id = "owner1", UserName = "seller1", FirstName = "Jean", LastName = "Dupont", IsVerifiedSeller = true };
        var seller2 = new ApplicationUser { Id = "owner2", UserName = "seller2", FirstName = "Marie", LastName = "Curie", IsVerifiedSeller = false };
        var seller3 = new ApplicationUser { Id = "owner3", UserName = "seller3", FirstName = "Ali", LastName = "Ben Salah", IsVerifiedSeller = true };
        var seller4 = new ApplicationUser { Id = "owner4", UserName = "seller4", FirstName = "Sophie", LastName = "Martin", IsVerifiedSeller = true };
        var seller5 = new ApplicationUser { Id = "owner5", UserName = "seller5", FirstName = "David", LastName = "Smith", IsVerifiedSeller = false };
        var seller6 = new ApplicationUser { Id = "owner6", UserName = "seller6", FirstName = "Fatima", LastName = "El Amrani", IsVerifiedSeller = true };

        var v1 = new Vehicle { Id = Guid.NewGuid(), Vin = "VIN1234567890", Brand = "Toyota", Model = "Corolla", Year = 2022, OwnerId = seller1.Id, ImageUrl = "https://images.unsplash.com/photo-1511918984145-48bbd2aa2d4c?auto=format&fit=crop&w=400&q=80", Price = 15000, Description = "Reliable sedan, low mileage.", Mileage = 12000, Location = "Paris" };
        var v2 = new Vehicle { Id = Guid.NewGuid(), Vin = "VIN0987654321", Brand = "BMW", Model = "X5", Year = 2021, OwnerId = seller2.Id, ImageUrl = "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d?auto=format&fit=crop&w=400&q=80", Price = 35000, Description = "Luxury SUV, fully loaded.", Mileage = 8000, Location = "Lyon" };
        var v3 = new Vehicle { Id = Guid.NewGuid(), Vin = "VIN1122334455", Brand = "Renault", Model = "Clio", Year = 2020, OwnerId = seller3.Id, ImageUrl = "https://images.unsplash.com/photo-1461632830798-3adb3034e4c8?auto=format&fit=crop&w=400&q=80", Price = 9000, Description = "Compact city car, economical.", Mileage = 20000, Location = "Marseille" };
        var v4 = new Vehicle { Id = Guid.NewGuid(), Vin = "VIN5566778899", Brand = "Peugeot", Model = "208", Year = 2023, OwnerId = seller4.Id, ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=400&q=80", Price = 12000, Description = "Brand new, perfect for city driving.", Mileage = 500, Location = "Nice" };
        var v5 = new Vehicle { Id = Guid.NewGuid(), Vin = "VIN9988776655", Brand = "Mercedes", Model = "C-Class", Year = 2019, OwnerId = seller5.Id, ImageUrl = "https://images.unsplash.com/photo-1502877336888-7bfc88a5e4a0?auto=format&fit=crop&w=400&q=80", Price = 25000, Description = "Elegant and comfortable, well maintained.", Mileage = 30000, Location = "Bordeaux" };
        var v6 = new Vehicle { Id = Guid.NewGuid(), Vin = "VIN4455667788", Brand = "Volkswagen", Model = "Golf", Year = 2021, OwnerId = seller6.Id, ImageUrl = "https://images.unsplash.com/photo-1519643381400-7f7c7d3e0c44?auto=format&fit=crop&w=400&q=80", Price = 14000, Description = "Popular hatchback, great for families.", Mileage = 15000, Location = "Toulouse" };

        modelBuilder.Entity<ApplicationUser>().HasData(seller1, seller2, seller3, seller4, seller5, seller6);
        modelBuilder.Entity<Vehicle>().HasData(v1, v2, v3, v4, v5, v6);

        modelBuilder.Entity<Offer>().HasData(
            new Offer { Id = Guid.NewGuid(), Type = "Sale", Price = v1.Price ?? 15000, Status = "accepted", VehicleId = v1.Id, SellerId = seller1.Id },
            new Offer { Id = Guid.NewGuid(), Type = "Rent", Price = 120, Status = "accepted", VehicleId = v2.Id, SellerId = seller2.Id },
            new Offer { Id = Guid.NewGuid(), Type = "Sale", Price = v3.Price ?? 9000, Status = "accepted", VehicleId = v3.Id, SellerId = seller3.Id },
            new Offer { Id = Guid.NewGuid(), Type = "Rent", Price = 80, Status = "accepted", VehicleId = v4.Id, SellerId = seller4.Id },
            new Offer { Id = Guid.NewGuid(), Type = "Sale", Price = v5.Price ?? 25000, Status = "accepted", VehicleId = v5.Id, SellerId = seller5.Id },
            new Offer { Id = Guid.NewGuid(), Type = "Rent", Price = 100, Status = "accepted", VehicleId = v6.Id, SellerId = seller6.Id },
            // Add some rejected offers for realism
            new Offer { Id = Guid.NewGuid(), Type = "Sale", Price = 8000, Status = "rejected", VehicleId = v3.Id, SellerId = seller3.Id },
            new Offer { Id = Guid.NewGuid(), Type = "Rent", Price = 60, Status = "pending", VehicleId = v4.Id, SellerId = seller4.Id }
        );
    }
 
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<Offer> Offers { get; set; } = null!;
    public DbSet<Inspection> Inspections { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;
    public DbSet<VehiculeSale> VehiculeSales { get; set; } = null!;
}
