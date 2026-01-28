namespace TripMate.Application.Users.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? PreferredLanguage { get; set; }
        public string? PreferredCurrency { get; set; }
    }
}
