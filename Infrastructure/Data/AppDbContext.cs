using HelPaw.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelPaw.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<ShelterRequest> ShelterRequests { get; set; } = null!;
    public DbSet<FavoriteAnimal> FavoriteAnimals { get; set; } = null!;
    public DbSet<AnimalRequest> AnimalRequests { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<Chat> Chats { get; set; } = null!;
    public DbSet<PetStory> PetStories { get; set; } = null!;
    public DbSet<AnimalView> AnimalViews { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<News> News { get; set; } = null!;





    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // 🔹 Конфігурація many-to-many
        modelBuilder.Entity<FavoriteAnimal>()
            .HasKey(f => new { f.UserId, f.AnimalId });

        modelBuilder.Entity<FavoriteAnimal>()
            .HasOne(f => f.User)
            .WithMany(u => u.FavoriteAnimals)
            .HasForeignKey(f => f.UserId);

        modelBuilder.Entity<FavoriteAnimal>()
            .HasOne(f => f.Animal)
            .WithMany()
            .HasForeignKey(f => f.AnimalId);
    }
}
