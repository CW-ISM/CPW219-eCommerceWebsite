using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;
using eCommerce.Data;
using Microsoft.EntityFrameworkCore;

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

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Here you would typically check the credentials against the database
            // For now, we will just return a success message
            Member? loggedInMember = await _context.Members
                                .Where(m => (m.Username == model.EmailOrUsername || m.Email == model.EmailOrUsername)
                                && m.Password == model.Password)
                                .SingleOrDefaultAsync();

            if(loggedInMember == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your credentials.");
                return View(model);
            }

            // Store the member in session or authentication cookie
            HttpContext.Session.SetString("Username", loggedInMember.Username);
            HttpContext.Session.SetInt32("MemberId", loggedInMember.MemberId);

            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Logout()
    {
        // Clear the session or authentication cookie
        HttpContext.Session.Clear();
        TempData["SuccessMessage"] = "You have been logged out successfully.";
        return RedirectToAction("Index", "Home");
    }
}
