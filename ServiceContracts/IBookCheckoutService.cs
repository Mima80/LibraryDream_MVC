using Entities;

namespace ServiceContracts
{
    public interface IBookCheckoutService
    {
        Task CreateBookCheckoutAsync(BookCheckout bookCheckout);
        Task<BookCheckout> GetBookCheckoutByIdAsync(int checkoutId);
        Task<IEnumerable<BookCheckout>> GetAllBookCheckoutsAsync();
        Task UpdateBookCheckoutAsync(BookCheckout updatedBookCheckout);
        Task DeleteBookCheckoutAsync(int id);
        Task CloseBookCheckoutAsync(int id);
    }
}