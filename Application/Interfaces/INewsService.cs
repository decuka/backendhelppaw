// Application/Interfaces/INewsService.cs
using HelPaw.Application.DTOs;

namespace HelPaw.Application.Interfaces;

public interface INewsService
{
    Task CreateNewsAsync(Guid authorId, NewsCreateDto dto);
    Task<IEnumerable<NewsDto>> GetAllNewsAsync();
}
