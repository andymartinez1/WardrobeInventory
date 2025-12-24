using Microsoft.EntityFrameworkCore;
using Wardrobe_Inventory.Models;

namespace Wardrobe_Inventory.Data;

public static class SeedDatabase
{
    public static async Task InitializeDataAsync(IServiceProvider serviceProvider)
    {
        using var context = new WardrobeDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<WardrobeDbContext>>()
        );

        // Ensure database exists
        await context.Database.EnsureCreatedAsync();

        // If table already contains data, skip seeding
        if (await context.Items.AnyAsync())
            return;

        var clothingItems = new List<ClothingItem>
        {
            new()
            {
                Name = "Cotton Crewneck T-Shirt",
                Brand = "Everlane",
                Category = ClothingCategory.Shirts,
                Color = "Ocean Stripe",
                ShirtSize = ShirtSize.M,
                ImagePath = "/images/crewneck.jpg"
            },
            new()
            {
                Name = "Dark Wash Straight-Leg Jeans",
                Brand = "Nudie",
                Category = ClothingCategory.Jeans,
                Color = "Dark Indigo",
                JeansInseam = 32,
                JeansWaist = 33,
                ImagePath = "/images/jeans.jpg"
            },
            new()
            {
                Name = "Insulated Parka Jacket",
                Brand = "Arc'teryx",
                Category = ClothingCategory.Jackets,
                Color = "Alpine Green",
                ShirtSize = ShirtSize.L,
                ImagePath = "/images/jacket.jpg"
            },
            new()
            {
                Name = "Fleece Lined Hoodie",
                Brand = "Patagonia",
                Category = ClothingCategory.Jackets,
                Color = "Heather Gray",
                ShirtSize = ShirtSize.L,
                ImagePath = "/images/hoodie.jpg"
            },
            new()
            {
                Name = "Pima Polo Shirt",
                Brand = "Ralph Lauren",
                Category = ClothingCategory.Shirts,
                Color = "Deep Navy",
                ShirtSize = ShirtSize.M,
                ImagePath = "/images/polo.jpg"
            },
            new()
            {
                Name = "Slim Fit Dress Shirt",
                Brand = "Calvin Klein",
                Category = ClothingCategory.Shirts,
                Color = "White Pinstripe",
                ShirtSize = ShirtSize.M,
                ImagePath = "/images/dress-shirt.jpg"
            },
            new()
            {
                Name = "Rinse Slim Jeans",
                Brand = "Levi's",
                Category = ClothingCategory.Jeans,
                Color = "Dark Rinse",
                JeansInseam = 30,
                JeansWaist = 31
            },
            new()
            {
                Name = "Retro White Air Force",
                Brand = "Nike",
                Category = ClothingCategory.Sneakers,
                Color = "White",
                ShoeSize = 11.5m
            },
            new()
            {
                Name = "Performance Road Runners",
                Brand = "Asics",
                Category = ClothingCategory.Sneakers,
                Color = "Black/Reflective",
                ShoeSize = 10.0m
            },
            new()
            {
                Name = "Court Classic Tennis Sneakers",
                Brand = "Adidas",
                Category = ClothingCategory.Sneakers,
                Color = "White/Gum",
                ShoeSize = 9.0m
            },
            new()
            {
                Name = "Oxford Lightweight Shirt",
                Brand = "Banana Republic",
                Category = ClothingCategory.Shirts,
                Color = "Powder Blue",
                ShirtSize = ShirtSize.S
            },
            new()
            {
                Name = "Vintage Band Tee",
                Brand = "H&M",
                Category = ClothingCategory.Shirts,
                Color = "Distressed Red",
                ShirtSize = ShirtSize.M
            },
            new()
            {
                Name = "Classic Chino Pants",
                Brand = "Dockers",
                Category = ClothingCategory.Jeans,
                Color = "Khaki",
                JeansInseam = 32,
                JeansWaist = 34
            },
            new()
            {
                Name = "Cargo Utility Jeans",
                Brand = "Carhartt",
                Category = ClothingCategory.Jeans,
                Color = "Olive Drab",
                JeansInseam = 32,
                JeansWaist = 33
            },
            new()
            {
                Name = "Packable Windbreaker",
                Brand = "The North Face",
                Category = ClothingCategory.Jackets,
                Color = "Electric Blue",
                ShirtSize = ShirtSize.M
            },
            new()
            {
                Name = "Wool Blend Peacoat",
                Brand = "Zara",
                Category = ClothingCategory.Jackets,
                Color = "Charcoal",
                ShirtSize = ShirtSize.L
            },
            new()
            {
                Name = "Breton Striped Henley",
                Brand = "Uniqlo",
                Category = ClothingCategory.Shirts,
                Color = "Navy/White",
                ShirtSize = ShirtSize.S
            },
            new()
            {
                Name = "Stretch Slim Jeans",
                Brand = "Gap",
                Category = ClothingCategory.Jeans,
                Color = "Light Stone",
                JeansInseam = 30,
                JeansWaist = 30
            },
            new()
            {
                Name = "Slip-On Canvas Sneakers",
                Brand = "Vans",
                Category = ClothingCategory.Sneakers,
                Color = "Black",
                ShoeSize = 9.5m
            },
            new()
            {
                Name = "Trail Runner Pro GTX",
                Brand = "Salomon",
                Category = ClothingCategory.Sneakers,
                Color = "Orange/Black",
                ShoeSize = 11.0m
            },
            new()
            {
                Name = "Lightweight Linen Shirt",
                Brand = "J.Crew",
                Category = ClothingCategory.Shirts,
                Color = "Sand",
                ShirtSize = ShirtSize.L
            },
            new()
            {
                Name = "Relaxed Vintage Jeans",
                Brand = "Levi's",
                Category = ClothingCategory.Jeans,
                Color = "Indigo Fade",
                JeansInseam = 34,
                JeansWaist = 34
            },
            new()
            {
                Name = "High-Top Skate Sneakers",
                Brand = "Converse",
                Category = ClothingCategory.Sneakers,
                Color = "Black/White",
                ShoeSize = 10.5m
            },
            new()
            {
                Name = "Softshell Technical Jacket",
                Brand = "Columbia",
                Category = ClothingCategory.Jackets,
                Color = "Stone",
                ShirtSize = ShirtSize.M
            },
            new()
            {
                Name = "Everyday Trainer Sneakers",
                Brand = "New Balance",
                Category = ClothingCategory.Sneakers,
                Color = "Grey",
                ShoeSize = 10.0m
            },
            new()
            {
                Name = "Quilted Down Coat",
                Brand = "Patagonia",
                Category = ClothingCategory.Coats,
                Color = "Marine Blue",
                ShirtSize = ShirtSize.L
            },
            new()
            {
                Name = "Faux Shearling Coat",
                Brand = "Mango",
                Category = ClothingCategory.Coats,
                Color = "Camel",
                ShirtSize = ShirtSize.M
            },
            new()
            {
                Name = "Zip-Up Heavy Hoodie",
                Brand = "Champion",
                Category = ClothingCategory.Hoodies,
                Color = "Black",
                ShirtSize = ShirtSize.L
            },
            new()
            {
                Name = "Pullover Fleece Hoodie",
                Brand = "H&M",
                Category = ClothingCategory.Hoodies,
                Color = "Olive",
                ShirtSize = ShirtSize.M
            },
            new()
            {
                Name = "Classic Baseball Cap",
                Brand = "New Era",
                Category = ClothingCategory.Hats,
                Color = "Navy"
            },
            new()
            {
                Name = "Wool Beanie",
                Brand = "Carhartt",
                Category = ClothingCategory.Hats,
                Color = "Camel"
            },
            new()
            {
                Name = "Corduroy Bucket Hat",
                Brand = "Stüssy",
                Category = ClothingCategory.Hats,
                Color = "Brown"
            },
            new()
            {
                Name = "Cargo Athletic Shorts",
                Brand = "Nike",
                Category = ClothingCategory.Shorts,
                Color = "Black",
                JeansInseam = 9,
                JeansWaist = 32
            },
            new()
            {
                Name = "Relaxed Chino Shorts",
                Brand = "Uniqlo",
                Category = ClothingCategory.Shorts,
                Color = "Khaki",
                JeansInseam = 10,
                JeansWaist = 34
            },
            new()
            {
                Name = "Swim Volley Shorts",
                Brand = "Patagonia",
                Category = ClothingCategory.Shorts,
                Color = "Turquoise",
                JeansInseam = 7,
                JeansWaist = 32
            },
            new()
            {
                Name = "Wool Overcoat",
                Brand = "COS",
                Category = ClothingCategory.Coats,
                Color = "Charcoal",
                ShirtSize = ShirtSize.M
            },
            new()
            {
                Name = "Lightweight Rain Hoodie",
                Brand = "Columbia",
                Category = ClothingCategory.Hoodies,
                Color = "Yellow",
                ShirtSize = ShirtSize.S
            },
            new()
            {
                Name = "Performance Running Shorts",
                Brand = "Adidas",
                Category = ClothingCategory.Shorts,
                Color = "Grey",
                JeansInseam = 5,
                JeansWaist = 30
            },
            new()
            {
                Name = "Fitted Snapback Cap",
                Brand = "Adidas",
                Category = ClothingCategory.Hats,
                Color = "Black/White"
            },
            new()
            {
                Name = "Expedition Parka Coat",
                Brand = "The North Face",
                Category = ClothingCategory.Coats,
                Color = "Forest",
                ShirtSize = ShirtSize.XL
            }
        };

        context.AddRange(clothingItems);

        await context.SaveChangesAsync();
    }
}