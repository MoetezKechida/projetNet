using projetNet.Models;
using projetNet.Repositories;
using projetNet.Repositories.Repositories;
using projetNet.Services.ServiceContracts;

namespace projetNet.Services.Services;

public class OfferService : IOfferService
{
    private readonly IOfferRepository _offerRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IAuditLogRepository _auditLogRepository;

    public OfferService(
        IOfferRepository offerRepository, 
        IVehicleRepository vehicleRepository,
        IAuditLogRepository auditLogRepository)
    {
        _offerRepository = offerRepository;
        _vehicleRepository = vehicleRepository;
        _auditLogRepository = auditLogRepository;
    }

    public async Task<Offer?> GetByIdAsync(Guid id)
    {
        return await _offerRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Offer>> GetAllAsync()
    {
        return await _offerRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Offer>> GetBySellerIdAsync(string sellerId)
    {
        return await _offerRepository.GetBySellerIdAsync(sellerId);
    }

    public async Task<IEnumerable<Offer>> GetActiveOffersAsync()
    {
        return await _offerRepository.GetActiveOffersAsync();
    }

    public async Task<IEnumerable<Offer>> SearchAsync(string? type, decimal? minPrice, decimal? maxPrice, string? status)
    {
        return await _offerRepository.SearchAsync(type, minPrice, maxPrice, status);
    }

    public async Task<Offer> CreateAsync(Offer offer)
    {
        // Validate vehicle exists
        var vehicleExists = await _vehicleRepository.ExistsAsync(offer.VehicleId);
        if (!vehicleExists)
        {
            throw new KeyNotFoundException($"Vehicle with ID {offer.VehicleId} not found.");
        }

        // Validate price
        if (offer.Price <= 0)
        {
            throw new ArgumentException("Price must be greater than zero.");
        }

        // Validate type
        if (offer.Type != "Sale" && offer.Type != "Rent")
        {
            throw new ArgumentException("Type must be either 'Sale' or 'Rent'.");
        }

        offer.Status = "Active";
        var result = await _offerRepository.AddAsync(offer);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = offer.SellerId,
            Action = "Create Offer",
            EntityType = "Offer",
            Timestamp = DateTime.UtcNow
        });

        return result;
    }

    public async Task UpdateAsync(Offer offer)
    {
        await _offerRepository.UpdateAsync(offer);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = offer.SellerId,
            Action = "Update Offer",
            EntityType = "Offer",
            Timestamp = DateTime.UtcNow
        });
    }

    public async Task DeleteAsync(Guid id)
    {
        var offer = await _offerRepository.GetByIdAsync(id);
        if (offer == null)
        {
            throw new KeyNotFoundException($"Offer with ID {id} not found.");
        }

        await _offerRepository.DeleteAsync(id);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = offer.SellerId,
            Action = "Delete Offer",
            EntityType = "Offer",
            Timestamp = DateTime.UtcNow
        });
    }

    public async Task ChangeStatusAsync(Guid id, string status)
    {
        var offer = await _offerRepository.GetByIdAsync(id);
        if (offer == null)
        {
            throw new KeyNotFoundException($"Offer with ID {id} not found.");
        }

        offer.Status = status;
        await _offerRepository.UpdateAsync(offer);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = offer.SellerId,
            Action = $"Change Offer Status to {status}",
            EntityType = "Offer",
            Timestamp = DateTime.UtcNow
        });
    }
}
