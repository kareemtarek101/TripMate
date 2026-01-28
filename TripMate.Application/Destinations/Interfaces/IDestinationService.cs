using TripMate.Application.Destinations.Dtos;

namespace TripMate.Application.Destinations.Interfaces
{
    public interface IDestinationService
    {
        Task<List<DestinationDto>> GetAllAsync();
        Task<DestinationDto?> GetByIdAsync(int id);
    }
}
