using Microsoft.EntityFrameworkCore;
using projetNet.Data;
using projetNet.Models;

namespace projetNet.Repositories;

public interface IOfferRepository : IRepository<Offer>
{
    Task<IEnumerable<Offer>> GetBySellerIdAsync(string sellerId);
    Task<IEnumerable<Offer>> GetActiveOffersAsync();
    Task<IEnumerable<Offer>> SearchAsync(string? type, decimal? minPrice, decimal? maxPrice, string? status);
}

public class OfferRepository : Repository<Offer>, IOfferRepository
{
    public OfferRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Offer>> GetBySellerIdAsync(string sellerId)
    {
        return await _dbSet
            .Where(o => o.SellerId == sellerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Offer>> GetActiveOffersAsync()
    {
        return await _dbSet
            .Where(o => o.Status == "Active")
            .ToListAsync();
    }

    public async Task<IEnumerable<Offer>> SearchAsync(string? type, decimal? minPrice, decimal? maxPrice, string? status)
    {
        var query = _dbSet.AsQueryable();

        if (!string.IsNullOrEmpty(type))
            query = query.Where(o => o.Type == type);

        if (minPrice.HasValue)
            query = query.Where(o => o.Price >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(o => o.Price <= maxPrice.Value);

        if (!string.IsNullOrEmpty(status))
            query = query.Where(o => o.Status == status);

        return await query.ToListAsync();
    }
}
