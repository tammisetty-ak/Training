using Microsoft.AspNetCore.Mvc;

namespace MovieShopApp.Controllers;

public class CastController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}