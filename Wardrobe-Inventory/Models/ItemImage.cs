using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wardrobe_Inventory.Models;

public class ItemImage
{
    [Key]
    public int Id { get; set; }

    public ClothingItem? ClothingItem { get; set; }

    [Required]
    [MaxLength(2048)]
    public string Url { get; set; } = null!;

    public bool IsPrimary { get; set; } = false;
}
