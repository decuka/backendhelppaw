// Domain/Entities/News.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelPaw.Domain.Entities;

public class News
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Content { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public Guid AuthorId { get; set; }

    [ForeignKey(nameof(AuthorId))]
    public User Author { get; set; } = null!;
}
