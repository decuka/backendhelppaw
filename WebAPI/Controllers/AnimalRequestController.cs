using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelPaw.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalRequestController : ControllerBase
{
    private readonly IAnimalRequestService _service;

    public AnimalRequestController(IAnimalRequestService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Volunteer")]
    public async Task<IActionResult> Create([FromBody] AnimalRequestCreateDto dto)
    {
        var userId = GetUserId();
        var created = await _service.CreateAsync(dto, userId);
        return CreatedAtAction(nameof(GetAll), new { }, created);
    }

    [HttpGet]
    [Authorize(Roles = "Shelter")]
    public async Task<IActionResult> GetAll()
    {
        var requests = await _service.GetAllAsync();
        return Ok(requests);
    }

    [HttpPut("{id}/deactivate")]
    [Authorize(Roles = "Volunteer")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        var userId = GetUserId();
        await _service.DeactivateAsync(id, userId);
        return NoContent();
    }

    private Guid GetUserId()
    {
        var idClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(idClaim ?? throw new Exception("User ID not found"));
    }
}
