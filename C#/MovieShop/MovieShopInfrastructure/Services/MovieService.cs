using MovieShopApp.Models;
using MovieShopCore.Contracts.Repositories;
using MovieShopCore.Contracts.Services;
using MovieShopCore.Entities;
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
        var movie = _movieRepository.GetMovieById(id);
        
        var movieDetailModel = new MovieDetailsModel
        {
            Id = movie.Id,
            Title = movie.Title,
            PosterURL = movie.PosterUrl,
            ReleaseDate = movie.ReleaseDate,
            Runtime = movie.Runtime,
            Budget = movie.Budget,
            Revenue = movie.Revenue,
            Overview = movie.Overview,
            TagLine = movie.TagLine,
            TmdbUrl = movie.TmdbUrl,
            MovieCastModels = movie.Cast
                .Select(c => new MovieCastModel
                {
                    CastId = c.CastId,
                    MovieId = c.MovieId,
                    Character = c.Character,

                    // map the nested Cast entity into your CastModel DTO
                    CastModel = new CastModel
                    {
                        Id = c.Cast.Id,
                        Name = c.Cast.Name,
                        ProfilePath = c.Cast.ProfilePath,
                        TmdbUrl = c.Cast.TmdbUrl,
                        Gender = c.Cast.Gender
                    }
                })
                .OrderBy(mc => mc.CastModel.Id) // or mc => mc.CastId, or your billing Order
                .ToList()
        };
        return movieDetailModel;
    }
    

    public List<MovieCardModel> getAllMovies()
    {
        var movies = _movieRepository.GetAll();
        var movieCardModels = new List<MovieCardModel>();
        foreach (var movie in movies)
        {
            movieCardModels.Add(new MovieCardModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterURL = movie.PosterUrl,
            });
        }
        return movieCardModels;
    }

    public PagedResultModel<MovieCardModel> GetAllMoviesPaged(int pageNumber, int pageSize)
    {
        var movies = _movieRepository.GetPagedMovies(pageNumber, pageSize);
        var movieCardModels = movies.Items
            .Select(m => new MovieCardModel {
                Id        = m.Id,
                Title     = m.Title,
                PosterURL = m.PosterUrl
            })
            .ToList();

        return new PagedResultModel<MovieCardModel>
        {
            Items       = movieCardModels,
            CurrentPage = movies.CurrentPage,
            PageSize    = movies.PageSize,
            TotalItems  = movies.TotalItems   
        };
    }
}