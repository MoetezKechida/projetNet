using projetNet.Models;

namespace projetNet.Services;

public interface IOfferService
{
    Task<Offer?> GetByIdAsync(Guid id);
    Task<IEnumerable<Offer>> GetAllAsync();
    Task<IEnumerable<Offer>> GetBySellerIdAsync(string sellerId);
    Task<IEnumerable<Offer>> GetActiveOffersAsync();
    Task<IEnumerable<Offer>> SearchAsync(string? type, decimal? minPrice, decimal? maxPrice, string? status);
    Task<Offer> CreateAsync(Offer offer);
    Task UpdateAsync(Offer offer);
    Task DeleteAsync(Guid id);
    Task ChangeStatusAsync(Guid id, string status);
}
