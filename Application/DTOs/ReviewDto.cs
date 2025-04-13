// Application/DTOs/ReviewDto.cs
using System;

namespace HelPaw.Application.DTOs;

public class ReviewDto
{
    public Guid Id { get; set; }
    public Guid ShelterId { get; set; }
    public Guid VolunteerId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}
