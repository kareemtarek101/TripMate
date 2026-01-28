using Microsoft.EntityFrameworkCore;
using TripMate.Application.Auth.Dtos;
using TripMate.Application.Auth.Interfaces;
using TripMate.Infrastructure.Persistence;
using TripMate.Infrastructure.Security;

namespace TripMate.Application.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly TripMateDbContext _context;

        public AuthService(TripMateDbContext context)
        {
            _context = context;
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Email == request.Email &&
                    u.IsActive);

            if (user == null)
                return null;

            if (!PasswordHasher.VerifyPassword(
                request.Password,
                user.PasswordHash))
                return null;

            return new AuthResponse
            {
                Email = user.Email,
                FullName = user.FullName,
                Token = "TEMP_TOKEN"
            };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var exists = await _context.Users
                .AnyAsync(u => u.Email == request.Email);



            if (exists)
                throw new Exception("Email already exists");

            var role = await  _context.Roles.FirstOrDefaultAsync(x => x.Name == "Traveller");
            if (role is null)
            {
                throw new Exception("Role doesn't exists");

            }

            var user = new Infrastructure.Persistence.Entities.User
            {
                FullName = request.FullName,
                Email = request.Email,
                Phone = request.Phone,
                PasswordHash = PasswordHasher.HashPassword(request.Password),
                RoleId = role.RoleId,//***
                IsActive = true,
                EmailVerified = false,
                PhoneVerified = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AuthResponse
            {
                Email = user.Email,
                FullName = user.FullName,
                Token = "TEMP_TOKEN"
            };
        }
    }
}
