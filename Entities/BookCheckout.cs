using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Entities
{
    public class BookCheckout
    {
        [Key]
        public int CheckoutId { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public DateOnly CheckoutDate { get; set; }

        public DateOnly ReturnDate { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? PostalCode { get; set; }
    }

    public class BookCheckoutValidator : AbstractValidator<BookCheckout>
    {
        public BookCheckoutValidator()
        {
            RuleFor(x => x.CheckoutId).NotNull();
            RuleFor(x => x.BookId).NotNull();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.CheckoutDate).NotEmpty();
            RuleFor(x => x.ReturnDate).NotEmpty();
        }
    }
}
