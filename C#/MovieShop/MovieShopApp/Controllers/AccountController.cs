using Microsoft.AspNetCore.Mvc;

namespace MovieShopApp.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpGet]
    public IActionResult TopGrossingMovies()
    {
        return View();
    }
}