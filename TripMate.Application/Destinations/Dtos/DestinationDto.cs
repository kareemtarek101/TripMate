namespace TripMate.Application.Destinations.Dtos
{
    public class DestinationDto
    {
        public int DestinationId { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? City { get; set; }
        public string? Description { get; set; }
        public string? MainImageUrl { get; set; }
        public decimal? AverageRating { get; set; }
        public decimal? MinPriceEstimate { get; set; }
    }
}
