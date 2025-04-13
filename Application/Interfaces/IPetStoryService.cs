using HelPaw.Application.DTOs;

namespace HelPaw.Application.Interfaces;
public interface IPetStoryService
{
    Task<IEnumerable<PetStoryDto>> GetAllAsync();
    Task<PetStoryDto?> GetByIdAsync(Guid id);
    Task<PetStoryDto> CreateAsync(PetStoryCreateDto dto, Guid userId);
    Task DeleteAsync(Guid id, Guid userId);
}
