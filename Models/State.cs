namespace Foodapi.Models;

public class State
{
    public int StateId { get; set; }
    public string StateName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    
    public List<City> Cities { get; set; } = new();
    public List<Restaurant> Restaurants { get; set; } = new();
    public List<Address> Addresses { get; set; } = new();
}