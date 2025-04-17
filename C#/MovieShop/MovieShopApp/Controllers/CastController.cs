using Microsoft.AspNetCore.Mvc;
using MovieShopCore.Contracts.Services;

namespace MovieShopApp.Controllers;

public class CastController : Controller
{
    private readonly ICastService _castService;

    public CastController(ICastService castService)
    {
        _castService = castService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    // public IActionResult GetCastDetails(int id)
    // {
    //     var castDetailsModel = _castService.GetAllCastByMovieId(id);
    //     return View(castDetailsModel);
    // }
}