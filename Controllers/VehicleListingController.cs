using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers
{
    public class VehicleListingController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<ApplicationUser> _userManager;

        public VehicleListingController(
            IOfferService offerService,
            IVehicleService vehicleService,
            UserManager<ApplicationUser> userManager)
        {
            _offerService = offerService;
            _vehicleService = vehicleService;
            _userManager = userManager;
        }

        // GET: /VehicleListing/
        public async Task<IActionResult> Index()
        {
            var activeOffers = await _offerService.SearchAsync(null, null, null, "accepted");
            
            var listings = new List<dynamic>();
            foreach (var offer in activeOffers)
            {
                var vehicle = await _vehicleService.GetByIdAsync(offer.VehicleId);
                listings.Add(new { Offer = offer, Vehicle = vehicle });
            }

            return View(listings);
        }

        // GET: /VehicleListing/Preview/5
        public async Task<IActionResult> Preview(Guid id)
        {
            // Search for an accepted offer for this vehicle
            var offers = await _offerService.SearchAsync(null, null, null, "accepted");
            var offer = offers.FirstOrDefault(o => o.VehicleId == id);
            if (offer == null)
                return NotFound();

            var vehicle = await _vehicleService.GetByIdAsync(offer.VehicleId);
            return View(new { Offer = offer, Vehicle = vehicle });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Rent(Guid VehicleId, DateTime StartDate, DateTime EndDate)
        {
            // TODO: Extract to BookingService
            var userId = _userManager.GetUserId(User);
            
            TempData["Message"] = "Rent request submitted.";
            return RedirectToAction("Preview", new { id = VehicleId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Buy(Guid OfferId, decimal Amount)
        {
            // TODO: Extract to SaleService
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                TempData["Message"] = "You must be logged in to buy.";
                return RedirectToAction("Index");
            }

            TempData["Message"] = $"Buy request submitted with price {Amount:F2} €.";
            var offer = await _offerService.GetByIdAsync(OfferId);
            return RedirectToAction("Preview", new { id = offer?.VehicleId });
        }
    }
}
