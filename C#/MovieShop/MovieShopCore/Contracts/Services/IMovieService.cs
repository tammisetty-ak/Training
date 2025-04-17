using MovieShopApp.Models;
using MovieShopCore.Models;

namespace MovieShopCore.Contracts.Services;

public interface IMovieService
{
    public List<MovieCardModel> Top20GrossingMovies();
    
    public MovieDetailsModel Details(int id);
    
    public PagedResultModel<MovieCardModel> GetAllMoviesPaged(int pageNumber, int pageSize);
}