using MovieShopApp.Models;
using MovieShopCore.Entities;

namespace MovieShopCore.Contracts.Repositories;

public interface IMovieRepository : IRepository<Movie>
{
    IEnumerable<Movie> GetTop20GrossingMovies();
    
    Movie GetMovieById(int id);
    
    PagedResultModel<Movie> GetPagedMovies(int pageNumber, int pageSize);
}