using AuctionService.Data;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Controllers;

[ApiController]
[Route("api/auctions")]
public class AuctionsController : ControllerBase
{
    private readonly AuctionDbContext _auctionDbContext;
    private readonly IMapper _mapper;

    public AuctionsController(AuctionDbContext auctionDbContext, IMapper mapper)
    {
        _auctionDbContext = auctionDbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuctionDto>>> GetAuctions()
    {
        var auctions = await _auctionDbContext.Auctions
            .Include(x => x.Item)
            .OrderBy(x => x.Item.Make)
            .ToListAsync();

        return Ok(_mapper.Map<List<AuctionDto>>(auctions));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid id)
    {
        var auction = await _auctionDbContext.Auctions
            .Include(x => x.Item)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (auction == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<AuctionDto>(auction));
    }

    [HttpPost]
    public async Task<ActionResult<AuctionDto>> CreateAuction(CreateAuctionDto createAuctionDto)
    {
        var auction = _mapper.Map<Auction>(createAuctionDto);

        // TODO: Add auth + add current user as seller
        auction.Seller = "test-user";

        _auctionDbContext.Auctions.Add(auction);
        var result = await _auctionDbContext.SaveChangesAsync() > 0;

        if (!result)
        {
            return BadRequest("Failed to create auction");
        }


        return CreatedAtAction(
            nameof(GetAuctionById),
            new { auction.Id },
            _mapper.Map<AuctionDto>(auction)
        );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAuction(Guid id, UpdateAuctionDto updateAuctionDto)
    {
        var auction = await _auctionDbContext.Auctions
            .Include(x => x.Item)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (auction == null)
        {
            return NotFound();
        }

        // TODO: Verify that the user can update the auction.
        auction.Item.Make = updateAuctionDto.Make ?? auction.Item.Make;
        auction.Item.Model = updateAuctionDto.Model ?? auction.Item.Model;
        auction.Item.Color = updateAuctionDto.Color ?? auction.Item.Color;
        auction.Item.Mileage = updateAuctionDto.Mileage ?? auction.Item.Mileage;
        auction.Item.Year = updateAuctionDto.Year ?? auction.Item.Year;

        var result = await _auctionDbContext.SaveChangesAsync() > 0;

        if (!result)
        {
            return BadRequest("Failed to update auction");
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuction(Guid id)
    {
        var auction = await _auctionDbContext.Auctions.FindAsync(id);

        if (auction == null)
        {
            return NotFound();
        }

        // TODO: Authorization to verify that the user can delete the auction.

        _auctionDbContext.Auctions.Remove(auction);
        var result = await _auctionDbContext.SaveChangesAsync() > 0;

        if (!result)
        {
            return BadRequest("Failed to delete auction");
        }

        return Ok();
    }
}
