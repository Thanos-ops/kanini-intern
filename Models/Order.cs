namespace Foodapi.Models;

public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int RestaurantId { get; set; }
    public int AddressId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public User User { get; set; } = null!;
    public Restaurant Restaurant { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public List<OrderItem> OrderItems { get; set; } = new();
}