// Domain/Entities/AnimalView.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelPaw.Domain.Entities;

public class AnimalView
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid AnimalId { get; set; }

    public Guid? UserId { get; set; } // null якщо переглядав гість

    public DateTime ViewedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(AnimalId))]
    public Animal Animal { get; set; } = null!;
}
