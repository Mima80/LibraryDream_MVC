using FluentValidation;

namespace Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<string>? Tags { get; set; }
        public string? Author { get; set; }
        public bool Reserved { get; set; }
        public List<Comment>? Comments { get; set; }
    }

    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Name).NotEmpty().Length(3, 20);
            RuleFor(b => b.Description).NotEmpty().MinimumLength(10);
            //RuleForEach(b => b.Tags).NotEmpty().Length(3, 10);
            RuleFor(b => b.Author).NotEmpty().Length(3, 15);

            RuleForEach(b => b.Comments).ChildRules(comment =>
            {
                comment.RuleFor(c => c.Text).NotEmpty().Length(5, 300);
                comment.RuleFor(c => c.UserName).NotEmpty();
            });
        }
    }
}
