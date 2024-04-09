using Entities;
using RepositoryContracts;
using ServiceContracts;

namespace Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task CreateBookAsync(Book book)
        {
            await _bookRepository.AddBookAsync(book);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task UpdateBookAsync(Book updatedBook)
        {
            await _bookRepository.UpdateBookAsync(updatedBook);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }

        public async Task AddCommentAsync(int bookId, Comment comment)
        {
            await _bookRepository.AddCommentAsync(bookId, comment);
        }

        public async Task ReserveBookAsync(int id)
        {
            var book = await GetBookByIdAsync(id);
            book.Reserved = true;
            await UpdateBookAsync(book);
        }

        public async Task ReturnBookAsync(int id)
        {
            var book = await GetBookByIdAsync(id);
            book.Reserved = false;
            await UpdateBookAsync(book);
        }
    }
}