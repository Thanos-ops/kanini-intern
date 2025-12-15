using Foodapi.DTOs;

namespace Foodapi.Services;

public interface IAddressService
{
    Task<List<AddressDto>> GetAddressesAsync(int userId);
    Task<AddressDto?> AddAddressAsync(int userId, AddressDto dto);
    Task<bool> UpdateAddressAsync(int userId, int addressId, AddressDto dto);
    Task<bool> DeleteAddressAsync(int userId, int addressId);
}