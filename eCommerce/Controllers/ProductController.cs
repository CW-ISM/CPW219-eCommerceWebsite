using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers;

public class ProductController : Controller
{
    private readonly ProductDbContext _context;
    public ProductController(ProductDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        List<Product> allProducts = await _context.Products.ToListAsync(); // Retrieve all products from the database
        return View(allProducts);
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

            // TempData is used to pass data and will persist over a redirect
            TempData["SuccessMessage"] = $"{product.Name} was created successfully!";
            //TempData["FailureMessage"] = $"Failed to create {product.Name}.";

            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Product? product = _context.Products
            .Where(p => p.Id == id)
            .FirstOrDefault();

        if (product == null)
        {
            //TempData["ErrorMessage"] = "Product not found.";
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        if (!ModelState.IsValid)
        {
            _context.Update(product); // Update the product in the context
            await _context.SaveChangesAsync(); // Save changes to the database

            TempData["SuccessMessage"] = $"{product.Name} was updated successfully!";

            return RedirectToAction("Index");
        }

        return View(product);
    }
}
