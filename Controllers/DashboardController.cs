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
    }
}
