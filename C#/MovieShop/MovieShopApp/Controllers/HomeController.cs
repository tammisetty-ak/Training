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

    public IActionResult Home([FromQuery(Name = "page")] int pageNumber = 1, int pageSize = 10)
    {
        var movies = _movieService.GetAllMoviesPaged(pageNumber, pageSize);
        ViewBag.CurrentPage = pageNumber;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalItems = movies.TotalItems;
        ViewBag.TotalPages = (int)Math.Ceiling((double)movies.TotalItems / movies.PageSize);
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