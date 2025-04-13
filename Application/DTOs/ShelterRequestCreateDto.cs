namespace HelPaw.Application.DTOs;

public class ShelterRequestCreateDto
{
    public required string AnimalType { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Gender { get; set; }
    public string? Size { get; set; }
    public bool? IsVaccinated { get; set; }
    public bool? IsSterilized { get; set; }
    public string? Condition { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public string? ImageUrl { get; set; }
    public Guid ShelterId { get; set; }
}
