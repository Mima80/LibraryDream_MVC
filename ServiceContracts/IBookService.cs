using Entities;

namespace ServiceContracts
{
    public interface IBookService
    {
        Task CreateBookAsync(Book book);
        Task<Book> GetBookByIdAsync(int bookId);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task UpdateBookAsync(Book updatedBook);
        Task DeleteBookAsync(int bookId);
        Task AddCommentAsync(int bookId, Comment comment);
        Task ReserveBookAsync(int id);
        Task ReturnBookAsync(int id);
    }
}

