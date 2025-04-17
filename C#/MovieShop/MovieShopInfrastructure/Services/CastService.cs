using MovieShopCore.Contracts.Repositories;
using MovieShopCore.Contracts.Services;
using MovieShopCore.Models;

namespace MovieShopInfrastructure.Services;

public class CastService : ICastService
{
    private readonly ICastRepository _castRepository;

    public CastService(ICastRepository castRepository)
    {
        _castRepository = castRepository;
    }

    public CastModel GetCastById(int id)
    {
        var cast =  _castRepository.GetCastById(id);
        var castModel = new CastModel()
        {
            Id = cast.Id,
            Name = cast.Name,
            Gender = cast.Gender,
            ProfilePath = cast.ProfilePath,
            TmdbUrl = cast.TmdbUrl,
            MoviesCastModels = cast.Movies
                .Select(c => new MovieCastModel
                {
                    CastId = c.CastId,
                    MovieId = c.MovieId,
                    Character = c.Character,

                    // map the nested Cast entity into your CastModel DTO
                    MovieCardModel = new MovieCardModel()
                    {
                        Id = c.Movie.Id,
                        Title = c.Movie.Title,
                        PosterURL = c.Movie.PosterUrl
                    }
                })
                .OrderBy(m => m.MovieCardModel.Id)
                .ToList()
        };
        return castModel;
    }
}