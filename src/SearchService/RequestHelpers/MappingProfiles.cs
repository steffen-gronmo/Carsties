using AutoMapper;
using Contracts;
using SearchService.Models;

namespace AuctionService.RequestHelpers;

// TODO: Understand mapping better
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AuctionCreated, Item>();
    }
}
