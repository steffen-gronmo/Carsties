namespace Contracts;

public class AuctionUpdated
{
    public required string Id { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public required int Year { get; set; }
    public string? Color { get; set; }
    public required int Mileage { get; set; }
}
