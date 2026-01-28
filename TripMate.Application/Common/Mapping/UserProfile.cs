using AutoMapper;
using TripMate.Application.Users.Dtos;
using TripMate.Infrastructure.Persistence.Entities;

namespace TripMate.Application.Common.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
