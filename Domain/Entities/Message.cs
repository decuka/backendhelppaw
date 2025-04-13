// Domain/Entities/Message.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelPaw.Domain.Entities;
public class Message
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid ChatId { get; set; }

    [Required]
    public Guid SenderId { get; set; }

    [Required]
    public string Content { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public bool IsRead { get; set; } = false;

    [ForeignKey(nameof(ChatId))]
    public Chat Chat { get; set; } = null!;
    public Guid ReceiverId { get; set; } // або public required Guid ReceiverId { get; set; }


    [ForeignKey(nameof(SenderId))]
    public User Sender { get; set; } = null!;
}
