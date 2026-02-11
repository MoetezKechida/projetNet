using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(
            IOfferService offerService,
            IVehicleService vehicleService,
            UserManager<ApplicationUser> userManager)
        {
            _offerService = offerService;
            _vehicleService = vehicleService;
            _userManager = userManager;
        }

        // GET: /Profile
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var offers = await _offerService.GetBySellerIdAsync(userId!);
            return View(offers);
        }

        // GET: /Profile/OfferDetails/{id}
        public async Task<IActionResult> OfferDetails(Guid id)
        {
            var offer = await _offerService.GetByIdAsync(id);
            if (offer == null) return NotFound();

            var vehicle = await _vehicleService.GetByIdAsync(offer.VehicleId);
            if (vehicle == null)
            {
                TempData["Error"] = "Vehicle not found for this offer.";
                return RedirectToAction("Index");
            }

            var model = new OfferDetailsViewModel
            {
                Offer = offer,
                Vehicle = vehicle
            };

            ViewBag.OfferId = id;
            return View(model);
        }

        // GET: /Profile/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.Vehicles = (await _vehicleService.GetByOwnerIdAsync(userId!)).ToList();
            return View();
        }

        // POST: /Profile/Create
        [HttpPost]
        public async Task<IActionResult> Create(Offer offer)
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.Vehicles = (await _vehicleService.GetByOwnerIdAsync(userId!)).ToList();

            if (offer.VehicleId == Guid.Empty)
                ModelState.AddModelError("VehicleId", "You must select a vehicle.");

            if (offer.Price <= 0)
                ModelState.AddModelError("Price", "Price must be greater than zero.");

            if (!ModelState.IsValid)
                return View(offer);

            offer.SellerId = userId!;
            await _offerService.CreateAsync(offer);

            return RedirectToAction("Index");
        }

        // GET: /Profile/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var userId = _userManager.GetUserId(User);
            var offer = await _offerService.GetByIdAsync(id);
            if (offer == null || offer.SellerId != userId)
                return NotFound();

            ViewBag.Vehicles = (await _vehicleService.GetByOwnerIdAsync(userId!)).ToList();
            return View(offer);
        }

        // POST: /Profile/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Offer offer)
        {
            var userId = _userManager.GetUserId(User);

            if (offer.VehicleId == Guid.Empty)
                ModelState.AddModelError("VehicleId", "You must select a vehicle.");

            if (offer.Price <= 0)
                ModelState.AddModelError("Price", "Price must be greater than zero.");

            if (!ModelState.IsValid)
                return View(offer);

            var existing = await _offerService.GetByIdAsync(id);
            if (existing == null || existing.SellerId != userId)
                return NotFound();

            existing.Type = offer.Type;
            existing.Price = offer.Price;
            existing.VehicleId = offer.VehicleId;
            existing.Status = offer.Status;

            await _offerService.UpdateAsync(existing);
            return RedirectToAction("Index");
        }

        // GET: /Profile/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = _userManager.GetUserId(User);
            var offer = await _offerService.GetByIdAsync(id);
            if (offer == null || offer.SellerId != userId)
                return NotFound();

            return View(offer);
        }

        // POST: /Profile/Delete
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var offer = await _offerService.GetByIdAsync(id);
            if (offer == null) return NotFound();

            await _offerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmSale(Guid saleId)
        {
            // TODO: Extract to a SaleService when business logic grows
            // For now, this remains a thin controller action
            await Task.CompletedTask;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmBooking(Guid bookingId)
        {
            // TODO: Extract to a BookingService when business logic grows
            await Task.CompletedTask;
            return RedirectToAction("Index");
        }
    }
}
