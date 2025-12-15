using Foodapi.DTOs;

namespace Foodapi.Services;

public interface ISettingsService
{
    Task<UserSettingsDto?> GetSettingsAsync(int userId);
    Task<bool> UpdateSettingsAsync(int userId, UserSettingsDto dto);
}