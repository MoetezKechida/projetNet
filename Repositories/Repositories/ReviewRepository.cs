using MongoDB.Driver;
using projetNet.Data;
using projetNet.Repositories.RepositoryContracts;

namespace projetNet.Repositories.Repositories;

public interface IReviewRepository : IMongoRepository<Review>
{
    Task<IEnumerable<Review>> GetByTargetIdAsync(string targetId);
    Task<IEnumerable<Review>> GetByReviewerIdAsync(string reviewerId);
    Task<double> GetAverageRatingAsync(string targetId);
}

public class ReviewRepository : MongoRepository<Review>, IReviewRepository
{
    public ReviewRepository(IMongoContext mongoContext) 
        : base(mongoContext, "reviews")
    {
    }

    public async Task<IEnumerable<Review>> GetByTargetIdAsync(string targetId)
    {
        var filter = Builders<Review>.Filter.Eq(r => r.TargetId, targetId);
        return await _collection
            .Find(filter)
            .SortByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetByReviewerIdAsync(string reviewerId)
    {
        var filter = Builders<Review>.Filter.Eq(r => r.ReviewerId, reviewerId);
        return await _collection
            .Find(filter)
            .SortByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<double> GetAverageRatingAsync(string targetId)
    {
        var filter = Builders<Review>.Filter.Eq(r => r.TargetId, targetId);
        var reviews = await _collection.Find(filter).ToListAsync();
        
        if (!reviews.Any())
            return 0;

        return reviews.Average(r => r.Rating);
    }
}
