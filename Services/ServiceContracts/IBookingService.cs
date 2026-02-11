using projetNet.Models;

namespace projetNet.Services.ServiceContracts;

public interface IBookingService
{
    Task<Booking?> GetByIdAsync(Guid id);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task<IEnumerable<Booking>> GetByBuyerIdAsync(string buyerId);
    Task<IEnumerable<Booking>> GetBySellerIdAsync(string sellerId);
    Task<IEnumerable<Booking>> GetByVehicleIdAsync(Guid vehicleId);
    Task<Booking> CreateBookingAsync(Guid vehicleId, string buyerId, string bookingType, DateTime? startDate, DateTime? endDate);
    Task DeleteBookingAsync(Guid id);
}
