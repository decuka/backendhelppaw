// Application/Interfaces/IFavoriteAnimalService.cs
using HelPaw.Application.DTOs;

namespace HelPaw.Application.Interfaces;

public interface IFavoriteAnimalService
{
    Task AddToFavoritesAsync(Guid userId, Guid animalId);
    Task RemoveFromFavoritesAsync(Guid userId, Guid animalId);
    Task<List<FavoriteAnimalDto>> GetFavoritesAsync(Guid userId);
}
