namespace HelPaw.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string Role { get; set; }
    public string? FullName { get; set; }
    public string? City { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Description { get; set; }
    public string? ShelterCategory { get; set; } // Ветклініка, Притулок для собак, тощо
    public ICollection<FavoriteAnimal> FavoriteAnimals { get; set; } = new List<FavoriteAnimal>();

}


