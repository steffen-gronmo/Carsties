using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
{
    public async Task Consume(ConsumeContext<AuctionDeleted> context)
    {
        var result = await DB.DeleteAsync<Item>(context.Message.Id);

        if (result.DeletedCount == 0)
        {
            throw new ArgumentException($"Item with ID {context.Message.Id} not found");
        }

        if (result.DeletedCount != 1)
        {
            throw new ArgumentException($"Multiple items with ID {context.Message.Id} found. Deleted count: {result.DeletedCount}");
        }
    }
}
