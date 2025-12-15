using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Foodapi.Data;
using Foodapi.DTOs;
using Foodapi.Models;

namespace Foodapi.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public UserService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserProfileDto?> GetProfileAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        return user == null ? null : _mapper.Map<UserProfileDto>(user);
    }

    public async Task<bool> UpdateProfileAsync(int userId, UserProfileDto dto)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) return false;

        _mapper.Map(dto, user);
        await _context.SaveChangesAsync();
        return true;
    }



    public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto dto)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, System.Text.Encoding.UTF8.GetString(user.PasswordHash)))
            return false;

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
        user.PasswordHash = System.Text.Encoding.UTF8.GetBytes(hashedPassword);
        await _context.SaveChangesAsync();
        return true;
    }
}