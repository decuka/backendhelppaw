using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelPaw.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto request)
    {
        try
        {
            var result = await _authService.RegisterAsync(request);
            return Ok(new { message = result });
        }
        catch (Exception ex)
        {
            // email already exists
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto request)
    {
        try
        {
            var result = await _authService.LoginAsync(request);
            return Ok(new { token = result });
        }
        catch (Exception ex)
        {
            // invalid credentials
            return Unauthorized(new { message = ex.Message });
        }
    }
}