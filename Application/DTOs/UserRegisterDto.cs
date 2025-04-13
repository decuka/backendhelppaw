namespace HelPaw.Application.DTOs;

public class UserRegisterDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Role { get; set; } = default!; // shelter / volunteer
}
