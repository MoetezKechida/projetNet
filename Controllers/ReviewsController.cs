using Microsoft.AspNetCore.Mvc;
using projetNet.Services;

namespace projetNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var reviews = await _reviewService.GetAllAsync();
            return Ok(reviews);
        }
        catch (Exception ex)
        {
            return StatusCode(503, new { error = "MongoDB connection failed", details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        try
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
                return NotFound();
            return Ok(review);
        }
        catch (Exception ex)
        {
            return StatusCode(503, new { error = "MongoDB connection failed", details = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Review review)
    {
        try
        {
            var created = await _reviewService.CreateAsync(review);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _reviewService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
