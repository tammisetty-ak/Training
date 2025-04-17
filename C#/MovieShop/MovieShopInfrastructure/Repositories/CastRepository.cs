using Microsoft.EntityFrameworkCore;
using MovieShopCore.Contracts.Repositories;
using MovieShopCore.Entities;
using MovieShopInfrastructure.Data;

namespace MovieShopInfrastructure.Repositories;

public class CastRepository : BaseRepository<Cast>, ICastRepository
{
    public CastRepository(MovieShopDbContext  context):base(context)
    {
        
    }

    public Cast GetCastById(int id)
    {
        var cast = _dbContext.Casts.Include(m => m.Movies).ThenInclude(mc => mc.Movie).FirstOrDefault(m => m.Id == id);
        return cast;
    }
}