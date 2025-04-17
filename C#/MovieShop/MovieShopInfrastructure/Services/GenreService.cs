using MovieShopCore.Contracts.Repositories;
using MovieShopCore.Contracts.Services;
using MovieShopCore.Entities;
using MovieShopCore.Models;
using MovieShopInfrastructure.Data;
using MovieShopInfrastructure.Repositories;

namespace MovieShopInfrastructure.Services;

public class GenreService  : IGenreService
{
    private IRepository<Genre> _genreRepository;

    public GenreService(IRepository<Genre> genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public List<GenreModel> GetAllGenres()
    {
        var genres = _genreRepository.GetAll();
        
        var genreModels = new List<GenreModel>();

        foreach (var genre in genres)
        {
            genreModels.Add(new GenreModel()
            {
                Id = genre.Id,
                Name = genre.Name
            });
        }
        return genreModels;
    }
}