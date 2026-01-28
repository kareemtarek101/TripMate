using Microsoft.EntityFrameworkCore;
using TripMate.Application.Users.Dtos;
using TripMate.Application.Users.Interfaces;
using TripMate.Infrastructure.Persistence;

namespace TripMate.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly TripMateDbContext _context;

        public UserService(TripMateDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> GetProfileAsync(int userId)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == userId && u.IsActive);

            if (user == null)
                return null;

            return new UserDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                ProfileImageUrl = user.ProfileImageUrl,
                PreferredLanguage = user.PreferredLanguage,
                PreferredCurrency = user.PreferredCurrency
            };
        }

        public async Task<bool> UpdateProfileAsync(int userId, UpdateUserProfileRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId && u.IsActive);

            if (user == null)
                return false;

            user.FullName = request.FullName;
            user.Phone = request.Phone;
            user.ProfileImageUrl = request.ProfileImageUrl;
            user.PreferredLanguage = request.PreferredLanguage;
            user.PreferredCurrency = request.PreferredCurrency;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
