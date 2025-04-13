// Application/Interfaces/IAnimalRequestService.cs
using HelPaw.Application.DTOs;

namespace HelPaw.Application.Interfaces;

public interface IAnimalRequestService
{
    Task<AnimalRequestDto> CreateAsync(AnimalRequestCreateDto dto, Guid volunteerId);
    Task<IEnumerable<AnimalRequestDto>> GetAllAsync();
    Task DeactivateAsync(Guid id, Guid userId); // волонтер може деактивувати
}
