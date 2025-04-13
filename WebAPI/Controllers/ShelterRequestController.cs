using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelPaw.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShelterRequestController : ControllerBase
{
    private readonly IShelterRequestService _service;

    public ShelterRequestController(IShelterRequestService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Volunteer")]
    public async Task<IActionResult> CreateRequest([FromBody] ShelterRequestCreateDto dto)
    {
        var volunteerId = GetUserId();
        var created = await _service.CreateRequestAsync(dto, volunteerId);
        return CreatedAtAction(nameof(GetRequests), new { shelterId = created.ShelterId }, created);
    }

    [HttpGet("{shelterId}")]
    [Authorize(Roles = "Shelter")]
    public async Task<IActionResult> GetRequests(Guid shelterId)
    {
        var requests = await _service.GetRequestsForShelterAsync(shelterId);
        return Ok(requests);
    }

    [HttpPut("{requestId}/status")]
    [Authorize(Roles = "Shelter")]
    public async Task<IActionResult> UpdateStatus(Guid requestId, [FromBody] string newStatus)
    {
        await _service.UpdateRequestStatusAsync(requestId, newStatus);
        return NoContent();
    }

    private Guid GetUserId()
    {
        var idClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(idClaim ?? throw new Exception("User ID not found"));
    }
}
