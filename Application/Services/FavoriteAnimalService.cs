// Application/Services/FavoriteAnimalService.cs
using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using HelPaw.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelPaw.Application.Services;

public class FavoriteAnimalService : IFavoriteAnimalService
{
    private readonly AppDbContext _context;

    public FavoriteAnimalService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddToFavoritesAsync(Guid userId, Guid animalId)
    {
        var exists = await _context.FavoriteAnimals
            .AnyAsync(f => f.UserId == userId && f.AnimalId == animalId);

        if (!exists)
        {
            _context.FavoriteAnimals.Add(new Domain.Entities.FavoriteAnimal
            {
                UserId = userId,
                AnimalId = animalId
            });
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveFromFavoritesAsync(Guid userId, Guid animalId)
    {
        var entity = await _context.FavoriteAnimals
            .FirstOrDefaultAsync(f => f.UserId == userId && f.AnimalId == animalId);

        if (entity != null)
        {
            _context.FavoriteAnimals.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<FavoriteAnimalDto>> GetFavoritesAsync(Guid userId)
    {
        return await _context.FavoriteAnimals
            .Where(f => f.UserId == userId)
            .Select(f => new FavoriteAnimalDto
            {
                AnimalId = f.Animal.Id,
                Name = f.Animal.Name,
                Type = f.Animal.Type,
                ImageUrl = f.Animal.ImageUrl
            })
            .ToListAsync();
    }
}
