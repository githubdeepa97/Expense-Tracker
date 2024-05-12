using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

public class UserController : Controller
{
    public UserController()
    {}
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
}