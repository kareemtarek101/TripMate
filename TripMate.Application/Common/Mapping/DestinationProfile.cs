using AutoMapper;
using TripMate.Application.Destinations.Dtos;
using TripMate.Infrastructure.Persistence.Entities;

namespace TripMate.Application.Common.Mapping
{
    public class DestinationProfile : Profile
    {
        public DestinationProfile()
        {
            CreateMap<Destination, DestinationDto>();
        }
    }
}
