using Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace LibraryDream.Controllers
{
    [Authorize]
    [Route("[action]")]
    public class CheckoutController : CustomBaseController<BookCheckout>
    {
        private readonly IBookCheckoutService _bookCheckoutService;

        public CheckoutController(IBookCheckoutService bookCheckoutService, IValidator<BookCheckout> validator) : base(validator)
        {
            _bookCheckoutService = bookCheckoutService;
        }

        [HttpGet]
        public async Task<IActionResult> AddCheckout(int bookId)
        {
            return View(new BookCheckout { BookId = bookId });
        }

        [HttpPost]
        public async Task<IActionResult> AddCheckout([FromForm] BookCheckout bookCheckout)
        {
            if (!await ValidateModelAndAddModelErrorsAsync(bookCheckout)) return View(bookCheckout);
            await _bookCheckoutService.CreateBookCheckoutAsync(bookCheckout);
            return RedirectToAction("ViewMyCheckouts");
        }

        [HttpGet]
        public async Task<IActionResult> ViewMyCheckouts()
        {
            return View((await _bookCheckoutService.GetAllBookCheckoutsAsync()).Where(p => p.UserName == User.Identity.Name).ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ViewAllCheckouts()
        {
            var result = (await _bookCheckoutService.GetAllBookCheckoutsAsync()).Where(p => p.ReturnDate == DateOnly.MinValue).ToList();
            result.Reverse();
            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CloseCheckout(int checkoutId)
        {
            await _bookCheckoutService.CloseBookCheckoutAsync(checkoutId);
            return RedirectToAction("ViewAllCheckouts");
        }
    }
}
