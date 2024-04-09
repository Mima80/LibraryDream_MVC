using Entities;

namespace RepositoryContracts;

public interface IBookRepository
{
    Task<Book> GetBookByIdAsync(int id);
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book> ReserveBook(int id);
    Task<Book> ReturnBook(int id);
    Task<Book> AddBookAsync(Book book);
    Task<Book> UpdateBookAsync(Book book);
    Task<Book> DeleteBookAsync(int id);
    Task<Book> AddCommentAsync(int bookId, Comment comment);
}