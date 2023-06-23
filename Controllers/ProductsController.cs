using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmerCentral2.Data;
using FarmerCentral2.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;

namespace FarmerCentral2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            //Including current User's Id to the table
            var applicationDbContext = _context.Products.Include(p => p.ApplicationUser)
                                                        .Where(a => a.ApplicationUser.UserName == User.Identity.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        //Action to list products created by a specific farmer
        //This action is to be redirected to when clicking on "View Details"
        [Authorize(Roles = "Employee")]
        public IActionResult ProductsByFarmer(string userId)
        {
            var products = _context.Products.Where(p => p.ApplicationUserId == userId).ToList();
            ViewBag.ApplicationUserId = userId;
            return View(products);
        }

        //Action to filter farmer's products based on date range or product type
        
        [Authorize(Roles = "Employee")]
        public IActionResult FilterProducts(string userId, DateTime startDate, DateTime endDate, string productType)
        {
            //Creating query to assign Product UserId to Farmer & apply user filters to product list
            var productsQuery = _context.Products.Where(p => p.ApplicationUserId == userId);

            if (startDate != DateTime.MinValue)
            {
                productsQuery = productsQuery.Where(p => p.Date >= startDate);
            }

            if (endDate != DateTime.MinValue)
            {
                productsQuery = productsQuery.Where(p => p.Date <= endDate);
            }

            if (!string.IsNullOrEmpty(productType))
            {
                productsQuery = productsQuery.Where(p => p.Type == productType);
            }

            var products = productsQuery.ToList();

            return View(products);
        }
        

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create

        //Only allowing a farmer to create a new Product
        [Authorize(Roles = "Farmer")]
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            product.ApplicationUserId = user.Id;

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.ApplicationUserId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.ApplicationUserId);
            return View(product);
        }

        // POST: Products/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Type,Date,ApplicationUserId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.ApplicationUserId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
