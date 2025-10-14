using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTOs;

public class CreateAuctionDto
{
    [Required]
    public required string Make { get; set; }
    [Required]
    public required string Model { get; set; }
    [Required]
    public required int Year { get; set; }
    [Required]
    public required string Color { get; set; }
    [Required]
    public required int Mileage { get; set; }
    [Required]
    public required string ImageUrl { get; set; }
    [Required]
    public required int ReservePrice { get; set; }
    [Required]
    public required DateTime AuctionEnd { get; set; }
}
