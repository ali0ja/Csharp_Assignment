

using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class ContactRegistrationForm
{
    [Required (ErrorMessage ="First name is required")]
    [MinLength (2,ErrorMessage ="First name must contain at least two characters")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Last name must contain at least two characters")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email must be in a valid format like username@domain.com ")]
    public string Email { get; set; } = null!;

    //[Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^\+?[1-9]\d{9,14}$", ErrorMessage = "Phone number must be in a valid international format, e.g., +1234567890")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Street address is required")]
    [MinLength(5, ErrorMessage = "Street address must contain at least five characters")]
    public string StreetAddress { get; set; } = null!;

    [Required(ErrorMessage = "Postal code is required")]
    [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Postal code must be in a valid format like 12345 or 12345-6789")]
    public string PostalCode { get; set; } = null!;

    [Required(ErrorMessage = "City is required")]
    [MinLength(2, ErrorMessage = "City must contain at least two characters")]
    public string City { get; set; } = null!;
}
