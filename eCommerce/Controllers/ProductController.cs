using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class ProductController : Controller
{
    private readonly ProductDbContext _context;
    public ProductController(ProductDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            // Save product to database
            // Redirect to Product list (Index action)
            _context.Products.Add(product);     // Add the product to the context
            await _context.SaveChangesAsync();  // Save changes to the database

            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }
}
