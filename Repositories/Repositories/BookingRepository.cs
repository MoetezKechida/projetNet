using Microsoft.EntityFrameworkCore;
using projetNet.Data;
using projetNet.Models;
using projetNet.Repositories.RepositoryContracts;

namespace projetNet.Repositories.Repositories;

public class BookingRepository : Repository<Booking>, IBookingRepository
{
    public BookingRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Booking>> GetByBuyerIdAsync(string buyerId)
    {
        return await _dbSet
            .Where(b => b.BuyerId == buyerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetBySellerIdAsync(string sellerId)
    {
        return await _dbSet
            .Join(_context.Vehicles,
                booking => booking.VehicleId,
                vehicle => vehicle.Id,
                (booking, vehicle) => new { booking, vehicle })
            .Where(bv => bv.vehicle.OwnerId == sellerId)
            .Select(bv => bv.booking)
            .ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetByVehicleIdAsync(Guid vehicleId)
    {
        return await _dbSet
            .Where(b => b.VehicleId == vehicleId)
            .ToListAsync();
    }
}
