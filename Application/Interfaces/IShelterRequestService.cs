using HelPaw.Application.DTOs;

namespace HelPaw.Application.Interfaces;

public interface IShelterRequestService
{
    Task<ShelterRequestDto> CreateRequestAsync(ShelterRequestCreateDto dto, Guid volunteerId);
    Task<IEnumerable<ShelterRequestDto>> GetRequestsForShelterAsync(Guid shelterId);
    Task UpdateRequestStatusAsync(Guid requestId, string newStatus);
}
