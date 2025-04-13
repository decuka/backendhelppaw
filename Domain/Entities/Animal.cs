// Domain/Entities/Animal.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelPaw.Domain.Entities;

public class Animal
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public required string Type { get; set; }// Dog, Cat, etc.

    [Required]
    public required string Name { get; set; }
    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? Size { get; set; } // Small, Medium, Large

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    // Health status
    public bool? IsVaccinated { get; set; }

    public bool? IsSterilized { get; set; }

    public string? Condition { get; set; } // e.g. Healthy, Injured, Sick

    [Required]
    public Guid ShelterId { get; set; }

    [ForeignKey("ShelterId")]
    public User Shelter { get; set; } = null!;
}
