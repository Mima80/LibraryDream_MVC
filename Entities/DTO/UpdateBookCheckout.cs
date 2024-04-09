using System.ComponentModel.DataAnnotations;


namespace Entities.DTO
{
    public class UpdateBookCheckout
    {
        [Required]
        public int CheckoutId { get; set; }
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
}
