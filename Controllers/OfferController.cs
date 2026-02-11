using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers
{
    [Authorize]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OfferController(
            IOfferService offerService,
            IVehicleService vehicleService,
            UserManager<ApplicationUser> userManager)
        {
            _offerService = offerService;
            _vehicleService = vehicleService;
            _userManager = userManager;
        }

        // GET: Offer
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var offers = await _offerService.GetBySellerIdAsync(userId!);
            return View(offers);
        }

        // GET: Offer/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var offer = await _offerService.GetByIdAsync(id);
            if (offer == null) return NotFound();
            return View(offer);
        }

        // GET: Offer/Create
        public async Task<IActionResult> Create()
        {
            var userId = _userManager.GetUserId(User);
            var vehicles = await _vehicleService.GetByOwnerIdAsync(userId!);
            ViewData["VehicleId"] = new SelectList(vehicles, "Id", "Brand");
            return View();
        }

        // POST: Offer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,Price,Status,VehicleId")] Offer offer)
        {
            var userId = _userManager.GetUserId(User);
            offer.SellerId = userId!;
            await _offerService.CreateAsync(offer);
            return RedirectToAction(nameof(Index));
        }

        // GET: Offer/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var offer = await _offerService.GetByIdAsync(id);
            if (offer == null) return NotFound();

            var userId = _userManager.GetUserId(User);
            var vehicles = await _vehicleService.GetByOwnerIdAsync(userId!);
            ViewData["VehicleId"] = new SelectList(vehicles, "Id", "Brand", offer.VehicleId);
            return View(offer);
        }

        // POST: Offer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Type,Price,Status,VehicleId")] Offer offer)
        {
            if (id != offer.Id) return NotFound();

            var existing = await _offerService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Type = offer.Type;
            existing.Price = offer.Price;
            existing.Status = offer.Status;
            existing.VehicleId = offer.VehicleId;

            await _offerService.UpdateAsync(existing);
            return RedirectToAction(nameof(Index));
        }

        // GET: Offer/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var offer = await _offerService.GetByIdAsync(id);
            if (offer == null) return NotFound();
            return View(offer);
        }

        // POST: Offer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _offerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
