using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using projetNet.Data;
using projetNet.Models;
using System;
using System.Linq;

namespace projetNet.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Profile
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var offers = _context.Offers
                .Where(o => o.SellerId == userId)
                .ToList();

            return View(offers);
        }

        // GET: /Profile/OfferDetails/{id}
        public IActionResult OfferDetails(Guid id)
        {
            var offer = _context.Offers.FirstOrDefault(o => o.Id == id);
            if (offer == null) return NotFound();

            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == offer.VehicleId);
            if (vehicle == null)
            {
                TempData["Error"] = "Vehicle not found for this offer.";
                return RedirectToAction("Index");
            }

            var model = new OfferDetailsViewModel
            {
                Offer = offer,
                Vehicle = vehicle,
                Bookings = _context.Bookings.Where(b => b.OfferId == id).ToList(),
                Sales = _context.VehiculeSales.Where(s => s.OfferId == id).ToList()
            };

            ViewBag.OfferId = id;
            return View(model);
        }

        // GET: /Profile/Create
        [HttpGet]
        public IActionResult Create()
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.Vehicles = _context.Vehicles
                .Where(v => v.OwnerId == userId)
                .ToList();

            return View();
        }

        // POST: /Profile/Create
        [HttpPost]
        public IActionResult Create(Offer offer)
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.Vehicles = _context.Vehicles
                .Where(v => v.OwnerId == userId)
                .ToList();

            if (offer.VehicleId == Guid.Empty)
                ModelState.AddModelError("VehicleId", "You must select a vehicle.");

            if (offer.Price <= 0)
                ModelState.AddModelError("Price", "Price must be greater than zero.");

            if (!ModelState.IsValid)
                return View(offer);

            offer.Id = Guid.NewGuid();
            offer.SellerId = userId;
            offer.Status = "pending";

            _context.Offers.Add(offer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: /Profile/Edit/{id}
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var userId = _userManager.GetUserId(User);
            var offer = _context.Offers
                .FirstOrDefault(o => o.Id == id && o.SellerId == userId);

            if (offer == null) return NotFound();

            ViewBag.Vehicles = _context.Vehicles
                .Where(v => v.OwnerId == userId)
                .ToList();

            return View(offer);
        }

        // POST: /Profile/Edit/{id}
        [HttpPost]
        public IActionResult Edit(Guid id, Offer offer)
        {
            var userId = _userManager.GetUserId(User);

            if (offer.VehicleId == Guid.Empty)
                ModelState.AddModelError("VehicleId", "You must select a vehicle.");

            if (offer.Price <= 0)
                ModelState.AddModelError("Price", "Price must be greater than zero.");

            if (!ModelState.IsValid)
                return View(offer);

            var existing = _context.Offers
                .FirstOrDefault(o => o.Id == id && o.SellerId == userId);

            if (existing == null) return NotFound();

            existing.Type = offer.Type;
            existing.Price = offer.Price;
            existing.VehicleId = offer.VehicleId;
            existing.Status = offer.Status;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Profile/Delete/{id}
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var userId = _userManager.GetUserId(User);
            var offer = _context.Offers
                .FirstOrDefault(o => o.Id == id && o.SellerId == userId);

            if (offer == null) return NotFound();
            return View(offer);
        }

        // POST: /Profile/Delete
        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var offer = _context.Offers.FirstOrDefault(o => o.Id == id);
            if (offer == null) return NotFound();

            _context.Offers.Remove(offer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ConfirmSale(Guid saleId)
        {
            var sale = _context.VehiculeSales.FirstOrDefault(s => s.Id == saleId);
            if (sale == null) return NotFound();

            sale.Status = "completed";

            var offer = _context.Offers.FirstOrDefault(o => o.Id == sale.OfferId);
            if (offer != null) offer.Status = "completed";

            _context.SaveChanges();
            return RedirectToAction("OfferDetails", new { id = sale.OfferId });
        }

        [HttpPost]
        public IActionResult ConfirmBooking(Guid bookingId)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null) return NotFound();

            booking.Status = "completed";

            var offer = _context.Offers.FirstOrDefault(o => o.Id == booking.OfferId);
            if (offer != null) offer.Status = "completed";

            _context.SaveChanges();
            return RedirectToAction("OfferDetails", new { id = booking.OfferId });
        }
    }
}
