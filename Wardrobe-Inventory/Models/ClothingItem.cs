using System.ComponentModel.DataAnnotations;

namespace Wardrobe_Inventory.Models;

public class ClothingItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ClothingCategory? Category { get; set; }

    public Brand? Brand { get; set; }

    public int Size { get; set; }

    public string Color { get; set; } = string.Empty;

    public bool IsFavorite { get; set; } = false;

    public DateTime? PurchasedDate { get; set; }

    public ICollection<ItemImage>? Images { get; set; }
}
