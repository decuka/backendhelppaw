// Domain/Entities/Review.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelPaw.Domain.Entities;

public class Review
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid ShelterId { get; set; }

    [Required]
    public Guid VolunteerId { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(ShelterId))]
    public User Shelter { get; set; } = null!;

    [ForeignKey(nameof(VolunteerId))]
    public User Volunteer { get; set; } = null!;
}
