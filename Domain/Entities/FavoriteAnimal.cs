// Domain/Entities/FavoriteAnimal.cs
using System.ComponentModel.DataAnnotations;

namespace HelPaw.Domain.Entities;

public class FavoriteAnimal
{
    [Key]
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    [Key]
    public Guid AnimalId { get; set; }
    public Animal Animal { get; set; } = null!;
}
