using Foodapi.DTOs;

namespace Foodapi.Services;

public interface IFavoriteService
{
    Task<List<FavoriteDto>> GetFavoritesAsync(int userId);
    Task<FavoriteDto?> AddFavoriteAsync(int userId, int restaurantId, string restaurantName);
    Task<bool> RemoveFavoriteAsync(int userId, int restaurantId);
}