using Microsoft.EntityFrameworkCore;
using TripMate.Application.Destinations.Dtos;
using TripMate.Application.Destinations.Interfaces;
using TripMate.Infrastructure.Persistence;

namespace TripMate.Application.Destinations.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly TripMateDbContext _context;

        public DestinationService(TripMateDbContext context)
        {
            _context = context;
        }

        public async Task<List<DestinationDto>> GetAllAsync()
        {
            return await _context.Destinations
                .AsNoTracking()
                .Where(d => d.IsActive)
                .Select(d => new DestinationDto
                {
                    DestinationId = d.DestinationId,
                    Name = d.Name,
                    Country = d.Country,
                    City = d.City,
                    Description = d.Description,
                    MainImageUrl = d.MainImageUrl,
                    AverageRating = d.AverageRating,
                    MinPriceEstimate = d.MinPriceEstimate
                })
                .ToListAsync();
        }

        public async Task<DestinationDto?> GetByIdAsync(int id)
        {
            var d = await _context.Destinations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DestinationId == id && x.IsActive);

            if (d == null)
                return null;

            return new DestinationDto
            {
                DestinationId = d.DestinationId,
                Name = d.Name,
                Country = d.Country,
                City = d.City,
                Description = d.Description,
                MainImageUrl = d.MainImageUrl,
                AverageRating = d.AverageRating,
                MinPriceEstimate = d.MinPriceEstimate
            };
        }
    }
}
