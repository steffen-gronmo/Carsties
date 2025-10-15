namespace Contracts;

public class AuctionCreated
{
    public Guid Id { get; set; }
    public int ReservePrice { get; set; }
    public string? Seller { get; set; }
    public string? Winner { get; set; }
    public int SoldAmmount { get; set; }
    public int CurrentHighBid { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public required DateTime AuctionEnd { get; set; }
    public required string Status { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public string? Color { get; set; }
    public int Mileage { get; set; }
    public string? ImageUrl { get; set; }
}
