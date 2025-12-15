namespace Foodapi.Models;

public class Restaurant
{
    public int RestaurantId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Address { get; set; }
    public int CityId { get; set; }
    public int StateId { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public User User { get; set; } = null!;
    public City City { get; set; } = null!;
    public State State { get; set; } = null!;
    public List<MenuCategory> MenuCategories { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}