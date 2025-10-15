using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Services;

public class AuctionServiceHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public AuctionServiceHttpClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task<List<Item>?> GetItemsForSearchDb()
    {
        var lastUpdated = await DB.Find<Item, string>()
            .Sort(x => x.UpdatedAt, Order.Descending)
            .Project(x => x.UpdatedAt.ToString())
            .ExecuteFirstAsync();

        var auctionServiceUrl = _configuration["AuctionServiceUrl"];
        if (auctionServiceUrl == null)
        {
            Console.WriteLine("AuctionServiceUrl must be set in the application configuration");
            return null;
        }

        return await _httpClient.GetFromJsonAsync<List<Item>>(auctionServiceUrl + "/api/auctions?date=" + lastUpdated);
    }
}
