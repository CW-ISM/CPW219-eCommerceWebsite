using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;

/// <summary>
/// Represents an individual product for sale
/// </summary>
public class Product
{
    /// <summary>
    /// The unique identifier for the product
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// The user facing name of the product
    /// </summary>
    [Required]
    [StringLength(64, ErrorMessage = "Name cannot be more than 64 characters")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Unique identifier for the product, used for inventory and sales tracking
    /// </summary>
    [StringLength(12, MinimumLength = 8, ErrorMessage = "The SKU must be between {2} and {1} characters long")]
    public string SKU { get; set; } = string.Empty;

    /// <summary>
    /// Brand or manufacturer of the product
    /// </summary>
    /// 
    [StringLength(64, MinimumLength = 1, ErrorMessage = "Brand must be between {2} and {1} characters long")]
    public string Brand { get; set; } = string.Empty;

    /// <summary>
    /// Detailed description of the product
    /// </summary>
    [StringLength(500, ErrorMessage = "Description cannot be more than 500 characters")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The current sales price of the product
    /// </summary>
    [Range(0, 100000)]
    public double Price { get; set; } = 0.0;
}