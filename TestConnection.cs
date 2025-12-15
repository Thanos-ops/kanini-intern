using Microsoft.EntityFrameworkCore;
using Foodapi.Data;

namespace Foodapi;

public class TestConnection
{
    public static async Task TestDatabaseConnection(AppDbContext context)
    {
        try
        {
            Console.WriteLine("Testing database connection...");
            
            // Test basic connection
            var canConnect = await context.Database.CanConnectAsync();
            Console.WriteLine($"Can connect to database: {canConnect}");
            
            if (canConnect)
            {
                // Test table access
                var roleCount = await context.Roles.CountAsync();
                Console.WriteLine($"Roles count: {roleCount}");
                
                var userCount = await context.Users.CountAsync();
                Console.WriteLine($"Users count: {userCount}");
                
                var stateCount = await context.States.CountAsync();
                Console.WriteLine($"States count: {stateCount}");
                
                var cityCount = await context.Cities.CountAsync();
                Console.WriteLine($"Cities count: {cityCount}");
                
                var restaurantCount = await context.Restaurants.CountAsync();
                Console.WriteLine($"Restaurants count: {restaurantCount}");
                
                Console.WriteLine("Database connection test successful!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database connection test failed: {ex.Message}");
            Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
        }
    }
}