using Microsoft.AspNetCore.Mvc;
using MovieShopCore.Contracts.Services;

namespace MovieShopApp.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    // Details

    public IActionResult Details(int id)
    {
        var movies = _movieService.Details(id);
        return View(movies);
    }
    
    // 
    // GET
    public IActionResult Index()
    {
        return View();
    }
}