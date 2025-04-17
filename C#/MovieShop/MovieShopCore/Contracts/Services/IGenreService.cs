using MovieShopCore.Models;

namespace MovieShopCore.Contracts.Services;

public interface IGenreService
{
    public List<GenreModel> GetAllGenres();
}