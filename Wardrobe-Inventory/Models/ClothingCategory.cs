using System.ComponentModel.DataAnnotations;

namespace Wardrobe_Inventory.Models;

public class ClothingCategory
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public List<ClothingItem>? Items { get; set; }
}
