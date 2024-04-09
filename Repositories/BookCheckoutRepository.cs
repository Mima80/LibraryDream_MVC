using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories

{
    public class BookCheckoutRepository : IBookCheckoutRepository
    {
        private readonly ProgramDbContext _dbContext;
        private readonly IBookRepository _bookRepository;

        public BookCheckoutRepository(ProgramDbContext dbContext, IBookRepository bookRepository)
        {
            _dbContext = dbContext;
            _bookRepository = bookRepository;
        }

        public async Task<BookCheckout> GetBookCheckoutByIdAsync(int id)
        {
            return await 
                _dbContext.BookCheckouts.Include(bc => bc.Book).FirstOrDefaultAsync(p => p.CheckoutId == id) ??
                   throw new InvalidOperationException();
        }

        public async Task<IEnumerable<BookCheckout>> GetBookCheckoutsAsync()
        {
            return await _dbContext.BookCheckouts.Include(bc => bc.Book).ToListAsync();
        }

        public async Task<BookCheckout> AddBookCheckoutAsync(BookCheckout bookCheckout)
        {
            await _dbContext.BookCheckouts.AddAsync(bookCheckout);
            await _dbContext.SaveChangesAsync();
            return bookCheckout;
        }

        public async Task<BookCheckout> UpdateBookCheckoutAsync(BookCheckout bookCheckout)
        {
            var oldBookCheckout = await GetBookCheckoutByIdAsync(bookCheckout.CheckoutId);

            oldBookCheckout.CheckoutDate = bookCheckout.CheckoutDate;
            oldBookCheckout.ReturnDate = bookCheckout.ReturnDate;
            oldBookCheckout.FullName = bookCheckout.FullName;
            oldBookCheckout.PhoneNumber = bookCheckout.PhoneNumber;
            oldBookCheckout.PostalCode = bookCheckout.PostalCode;
            
            await _dbContext.SaveChangesAsync();

            return bookCheckout;
        }

        public async Task<BookCheckout> DeleteBookCheckoutAsync(int id)
        {
            var bookCheckout = await _dbContext.BookCheckouts.FindAsync(id) ?? throw new InvalidOperationException();
            _dbContext.BookCheckouts.Remove(bookCheckout);
            await _dbContext.SaveChangesAsync();
            return bookCheckout;
        }
    }
}
