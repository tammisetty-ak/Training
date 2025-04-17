using Microsoft.EntityFrameworkCore;
using MovieShopApp.Models;
using MovieShopCore.Contracts.Repositories;
using MovieShopCore.Entities;
using MovieShopInfrastructure.Data;

namespace MovieShopInfrastructure.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
        
    }
    public IEnumerable<Movie> GetTop20GrossingMovies()
    {
        var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(20);
        return movies;
    }
    
    public Movie GetMovieById(int id)
    {
        var movie = _dbContext.Movies
            .Include(m => m.Cast)        // Include MovieCast join entities
            .ThenInclude(mc => mc.Cast)  // Include actual Cast entities
            .FirstOrDefault(m => m.Id == id);
        
        return movie;
    }

    public PagedResultModel<Movie> GetPagedMovies(int pageNumber, int pageSize)
    {
        var query = _dbContext.Movies.AsNoTracking();
        
        var total = query.Count();

        var movies = query
            .OrderBy(m => m.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        return new PagedResultModel<Movie> {
            Items       = movies,
            CurrentPage = pageNumber,
            PageSize    = pageSize,
            TotalItems  = total
        };
    }

}