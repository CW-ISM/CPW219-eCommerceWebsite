using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;
using eCommerce.Data;

namespace eCommerce.Controllers;

public class MemberController : Controller
{
    private readonly ProductDbContext _context;
    public MemberController(ProductDbContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterationViewModel model)
    {
        if(ModelState.IsValid)
        {
            // Here you would typically save the member to the database
            // For now, we will just return a success message
            Member newMember = new Member
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password, // In a real application, ensure to hash the password
                BirthDate = model.BirthDate
            };

            _context.Members.Add(newMember);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"{model.Username} has been registered successfully!";
            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
}
