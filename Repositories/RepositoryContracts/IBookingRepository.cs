using projetNet.Models;
using System.Linq.Expressions;

namespace projetNet.Repositories.RepositoryContracts;

public interface IBookingRepository : IRepository<Booking>
{
    Task<IEnumerable<Booking>> GetByBuyerIdAsync(string buyerId);
    Task<IEnumerable<Booking>> GetBySellerIdAsync(string sellerId);
    Task<IEnumerable<Booking>> GetByVehicleIdAsync(Guid vehicleId);
}
