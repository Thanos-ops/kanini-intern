using Foodapi.DTOs;

namespace Foodapi.Services;

public interface IUserService
{
    Task<UserProfileDto?> GetProfileAsync(int userId);
    Task<bool> UpdateProfileAsync(int userId, UserProfileDto dto);

    Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto dto);
}