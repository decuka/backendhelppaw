public class UserProfileDto
{
    public required string Email { get; set; }
    public string? FullName { get; set; }
    public string? City { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Description { get; set; }
    public string Role { get; set; } = null!;
    public string? ShelterCategory { get; set; }

}
