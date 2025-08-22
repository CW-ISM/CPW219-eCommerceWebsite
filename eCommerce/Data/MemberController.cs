using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;

namespace eCommerce.Data;

public class MemberController : Controller
{
    public IActionResult Register()
    {
        return View();
    }
}
