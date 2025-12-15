namespace Foodapi.Models;

public class Favorite
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RestaurantId { get; set; }
    public string RestaurantName { get; set; } = string.Empty;
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public User User { get; set; } = null!;
}