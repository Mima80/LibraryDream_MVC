using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ProgramDbContext _dbContext;

        public BookRepository(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.Include(p => p.Comments).FirstOrDefaultAsync(p => p.BookId == id) ?? 
                   throw new InvalidOperationException();
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.Include(p => p.Comments).ToListAsync();
        }

        public async Task<Book> ReserveBook(int id)
        {
            var book = await GetBookByIdAsync(id);
            book.Reserved = true;
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> ReturnBook(int id)
        {
            var book = await GetBookByIdAsync(id);
            book.Reserved = false;
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var oldBook = await GetBookByIdAsync(book.BookId);

            oldBook.Name = book.Name;
            oldBook.Description = book.Description;
            oldBook.Reserved = book.Reserved;
            oldBook.Comments = book.Comments;
            oldBook.Author = book.Author;
            oldBook.Tags = book.Tags;

            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBookAsync(int id)
        {
            var book = await GetBookByIdAsync(id);
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> AddCommentAsync(int bookId, Comment comment)
        {
            var book = await GetBookByIdAsync(bookId);
            book.Comments ??= new List<Comment>();
            book.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();
            return book;
        }
    }
}
