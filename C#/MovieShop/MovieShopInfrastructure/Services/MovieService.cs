using MovieShopCore.Contracts.Repositories;
using MovieShopCore.Contracts.Services;
using MovieShopCore.Models;

namespace MovieShopInfrastructure.Services;

public class MovieService: IMovieService
{
    
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public List<MovieCardModel> Top20GrossingMovies()
    {
        var movies = _movieRepository.GetTop20GrossingMovies();
        var movieCardModels = new List<MovieCardModel>();
        foreach (var movie in movies)
        {
            movieCardModels.Add(new MovieCardModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterURL = movie.PosterUrl
                
            });
        }
        return movieCardModels;
    }

    public MovieDetailsModel Details(int id)
    {
        var movie = _movieRepository.GetById(id);
        var movieDetailModel = new MovieDetailsModel()
        {
            Id = movie.Id,
            Title = movie.Title,
            PosterURL = movie.PosterUrl,
            ReleaseDate = movie.ReleaseDate,
            Runtime =  movie.Runtime,
            Budget = movie.Budget,
            Revenue = movie.Revenue,
            Overview = movie.Overview,
            TagLine = movie.TagLine,
            TmdbUrl = movie.TmdbUrl,
        };
        return movieDetailModel;
    }
}