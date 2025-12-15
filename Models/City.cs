namespace Foodapi.Models;

public class City
{
    public int CityId { get; set; }
    public string CityName { get; set; } = string.Empty;
    public int StateId { get; set; }
    public bool IsActive { get; set; } = true;
    
    public State State { get; set; } = null!;
    public List<Restaurant> Restaurants { get; set; } = new();
    public List<Address> Addresses { get; set; } = new();
}