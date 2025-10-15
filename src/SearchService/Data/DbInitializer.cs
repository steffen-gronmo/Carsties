using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Services;

namespace SearchService.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        Console.WriteLine("Initializing database...");

        await DB.InitAsync(
            "SearchDb",
            MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection"))
        );

        await DB.Index<Item>()
            .Key(x => x.Make, KeyType.Text)
            .Key(x => x.Model, KeyType.Text)
            .Key(x => x.Color, KeyType.Text)
            .CreateAsync();

        var count = await DB.CountAsync<Item>();

        if (count == 0)
        {
            using var scope = app.Services.CreateScope();
            var httpClient = scope.ServiceProvider.GetRequiredService<AuctionServiceHttpClient>();
            var items = await httpClient.GetItemsForSearchDb();

            if (items == null)
            {
                Console.WriteLine("Failed to fetch seed data from AuctionService");
            }
            else
            {
                Console.WriteLine($"Seeding database with {items.Count} items...");
                await DB.SaveAsync(items);
                Console.WriteLine("Database seeded.");
            }
        }

        Console.WriteLine("Database initialized.");
    }

}
