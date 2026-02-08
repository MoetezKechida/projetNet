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
 
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<Offer> Offers { get; set; } = null!;
    public DbSet<Inspection> Inspections { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;
}
