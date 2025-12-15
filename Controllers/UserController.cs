using Microsoft.AspNetCore.Mvc;
using Foodapi.Services;
using Foodapi.DTOs;

namespace Foodapi.Controllers;

[Route("api/[controller]")]
[ApiController]


public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    private int GetUserId()
    {
        return 2; // Default user ID for testing
    }

    [HttpGet("profile")]
    public async Task<ActionResult<ApiResponse<UserProfileDto>>> GetProfile()
    {
        var profile = await _userService.GetProfileAsync(GetUserId());
        return profile == null 
            ? Ok(ApiResponse<UserProfileDto>.ErrorResponse("Profile not found"))
            : Ok(ApiResponse<UserProfileDto>.SuccessResponse(profile));
    }

    [HttpPut("profile")]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateProfile([FromBody] UserProfileDto dto)
    {
        var result = await _userService.UpdateProfileAsync(GetUserId(), dto);
        return Ok(result 
            ? ApiResponse<bool>.SuccessResponse(true, "Profile updated successfully")
            : ApiResponse<bool>.ErrorResponse("Failed to update profile"));
    }



    [HttpPut("change-password")]
    public async Task<ActionResult<ApiResponse<bool>>> ChangePassword([FromBody] ChangePasswordDto dto)
    {
        var result = await _userService.ChangePasswordAsync(GetUserId(), dto);
        return Ok(result
            ? ApiResponse<bool>.SuccessResponse(true, "Password changed successfully")
            : ApiResponse<bool>.ErrorResponse("Failed to change password"));
    }
}