namespace Foodapi.Models;

public class Cart
{
    public int CartId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public User User { get; set; } = null!;
    public List<CartItem> CartItems { get; set; } = new();
}