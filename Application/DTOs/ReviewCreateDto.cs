// Application/DTOs/ReviewCreateDto.cs
namespace HelPaw.Application.DTOs;

public class ReviewCreateDto
{
    public Guid ShelterId { get; set; }           // Притулок, якому лишають відгук
    public int Rating { get; set; }               // Оцінка (1-5)
    public string? Comment { get; set; }          // Коментар (необов'язково)
}
