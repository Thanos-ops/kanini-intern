namespace Foodapi.Models;

public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public byte[] PasswordHash { get; set; } = new byte[0];
    public byte[] PasswordSalt { get; set; } = new byte[0];
    public int Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
    
    public Role RoleNavigation { get; set; } = null!;
    public List<Address> Addresses { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
    public List<Restaurant> Restaurants { get; set; } = new();
    public List<Cart> Carts { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}