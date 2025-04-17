using MovieShopCore.Entities;

namespace MovieShopCore.Contracts.Repositories;

public interface ICastRepository  : IRepository<Cast>
{
    Cast GetCastById(int id);
}