// Application/DTOs/AnimalRequestDto.cs
namespace HelPaw.Application.DTOs;

public class AnimalRequestDto
{
    public Guid Id { get; set; }
    public string Type { get; set; } = null!;
    public string? Gender { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }
    public string? Size { get; set; }
    public string? Condition { get; set; }
    public Guid VolunteerId { get; set; }
}
