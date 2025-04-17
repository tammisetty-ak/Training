using Microsoft.EntityFrameworkCore;
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
}