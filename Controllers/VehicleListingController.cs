using Microsoft.AspNetCore.Mvc;
using projetNet.Models;
using projetNet.Data;
using System.Linq;

namespace projetNet.Controllers
{
    public class VehicleListingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleListingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /VehicleListing/
        public IActionResult Index()
        {
            var offers = _context.Offers
                .Where(o => o.Status == "accepted")
                .Select(o => new
                {
                    Offer = o,
                    Vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == o.VehicleId),
                    Seller = _context.Users.FirstOrDefault(u => u.Id == o.SellerId)
                })
                .ToList();

            return View(offers);
        }

        // GET: /VehicleListing/Preview/5
        public IActionResult Preview(Guid id)
        {
            var offer = _context.Offers.FirstOrDefault(o => o.VehicleId == id && o.Status == "accepted");
            if (offer == null)
            {
                return NotFound();
            }
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == offer.VehicleId);
            var seller = _context.Users.FirstOrDefault(u => u.Id == offer.SellerId);
            return View(new { Offer = offer, Vehicle = vehicle, Seller = seller });
        }

        [HttpPost]
        public IActionResult Rent(Guid VehicleId, DateTime StartDate, DateTime EndDate)
        {
            var offer = _context.Offers.FirstOrDefault(o => o.VehicleId == VehicleId && o.Status == "accepted" && o.Type == "Rent");
            if (offer == null)
            {
                TempData["Message"] = "No valid rent offer found.";
                return RedirectToAction("Preview", new { id = VehicleId });
            }
            var buyerId = User.Identity?.Name ?? "demoBuyer";
            var days = (EndDate - StartDate).Days;
            var totalAmount = days * offer.Price;
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                OfferId = offer.Id,
                BuyerId = buyerId,
                StartDate = StartDate,
                EndDate = EndDate,
                TotalAmount = totalAmount,
                Status = "attempt"
            };
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            TempData["Message"] = $"Rent request submitted for {days} days.";
            return RedirectToAction("Preview", new { id = VehicleId });
        }

        [HttpPost]
        public IActionResult Buy(Guid OfferId, decimal Amount)
        {
            // For demo, use logged-in user as buyer
            var buyerId = User.Identity?.Name ?? "demoBuyer";
            var vehiculeSale = new VehiculeSale
            {
                Id = Guid.NewGuid(),
                OfferId = OfferId,
                BuyerId = buyerId,
                Amount = Amount,
                Status = "attempt"
            };
            _context.VehiculeSales.Add(vehiculeSale);
            _context.SaveChanges();
            TempData["Message"] = $"Buy request submitted with price {Amount:F2} €.";
            var offer = _context.Offers.FirstOrDefault(o => o.Id == OfferId);
            return RedirectToAction("Preview", new { id = offer?.VehicleId });
        }
    }
}
