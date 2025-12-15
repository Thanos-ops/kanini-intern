using Microsoft.EntityFrameworkCore;
using Foodapi.Models;

namespace Foodapi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<MenuCategory> MenuCategories { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<UserSettings> UserSettings { get; set; }
    public DbSet<Favorite> Favorites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("FoodOrderingSystem");

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleID);
            entity.Property(e => e.RoleName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(256);
            entity.Property(e => e.PasswordSalt).IsRequired().HasMaxLength(256);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            
            entity.HasOne(e => e.RoleNavigation)
                  .WithMany(e => e.Users)
                  .HasForeignKey(e => e.Role)
                  .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId);
            entity.Property(e => e.StateName).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.StateName).IsUnique();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId);
            entity.Property(e => e.CityName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            
            entity.HasOne(e => e.State)
                  .WithMany(e => e.Cities)
                  .HasForeignKey(e => e.StateId);
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestaurantId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            
            entity.HasOne(e => e.User)
                  .WithMany(e => e.Restaurants)
                  .HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.City)
                  .WithMany(e => e.Restaurants)
                  .HasForeignKey(e => e.CityId);
            entity.HasOne(e => e.State)
                  .WithMany(e => e.Restaurants)
                  .HasForeignKey(e => e.StateId);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId);
            entity.Property(e => e.AddressLine).HasMaxLength(300);
            entity.Property(e => e.IsDefault).HasDefaultValue(false);
            
            entity.HasOne(e => e.User)
                  .WithMany(e => e.Addresses)
                  .HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.City)
                  .WithMany(e => e.Addresses)
                  .HasForeignKey(e => e.CityId);
            entity.HasOne(e => e.State)
                  .WithMany(e => e.Addresses)
                  .HasForeignKey(e => e.StateId);
        });

        modelBuilder.Entity<MenuCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            
            entity.HasOne(e => e.Restaurant)
                  .WithMany(e => e.MenuCategories)
                  .HasForeignKey(e => e.RestaurantId);
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.MenuItemId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Price).HasColumnType("decimal(10,2)").IsRequired();
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            
            entity.HasOne(e => e.Category)
                  .WithMany(e => e.MenuItems)
                  .HasForeignKey(e => e.CategoryId);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            
            entity.HasOne(e => e.User)
                  .WithMany(e => e.Carts)
                  .HasForeignKey(e => e.UserId);
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId);
            
            entity.HasOne(e => e.Cart)
                  .WithMany(e => e.CartItems)
                  .HasForeignKey(e => e.CartId);
            entity.HasOne(e => e.MenuItem)
                  .WithMany(e => e.CartItems)
                  .HasForeignKey(e => e.MenuItemId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10,2)").IsRequired();
            entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            
            entity.HasOne(e => e.User)
                  .WithMany(e => e.Orders)
                  .HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.Restaurant)
                  .WithMany(e => e.Orders)
                  .HasForeignKey(e => e.RestaurantId);
            entity.HasOne(e => e.Address)
                  .WithMany(e => e.Orders)
                  .HasForeignKey(e => e.AddressId);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);
            entity.Property(e => e.Price).HasColumnType("decimal(10,2)").IsRequired();
            
            entity.HasOne(e => e.Order)
                  .WithMany(e => e.OrderItems)
                  .HasForeignKey(e => e.OrderId);
            entity.HasOne(e => e.MenuItem)
                  .WithMany(e => e.OrderItems)
                  .HasForeignKey(e => e.MenuItemId);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId);
            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.UserId).HasColumnName("customer_id");
            entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
            
            entity.HasOne(e => e.User)
                  .WithMany(e => e.Reviews)
                  .HasForeignKey(e => e.UserId)
                  .HasConstraintName("FK_Reviews_Users");
            entity.HasOne(e => e.Restaurant)
                  .WithMany(e => e.Reviews)
                  .HasForeignKey(e => e.RestaurantId)
                  .HasConstraintName("FK_Reviews_Restaurants");
        });

        modelBuilder.Entity<UserSettings>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.User)
                  .WithOne()
                  .HasForeignKey<UserSettings>(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.User)
                  .WithMany()
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}