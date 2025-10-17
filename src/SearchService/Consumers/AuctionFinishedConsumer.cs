using System;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
{
    public async Task Consume(ConsumeContext<AuctionFinished> context)
    {
        var auction = await DB.Find<Item>().OneAsync(context.Message.AuctionId);
        if (auction == null)
        {
            throw new ArgumentException($"Auction with id {context.Message.AuctionId} not found");
        }

        if (context.Message.ItemSold)
        {
            auction.Winner = context.Message.Winner;
            auction.SoldAmmount = context.Message.Amount ?? 0; // Should always be set.
        }

        auction.Status = "Finished";
        await auction.SaveAsync();
    }
}
