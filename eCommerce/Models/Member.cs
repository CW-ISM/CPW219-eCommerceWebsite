using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;

/// <summary>
/// Represents a individual website user
/// </summary>
public class Member
{
    [Key]
    public int MemberId { get; set; }

    /// <summary>
    /// Public facing username for the member
    /// Alphanumeric characters only, 3 to 32 characters long
    /// </summary>
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Username can only contain alphanumeric characters")]
    [StringLength(32, MinimumLength = 3, ErrorMessage = "Username must be between {2} and {1} characters long")]
    public required string Username { get; set; }

    /// <summary>
    /// The email address of the member
    /// </summary>
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address format")]
    public required string Email { get; set; }

    /// <summary>
    /// The password for the member account
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between {2} and {1} characters long")]
    public required string Password { get; set; }

    /// <summary>
    /// The date of birth of the member
    /// </summary>
    [Required]
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
}

public class RegisterationViewModel
{
    /// <summary>
    /// Public facing username for the member
    /// Alphanumeric characters only, 3 to 32 characters long
    /// </summary>
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Username can only contain alphanumeric characters")]
    [StringLength(32, MinimumLength = 3, ErrorMessage = "Username must be between {2} and {1} characters long")]
    public required string Username { get; set; }

    /// <summary>
    /// The email address of the member
    /// </summary>
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address format")]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    /// <summary>
    /// The password for the member account
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between {2} and {1} characters long")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    [DataType(DataType.Password)]
    public required string ConfirmPassword { get; set; }

    /// <summary>
    /// The date of birth of the member
    /// </summary>
    [Required]
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
}