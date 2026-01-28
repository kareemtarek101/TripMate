using Microsoft.Extensions.DependencyInjection;
using TripMate.Application.Users.Interfaces;
using TripMate.Application.Users.Services;
using TripMate.Application.Auth.Interfaces;
using TripMate.Application.Auth.Services;
using TripMate.Application.Destinations.Interfaces;
using TripMate.Application.Destinations.Services;

namespace TripMate.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Users
            services.AddScoped<IUserService, UserService>();

            // Auth
            services.AddScoped<IAuthService, AuthService>();

            // Destinations
            services.AddScoped<IDestinationService, DestinationService>();

            return services;
        }
    }
}
