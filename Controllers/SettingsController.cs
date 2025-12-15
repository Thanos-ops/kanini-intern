using Microsoft.AspNetCore.Mvc;
using Foodapi.Services;
using Foodapi.DTOs;

namespace Foodapi.Controllers;

[Route("api/user/[controller]")]
[ApiController]

public class SettingsController : ControllerBase
{
    private readonly ISettingsService _settingsService;

    public SettingsController(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    private int GetUserId()
    {
        return 2; // Default user ID for testing
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<UserSettingsDto>>> GetSettings()
    {
        var settings = await _settingsService.GetSettingsAsync(GetUserId());
        return settings == null
            ? Ok(ApiResponse<UserSettingsDto>.ErrorResponse("Settings not found"))
            : Ok(ApiResponse<UserSettingsDto>.SuccessResponse(settings));
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateSettings([FromBody] UserSettingsDto dto)
    {
        var result = await _settingsService.UpdateSettingsAsync(GetUserId(), dto);
        return Ok(result
            ? ApiResponse<bool>.SuccessResponse(true, "Settings updated successfully")
            : ApiResponse<bool>.ErrorResponse("Failed to update settings"));
    }
}