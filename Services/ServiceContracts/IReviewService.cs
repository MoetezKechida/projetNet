namespace projetNet.Services.ServiceContracts;

public interface IReviewService
{
    Task<Review?> GetByIdAsync(string id);
    Task<IEnumerable<Review>> GetAllAsync();
    Task<IEnumerable<Review>> GetByTargetIdAsync(string targetId);
    Task<IEnumerable<Review>> GetByReviewerIdAsync(string reviewerId);
    Task<double> GetAverageRatingAsync(string targetId);
    Task<Review> CreateAsync(Review review);
    Task UpdateAsync(string id, Review review);
    Task DeleteAsync(string id);
}
