using Entities;

namespace RepositoryContracts;

public interface IBookCheckoutRepository
{
    Task<BookCheckout> GetBookCheckoutByIdAsync(int id);
    Task<IEnumerable<BookCheckout>> GetBookCheckoutsAsync();

    Task<BookCheckout> AddBookCheckoutAsync(BookCheckout bookCheckout);

    Task<BookCheckout> UpdateBookCheckoutAsync(BookCheckout bookCheckout);

    Task<BookCheckout> DeleteBookCheckoutAsync(int id);
}