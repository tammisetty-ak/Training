using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieShopApp.Models;
using MovieShopCore.Contracts.Services;
using MovieShopInfrastructure.Services;

namespace MovieShopApp.Controllers;

public class HomeController : Controller
{
    
    private IMovieService _movieService;
    
    private IGenreService _genreService;

    public HomeController(IMovieService movieService, IGenreService genreService)
    {
        _movieService = movieService;
        _genreService = genreService;
    }

    public IActionResult GenreDropdownPartial()
    {
        var genres = _genreService.GetAllGenres(); 
        ViewData["Genres"] = genres;
        return View();
    }
    
    public IActionResult Index()
    {
        ViewData["Genres"] = _genreService.GetAllGenres(); // Critical
        ViewData["Message"] = "Your application description page.";
        var movies = _movieService.Top20GrossingMovies();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        ViewData["Genres"] = _genreService.GetAllGenres(); // Critical
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        ViewData["Genres"] = _genreService.GetAllGenres(); // Critical
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}