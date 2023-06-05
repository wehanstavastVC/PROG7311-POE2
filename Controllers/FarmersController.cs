using FarmerCentral2.Data;
using FarmerCentral2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FarmerCentral2.Controllers
{
    public class FarmersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Index()
        {
            //passing farmer id to "ProductsByFarmer"
            var users = await _context.ApplicationUsers.ToListAsync();
            return View(users);
        }

        [Authorize(Roles = "Employee")]
        public IActionResult Details(string id)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(f => f.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return RedirectToAction("ProductsByFarmer", "Products", new { userId = user.Id });
        }

        [Authorize(Roles = "Employee")]
        public IActionResult FilterProducts(int userId, DateTime startDate, DateTime endDate, string productType)
        {
            return RedirectToAction("ProductsByFarmer", new { userId });
        }

    }
}
