using Microsoft.AspNetCore.Mvc;
using Foodapi.Services;
using Foodapi.DTOs;

namespace Foodapi.Controllers;

[Route("api/user/[controller]")]
[ApiController]

public class FavoriteController : ControllerBase
{
    private readonly IFavoriteService _favoriteService;

    public FavoriteController(IFavoriteService favoriteService)
    {
        _favoriteService = favoriteService;
    }

    private int GetUserId()
    {
        return 2; // Default user ID for testing
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<FavoriteDto>>>> GetFavorites()
    {
        var favorites = await _favoriteService.GetFavoritesAsync(GetUserId());
        return Ok(ApiResponse<List<FavoriteDto>>.SuccessResponse(favorites));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<FavoriteDto>>> AddFavorite([FromBody] AddFavoriteRequest request)
    {
        var favorite = await _favoriteService.AddFavoriteAsync(GetUserId(), request.RestaurantId, request.RestaurantName);
        return favorite == null
            ? Ok(ApiResponse<FavoriteDto>.ErrorResponse("Failed to add favorite"))
            : Ok(ApiResponse<FavoriteDto>.SuccessResponse(favorite, "Favorite added successfully"));
    }

    [HttpDelete("{restaurantId}")]
    public async Task<ActionResult<ApiResponse<bool>>> RemoveFavorite(int restaurantId)
    {
        var result = await _favoriteService.RemoveFavoriteAsync(GetUserId(), restaurantId);
        return Ok(result
            ? ApiResponse<bool>.SuccessResponse(true, "Favorite removed successfully")
            : ApiResponse<bool>.ErrorResponse("Failed to remove favorite"));
    }
}

public class AddFavoriteRequest
{
    public int RestaurantId { get; set; }
    public string RestaurantName { get; set; } = string.Empty;
}