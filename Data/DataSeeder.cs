using Foodapi.Models;

namespace Foodapi.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // Skip seeding since we're using existing database
        return;
    }
}