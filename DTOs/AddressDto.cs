namespace Foodapi.DTOs;

public class AddressDto
{
    public int? Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public int CityId { get; set; }
    public int StateId { get; set; }
    public string? CityName { get; set; }
    public string? StateName { get; set; }
    public bool IsDefault { get; set; }
}