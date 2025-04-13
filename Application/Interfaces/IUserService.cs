using HelPaw.Application.DTOs;

public interface IUserService
{
    Task<UserProfileDto> GetProfileAsync(Guid userId);
    Task UpdateProfileAsync(Guid userId, UserProfileUpdateDto dto);
}
