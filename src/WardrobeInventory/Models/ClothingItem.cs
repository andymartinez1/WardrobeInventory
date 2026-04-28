using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WardrobeInventory.Models;

public class ClothingItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;

    public ClothingCategory Category { get; set; }

    [Required]
    [MaxLength(30)]
    public string Brand { get; set; } = string.Empty;

    public ShirtSize? ShirtSize { get; set; }

    [Column(TypeName = "decimal(4,1)")]
    [DisplayFormat(DataFormatString = "{0:N1}", ApplyFormatInEditMode = true)]
    public decimal? ShoeSize { get; set; }

    public int? JeansWaist { get; set; }

    public int? JeansInseam { get; set; }

    [Required]
    [MaxLength(20)]
    public string Color { get; set; } = string.Empty;

    public string? ImagePath { get; set; } = string.Empty;
}

public enum ClothingCategory
{
    Shirts,
    Jeans,
    Shorts,
    Jackets,
    Coats,
    Hoodies,
    Boots,
    Sneakers,
    Hats,
}

public enum ShirtSize
{
    S,
    M,
    L,
    XL,
    XXL,
}
