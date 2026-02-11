using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly UserManager<ApplicationUser> _userManager;

    public ReviewsController(IReviewService reviewService, UserManager<ApplicationUser> userManager)
    {
        _reviewService = reviewService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reviews = await _reviewService.GetAllAsync();
        return Ok(reviews);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var review = await _reviewService.GetByIdAsync(id);
        if (review == null)
            return NotFound();
        return Ok(review);
    }

    [HttpGet("by-target/{targetId}")]
    public async Task<IActionResult> GetByTargetId(string targetId)
    {
        var reviews = await _reviewService.GetByTargetIdAsync(targetId);
        var averageRating = await _reviewService.GetAverageRatingAsync(targetId);
        return Ok(new { reviews, averageRating });
    }

    [HttpGet("by-reviewer/{reviewerId}")]
    public async Task<IActionResult> GetByReviewerId(string reviewerId)
    {
        var reviews = await _reviewService.GetByReviewerIdAsync(reviewerId);
        return Ok(reviews);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReviewRequest request)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        if (request.Rating < 1 || request.Rating > 5)
            return BadRequest(new { error = "Rating must be between 1 and 5" });

        var review = new Review
        {
            ReviewerId = userId,
            TargetId = request.TargetId,
            Comment = request.Comment,
            Rating = request.Rating,
            CreatedAt = DateTime.UtcNow
        };

        var created = await _reviewService.CreateAsync(review);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateReviewRequest request)
    {
        var review = await _reviewService.GetByIdAsync(id);
        if (review == null)
            return NotFound();

        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (review.ReviewerId != userId)
            return Forbid();

        if (request.Rating is < 1 or > 5)
            return BadRequest(new { error = "Rating must be between 1 and 5" });

        review.Comment = request.Comment;
        review.Rating = request.Rating;
        await _reviewService.UpdateAsync(id, review);
        return Ok(review);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var review = await _reviewService.GetByIdAsync(id);
        if (review == null)
            return NotFound();

        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (review.ReviewerId != userId)
            return Forbid();

        await _reviewService.DeleteAsync(id);
        return NoContent();
    }
}

public record CreateReviewRequest(string TargetId, string Comment, int Rating);
public record UpdateReviewRequest(string Comment, int Rating);
