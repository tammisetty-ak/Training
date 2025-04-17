using MovieShopCore.Entities;
using MovieShopCore.Models;

namespace MovieShopCore.Contracts.Services;

public interface ICastService
{
    CastModel GetCastById(int id);
}