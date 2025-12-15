using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Foodapi.Data;
using Foodapi.DTOs;
using Foodapi.Models;

namespace Foodapi.Services;

public class AddressService : IAddressService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AddressService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AddressDto>> GetAddressesAsync(int userId)
    {
        var addresses = await _context.Addresses
            .Where(a => a.UserId == userId)
            .ToListAsync();
        return _mapper.Map<List<AddressDto>>(addresses);
    }

    public async Task<AddressDto?> AddAddressAsync(int userId, AddressDto dto)
    {
        if (dto == null) throw new ArgumentNullException(nameof(dto));

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            if (dto.IsDefault)
            {
                await _context.Addresses
                    .Where(a => a.UserId == userId)
                    .ExecuteUpdateAsync(a => a.SetProperty(x => x.IsDefault, false));
            }

            var address = _mapper.Map<Address>(dto);
            address.UserId = userId;
            
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            
            await transaction.CommitAsync();
            return _mapper.Map<AddressDto>(address);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            // Log the actual error for debugging
            Console.WriteLine($"AddAddress Error: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            return null;
        }
    }

    public async Task<bool> UpdateAddressAsync(int userId, int addressId, AddressDto dto)
    {
        if (dto == null) throw new ArgumentNullException(nameof(dto));

        var address = await _context.Addresses
            .FirstOrDefaultAsync(a => a.AddressId == addressId && a.UserId == userId);
        
        if (address == null) return false;

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            if (dto.IsDefault)
            {
                await _context.Addresses
                    .Where(a => a.UserId == userId && a.AddressId != addressId)
                    .ExecuteUpdateAsync(a => a.SetProperty(x => x.IsDefault, false));
            }

            _mapper.Map(dto, address);
            await _context.SaveChangesAsync();
            
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> DeleteAddressAsync(int userId, int addressId)
    {
        var address = await _context.Addresses
            .FirstOrDefaultAsync(a => a.AddressId == addressId && a.UserId == userId);
        
        if (address == null) return false;

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
        return true;
    }
}