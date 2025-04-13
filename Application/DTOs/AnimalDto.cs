namespace HelPaw.Application.DTOs;
public class AnimalDto
{
    public Guid Id { get; set; }
    public required string Type { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Size { get; set; } // Small, Medium, Large
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Gender { get; set; }
    public bool? IsVaccinated { get; set; }
    public bool? IsSterilized { get; set; }
    public string? Condition { get; set; }
    public Guid ShelterId { get; set; }
    // для фронту
    public string? ShelterName { get; set; }
    public string? City { get; set; }
}
