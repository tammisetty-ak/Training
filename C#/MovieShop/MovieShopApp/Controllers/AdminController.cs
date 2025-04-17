using Microsoft.AspNetCore.Mvc;

namespace MovieShopApp.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}