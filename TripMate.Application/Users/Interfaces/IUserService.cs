using TripMate.Application.Users.Dtos;

namespace TripMate.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetProfileAsync(int userId);
        Task<bool> UpdateProfileAsync(int userId, UpdateUserProfileRequest request);
    }
}
