using Microsoft.EntityFrameworkCore;
using Wardrobe_Inventory.Models;

namespace Wardrobe_Inventory.Data;

public static class SeedDatabase
{
    public static async Task InitializeDataAsync(IServiceProvider serviceProvider)
    {
        using (var context = new WardrobeDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<WardrobeDbContext>>()))
        {
            var brands = new List<Brand>
            {
                new() { Name = "Nike" },
                new() { Name = "Adidas" },
                new() { Name = "Under Armour" }
            };

            var categories = new List<ClothingCategory>
            {
                new() { Name = "Shirt" },
                new() { Name = "Jacket" },
                new() { Name = "Jeans" },
                new() { Name = "Shorts" },
                new() { Name = "Shoes" }
            };

            var clothes = new List<ClothingItem>
            {
                new()
                {
                    Brand = brands[0], Category = categories[0], Name = "Nike Class Polo T-shirt",
                    Description = "Polo T-shirt",
                    IsFavorite = true, PurchasedDate = DateTime.Now
                },
                new()
                {
                    Brand = brands[1], Category = categories[4], Name = "Adidas Shoes",
                    Description = "Adidas wide toe shoes",
                    IsFavorite = false, PurchasedDate = DateTime.Now.AddHours(-1)
                }
            };

            context.Brands.AddRange(brands);
            context.Categories.AddRange(categories);

            await context.SaveChangesAsync();
        }
    }
}