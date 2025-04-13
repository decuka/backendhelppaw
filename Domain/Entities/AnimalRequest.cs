// Domain/Entities/AnimalRequest.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelPaw.Domain.Entities;

public class AnimalRequest
{
    [Key]
    public Guid Id { get; set; }

    public string Type { get; set; } = null!; // Dog, Cat
    public string? Gender { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }
    public string? Size { get; set; }
    public string? Condition { get; set; }
    public bool IsActive { get; set; } = true;

    [Required]
    public Guid VolunteerId { get; set; }

    [ForeignKey("VolunteerId")]
    public User Volunteer { get; set; } = null!;
}
