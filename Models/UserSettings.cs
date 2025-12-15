namespace Foodapi.Models;

public class UserSettings
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public bool Notifications { get; set; }
    public bool EmailUpdates { get; set; }
    public bool SmsUpdates { get; set; }
    public bool OrderUpdates { get; set; }
    public bool Promotions { get; set; }
    public User User { get; set; } = null!;
}