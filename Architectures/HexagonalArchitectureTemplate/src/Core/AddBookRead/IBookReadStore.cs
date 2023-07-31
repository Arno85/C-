namespace Core.AddBookRead;

// PostegreSQL, SQL Server, MongoDB
public interface IBookReadStore
{
    Task<bool> AddAsync(int userId, string isbn);
}
