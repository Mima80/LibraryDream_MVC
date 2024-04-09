using Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace LibraryDream.Controllers
{
    [Route("[action]")]
    public class BookController : CustomBaseController<Book>
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService, IValidator<Book> validator) : base(validator)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> ViewAllBooks()
        {
            var result = (await _bookService.GetAllBooksAsync()).Where(p => p.Reserved == false).ToList();
            result.Reverse();
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            if (await ValidateModelAndAddModelErrorsAsync(book))
            {
                await _bookService.CreateBookAsync(book);
                return RedirectToAction("ViewAllBooks");
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> ViewBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.AddCommentAsync(comment.BookId, comment);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return RedirectToAction("ViewBook", new { id = comment.BookId });
        }
    }
}
