namespace Core.AddBookRead;

// API, CLI, Blazor
public interface IAddBookRead
{
    Task<bool> AddReadAsync(int userId, string isbn);
}
