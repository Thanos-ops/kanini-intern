namespace Foodapi.Models;

public class MenuCategory
{
    public int CategoryId { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public Restaurant Restaurant { get; set; } = null!;
    public List<MenuItem> MenuItems { get; set; } = new();
}