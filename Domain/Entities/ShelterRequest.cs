using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelPaw.Domain.Entities;

public class ShelterRequest
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string AnimalType { get; set; } = null!;

    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Gender { get; set; }
    public string? Size { get; set; }
    public string? ImageUrl { get; set; }

    public bool? IsVaccinated { get; set; }
    public bool? IsSterilized { get; set; }
    public string? Condition { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }

    public string Status { get; set; } = "New"; // New, Approved, Rejected

    // Foreign key: Volunteer who created request
    [Required]
    public Guid VolunteerId { get; set; }

    [ForeignKey("VolunteerId")]
    public User Volunteer { get; set; } = null!;

    // Foreign key: Shelter to which the request is sent
    [Required]
    public Guid ShelterId { get; set; }

    [ForeignKey("ShelterId")]
    public User Shelter { get; set; } = null!;
}
