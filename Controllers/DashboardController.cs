using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetNet.Data;
using projetNet.Models;
using System.Linq;

namespace projetNet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sales = _context.VehiculeSales.ToList();
            var bookings = _context.Bookings.ToList();
            ViewBag.Sales = sales;
            ViewBag.Bookings = bookings;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManageInspectors()
        {
            var inspectors = _context.Users.Where(u => u.Email.Contains("inspector") || u.UserName.Contains("inspector")).ToList();
            return View(inspectors);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateInspector()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateInspector(ApplicationUser inspector, string password)
        {
            // This should use UserManager in a real app, here is a placeholder
            // Add inspector to db and assign Inspector role
            return RedirectToAction("ManageInspectors");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditInspector(string id)
        {
            var inspector = _context.Users.FirstOrDefault(u => u.Id == id);
            if (inspector == null) return NotFound();
            return View(inspector);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditInspector(ApplicationUser inspector)
        {
            // Update inspector in db
            return RedirectToAction("ManageInspectors");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteInspector(string id)
        {
            var inspector = _context.Users.FirstOrDefault(u => u.Id == id);
            if (inspector == null) return NotFound();
            return View(inspector);
        }

        [HttpPost, ActionName("DeleteInspector")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteInspectorConfirmed(string id)
        {
            // Remove inspector from db
            return RedirectToAction("ManageInspectors");
        }
    }
}
