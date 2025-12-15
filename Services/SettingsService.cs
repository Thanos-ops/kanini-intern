using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Foodapi.Data;
using Foodapi.DTOs;

namespace Foodapi.Services;

public class SettingsService : ISettingsService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public SettingsService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserSettingsDto?> GetSettingsAsync(int userId)
    {
        var settings = await _context.UserSettings
            .FirstOrDefaultAsync(s => s.UserId == userId);
        
        return settings == null ? null : _mapper.Map<UserSettingsDto>(settings);
    }

    public async Task<bool> UpdateSettingsAsync(int userId, UserSettingsDto dto)
    {
        var settings = await _context.UserSettings
            .FirstOrDefaultAsync(s => s.UserId == userId);
        
        if (settings == null) return false;

        _mapper.Map(dto, settings);
        await _context.SaveChangesAsync();
        return true;
    }
}