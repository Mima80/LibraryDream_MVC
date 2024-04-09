using Entities;
using RepositoryContracts;
using ServiceContracts;

namespace Services
{
    public class BookCheckoutService : IBookCheckoutService
    {
        private readonly IBookCheckoutRepository _bookCheckoutRepository;
        private readonly IBookService _bookService;

        public BookCheckoutService(IBookCheckoutRepository bookCheckoutRepository, IBookService bookService)
        {
            _bookCheckoutRepository = bookCheckoutRepository;
            _bookService = bookService;
        }

        public async Task CreateBookCheckoutAsync(BookCheckout bookCheckout)
        {
           await _bookCheckoutRepository.AddBookCheckoutAsync(bookCheckout);
           await _bookService.ReserveBookAsync(bookCheckout.BookId);
        }

        public async Task<BookCheckout> GetBookCheckoutByIdAsync(int id)
        {
            return await _bookCheckoutRepository.GetBookCheckoutByIdAsync(id);
        }

        public async Task<IEnumerable<BookCheckout>> GetAllBookCheckoutsAsync()
        {
            return await _bookCheckoutRepository.GetBookCheckoutsAsync();
        }

        public async Task UpdateBookCheckoutAsync(BookCheckout updatedBookCheckout)
        {
            await _bookCheckoutRepository.UpdateBookCheckoutAsync(updatedBookCheckout);
        }

        public async Task DeleteBookCheckoutAsync(int id)
        {
            await _bookCheckoutRepository.DeleteBookCheckoutAsync(id);
        }

        public async Task CloseBookCheckoutAsync(int id)
        {
            var bookCheckout = await GetBookCheckoutByIdAsync(id);
            bookCheckout.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
            await _bookService.ReturnBookAsync(bookCheckout.Book.BookId);
            await UpdateBookCheckoutAsync(bookCheckout);
        }
    }
}
