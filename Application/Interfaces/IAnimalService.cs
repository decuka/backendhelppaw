// Application/Interfaces/IAnimalService.cs
using HelPaw.Application.DTOs;
using HelPaw.Application.DTOs.Animal;
using HelPaw.Domain.Entities;

namespace HelPaw.Application.Interfaces;

public interface IAnimalService
{
    Task<AnimalDto> CreateAnimalAsync(AnimalCreateDto dto, Guid shelterId);
    Task<IEnumerable<AnimalDto>> GetAnimalsAsync(AnimalFilterDto filter);
    Task<AnimalDto?> GetAnimalByIdAsync(Guid id);
    Task UpdateAnimalAsync(Guid id, AnimalUpdateDto dto, Guid shelterId);
    Task DeleteAnimalAsync(Guid id, Guid shelterId);
}
