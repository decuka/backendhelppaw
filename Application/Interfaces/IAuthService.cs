using HelPaw.Application.DTOs;

namespace HelPaw.Application.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(UserRegisterDto dto); // returns JWT
    Task<string> LoginAsync(UserLoginDto dto);       // returns JWT
}
