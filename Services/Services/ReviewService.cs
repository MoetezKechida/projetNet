using projetNet.Repositories;
using projetNet.Repositories.Repositories;
using projetNet.Services.ServiceContracts;

namespace projetNet.Services.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IAuditLogRepository _auditLogRepository;

    public ReviewService(IReviewRepository reviewRepository, IAuditLogRepository auditLogRepository)
    {
        _reviewRepository = reviewRepository;
        _auditLogRepository = auditLogRepository;
    }

    public async Task<Review?> GetByIdAsync(string id)
    {
        return await _reviewRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Review>> GetAllAsync()
    {
        return await _reviewRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Review>> GetByTargetIdAsync(string targetId)
    {
        return await _reviewRepository.GetByTargetIdAsync(targetId);
    }

    public async Task<IEnumerable<Review>> GetByReviewerIdAsync(string reviewerId)
    {
        return await _reviewRepository.GetByReviewerIdAsync(reviewerId);
    }

    public async Task<double> GetAverageRatingAsync(string targetId)
    {
        return await _reviewRepository.GetAverageRatingAsync(targetId);
    }

    public async Task<Review> CreateAsync(Review review)
    {
        // Validate rating (1-5 stars)
        if (review.Rating < 1 || review.Rating > 5)
        {
            throw new ArgumentException("Rating must be between 1 and 5.");
        }

        // Validate comment
        if (string.IsNullOrWhiteSpace(review.Comment))
        {
            throw new ArgumentException("Comment cannot be empty.");
        }

        review.CreatedAt = DateTime.UtcNow;
        var result = await _reviewRepository.AddAsync(review);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = review.ReviewerId,
            Action = "Create Review",
            EntityType = "Review",
            Timestamp = DateTime.UtcNow
        });

        return result;
    }

    public async Task UpdateAsync(string id, Review review)
    {
        var existingReview = await _reviewRepository.GetByIdAsync(id);
        if (existingReview == null)
        {
            throw new KeyNotFoundException($"Review with ID {id} not found.");
        }

        // Validate rating
        if (review.Rating < 1 || review.Rating > 5)
        {
            throw new ArgumentException("Rating must be between 1 and 5.");
        }

        await _reviewRepository.UpdateAsync(id, review);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = review.ReviewerId,
            Action = "Update Review",
            EntityType = "Review",
            Timestamp = DateTime.UtcNow
        });
    }

    public async Task DeleteAsync(string id)
    {
        var review = await _reviewRepository.GetByIdAsync(id);
        if (review == null)
        {
            throw new KeyNotFoundException($"Review with ID {id} not found.");
        }

        await _reviewRepository.DeleteAsync(id);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = review.ReviewerId,
            Action = "Delete Review",
            EntityType = "Review",
            Timestamp = DateTime.UtcNow
        });
    }
}
