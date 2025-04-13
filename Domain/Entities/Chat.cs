// Domain/Entities/Chat.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelPaw.Domain.Entities;

public class Chat
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid User1Id { get; set; }

    [Required]
    public Guid User2Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(User1Id))]
    public User User1 { get; set; } = null!;

    [ForeignKey(nameof(User2Id))]
    public User User2 { get; set; } = null!;

    public ICollection<Message> Messages { get; set; } = new List<Message>();
}
