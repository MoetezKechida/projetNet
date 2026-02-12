using projetNet.Exceptions;
using projetNet.Models;
using projetNet.Repositories;
using projetNet.Repositories.Repositories;
using projetNet.Repositories.RepositoryContracts;
using projetNet.Services.ServiceContracts;

namespace projetNet.Services.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IAuditLogRepository _auditLogRepository;

    public BookingService(
        IBookingRepository bookingRepository,
        IVehicleRepository vehicleRepository,
        IAuditLogRepository auditLogRepository)
    {
        _bookingRepository = bookingRepository;
        _vehicleRepository = vehicleRepository;
        _auditLogRepository = auditLogRepository;
    }

    public async Task<Booking?> GetByIdAsync(Guid id)
    {
        return await _bookingRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _bookingRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Booking>> GetByBuyerIdAsync(string buyerId)
    {
        return await _bookingRepository.GetByBuyerIdAsync(buyerId);
    }

    public async Task<IEnumerable<Booking>> GetBySellerIdAsync(string sellerId)
    {
        return await _bookingRepository.GetBySellerIdAsync(sellerId);
    }

    public async Task<IEnumerable<Booking>> GetByVehicleIdAsync(Guid vehicleId)
    {
        return await _bookingRepository.GetByVehicleIdAsync(vehicleId);
    }

    public async Task<Booking> CreateBookingAsync(Guid vehicleId, string buyerId, string bookingType, DateTime? startDate, DateTime? endDate)
    {
        // Validate vehicle exists
        var vehicle = await _vehicleRepository.GetByIdAsync(vehicleId);
        if (vehicle == null)
        {
            throw new NotFoundException($"Vehicle with ID {vehicleId} not found");
        }

        

        // Calculate total amount
        decimal totalAmount = 0;
        
        if (bookingType == "Rent")
        {
            if (!vehicle.RentalPrice.HasValue)
            {
                throw new InvalidOperationException("Vehicle is not available for rent");
            }
            
            if (!startDate.HasValue || !endDate.HasValue)
            {
                throw new InvalidOperationException("Start date and end date are required for rental bookings");
            }
            
            var days = (endDate.Value - startDate.Value).Days;
            if (days <= 0)
            {
                throw new InvalidOperationException("End date must be after start date");
            }
            totalAmount = vehicle.RentalPrice.Value * days;
        }
        else if (bookingType == "Buy")
        {
            if (!vehicle.Price.HasValue)
            {
                throw new InvalidOperationException("Vehicle is not available for purchase");
            }
            totalAmount = vehicle.Price.Value;
        }
        else
        {
            throw new InvalidOperationException("Invalid booking type. Must be 'Buy' or 'Rent'");
        }

        // Create booking
        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            VehicleId = vehicleId,
            BuyerId = buyerId,
            BookingType = bookingType,
            StartDate = startDate ?? DateTime.Now,
            EndDate = endDate ?? DateTime.Now,
            TotalAmount = totalAmount
        };

        var createdBooking = await _bookingRepository.AddAsync(booking);

        // Log audit
        await _auditLogRepository.AddAsync(new AuditLog
        {
            Action = "CreateBooking",
            Timestamp = DateTime.UtcNow,
            UserId = buyerId,
            EntityType = "Booking"
        });

        return createdBooking;
    }

    public async Task DeleteBookingAsync(Guid id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);
        if (booking == null)
        {
            throw new NotFoundException($"Booking with ID {id} not found");
        }

        await _bookingRepository.DeleteAsync(id);

        // Log audit
        await _auditLogRepository.AddAsync(new AuditLog
        {
            Action = "DeleteBooking",
            Timestamp = DateTime.UtcNow,
            UserId = booking.BuyerId,
            EntityType = "Booking"
        });
    }
}
