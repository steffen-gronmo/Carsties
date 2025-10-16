using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionUpdatedConsumer : IConsumer<AuctionUpdated>
{
    public async Task Consume(ConsumeContext<AuctionUpdated> context)
    {
        var item = await DB.Find<Item>().MatchID(context.Message.Id).ExecuteFirstAsync();

        if (item == null)
        {
            throw new ArgumentException($"Item with ID {context.Message.Id} not found");
        }
        
        item.Make = context.Message.Make ?? item.Make;
        item.Model = context.Message.Model ?? item.Model;
        item.Color = context.Message.Color ?? item.Color;
        item.Mileage = context.Message.Mileage ?? item.Mileage;
        item.Year = context.Message.Year ?? item.Year;

        await item.SaveAsync();
    }
}
