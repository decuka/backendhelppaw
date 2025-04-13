// Application/Interfaces/IAnimalViewService.cs
using HelPaw.Application.DTOs;

namespace HelPaw.Application.Interfaces;

public interface IAnimalViewService
{
    Task RecordViewAsync(Guid animalId, Guid? userId);
    Task<int> GetTotalViewsAsync(Guid animalId);
    Task<int> GetUniqueUserViewsAsync(Guid animalId);
}
