using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Foodapi.Data;
using Foodapi.DTOs;
using Foodapi.Models;

namespace Foodapi.Services;

public class FavoriteService : IFavoriteService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public FavoriteService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<FavoriteDto>> GetFavoritesAsync(int userId)
    {
        var favorites = await _context.Favorites
            .Where(f => f.UserId == userId)
            .ToListAsync();
        
        return _mapper.Map<List<FavoriteDto>>(favorites);
    }

    public async Task<FavoriteDto?> AddFavoriteAsync(int userId, int restaurantId, string restaurantName)
    {
        var existingFavorite = await _context.Favorites
            .FirstOrDefaultAsync(f => f.UserId == userId && f.RestaurantId == restaurantId);
        
        if (existingFavorite != null) return _mapper.Map<FavoriteDto>(existingFavorite);

        var favorite = new Favorite
        {
            UserId = userId,
            RestaurantId = restaurantId,
            RestaurantName = restaurantName
        };

        _context.Favorites.Add(favorite);
        await _context.SaveChangesAsync();
        
        return _mapper.Map<FavoriteDto>(favorite);
    }

    public async Task<bool> RemoveFavoriteAsync(int userId, int restaurantId)
    {
        var favorite = await _context.Favorites
            .FirstOrDefaultAsync(f => f.UserId == userId && f.RestaurantId == restaurantId);
        
        if (favorite == null) return false;

        _context.Favorites.Remove(favorite);
        await _context.SaveChangesAsync();
        return true;
    }
}