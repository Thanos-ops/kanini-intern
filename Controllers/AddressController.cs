using Microsoft.AspNetCore.Mvc;
using Foodapi.Services;
using Foodapi.DTOs;

namespace Foodapi.Controllers;

[Route("api/user/address")]
[ApiController]
//
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    private int GetUserId()
    {
        return 2; // Default user ID for testing
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<AddressDto>>>> GetAddresses()
    {
        var addresses = await _addressService.GetAddressesAsync(GetUserId());
        return Ok(ApiResponse<List<AddressDto>>.SuccessResponse(addresses));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<AddressDto>>> AddAddress([FromBody] AddressDto dto)
    {
        // Debug logging
        Console.WriteLine($"Received DTO: Address={dto?.Address}, CityId={dto?.CityId}, StateId={dto?.StateId}");
        
        if (dto == null)
        {
            return BadRequest(ApiResponse<AddressDto>.ErrorResponse("Request body is null"));
        }
        
        try
        {
            var userId = GetUserId();
            Console.WriteLine($"User ID: {userId}");
            
            var address = await _addressService.AddAddressAsync(userId, dto);
            return address == null
                ? BadRequest(ApiResponse<AddressDto>.ErrorResponse("Failed to add address - check server logs"))
                : CreatedAtAction(nameof(GetAddresses), ApiResponse<AddressDto>.SuccessResponse(address, "Address added successfully"));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Controller Error: {ex.Message}");
            return BadRequest(ApiResponse<AddressDto>.ErrorResponse($"Error: {ex.Message}"));
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateAddress(int id, [FromBody] AddressDto dto)
    {
        var result = await _addressService.UpdateAddressAsync(GetUserId(), id, dto);
        return result
            ? Ok(ApiResponse<bool>.SuccessResponse(true, "Address updated successfully"))
            : NotFound(ApiResponse<bool>.ErrorResponse("Address not found or access denied"));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteAddress(int id)
    {
        var result = await _addressService.DeleteAddressAsync(GetUserId(), id);
        return result
            ? Ok(ApiResponse<bool>.SuccessResponse(true, "Address deleted successfully"))
            : NotFound(ApiResponse<bool>.ErrorResponse("Address not found or access denied"));
    }
}