using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewController(IReviewService reviewService, UserManager<ApplicationUser> userManager)
        {
            _reviewService = reviewService;
            _userManager = userManager;
        }

        // GET: Review
        public async Task<IActionResult> Index()
        {
            try
            {
                var reviews = await _reviewService.GetAllAsync();
                return View(reviews);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading reviews: {ex.Message}";
                return View(new List<Review>());
            }
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var review = await _reviewService.GetByIdAsync(id);
                if (review == null)
                {
                    return NotFound();
                }

                return View(review);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading review: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Review/Create
        public IActionResult Create(string? targetId)
        {
            ViewBag.TargetId = targetId;
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewerId,TargetId,Comment,Rating")] Review review)
        {
            try
            {
                // Set the created date
                review.CreatedAt = DateTime.UtcNow;

                // Get current user if ReviewerId is not set
                if (string.IsNullOrEmpty(review.ReviewerId))
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        review.ReviewerId = user.Id;
                    }
                }

                // Validate rating
                if (review.Rating < 1 || review.Rating > 5)
                {
                    ModelState.AddModelError("Rating", "Rating must be between 1 and 5");
                    return View(review);
                }

                var created = await _reviewService.CreateAsync(review);
                TempData["Success"] = "Review created successfully!";
                return RedirectToAction(nameof(Details), new { id = created.Id });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error creating review: {ex.Message}";
                return View(review);
            }
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var review = await _reviewService.GetByIdAsync(id);
                if (review == null)
                {
                    return NotFound();
                }

                return View(review);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading review: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Review/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ReviewerId,TargetId,Comment,Rating,CreatedAt")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            try
            {
                // Validate rating
                if (review.Rating < 1 || review.Rating > 5)
                {
                    ModelState.AddModelError("Rating", "Rating must be between 1 and 5");
                    return View(review);
                }

                await _reviewService.UpdateAsync(id, review);
                TempData["Success"] = "Review updated successfully!";
                return RedirectToAction(nameof(Details), new { id = review.Id });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error updating review: {ex.Message}";
                return View(review);
            }
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var review = await _reviewService.GetByIdAsync(id);
                if (review == null)
                {
                    return NotFound();
                }

                return View(review);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading review: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                await _reviewService.DeleteAsync(id);
                TempData["Success"] = "Review deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error deleting review: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Review/ByTarget/targetId
        public async Task<IActionResult> ByTarget(string targetId)
        {
            if (string.IsNullOrEmpty(targetId))
            {
                return NotFound();
            }

            try
            {
                var reviews = await _reviewService.GetByTargetIdAsync(targetId);
                var averageRating = await _reviewService.GetAverageRatingAsync(targetId);
                
                ViewBag.TargetId = targetId;
                ViewBag.AverageRating = averageRating;
                
                return View("Index", reviews);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading reviews: {ex.Message}";
                return View("Index", new List<Review>());
            }
        }

        // GET: Review/ByReviewer/reviewerId
        public async Task<IActionResult> ByReviewer(string reviewerId)
        {
            if (string.IsNullOrEmpty(reviewerId))
            {
                return NotFound();
            }

            try
            {
                var reviews = await _reviewService.GetByReviewerIdAsync(reviewerId);
                ViewBag.ReviewerId = reviewerId;
                
                return View("Index", reviews);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading reviews: {ex.Message}";
                return View("Index", new List<Review>());
            }
        }
    }
}
