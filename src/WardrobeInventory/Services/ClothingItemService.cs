using Microsoft.EntityFrameworkCore;
using WardrobeInventory.Data;
using WardrobeInventory.Models;

namespace WardrobeInventory.Services;

public class ClothingItemService : IClothingItemService
{
    private readonly WardrobeDbContext _wardrobeDbContext;

    public ClothingItemService(WardrobeDbContext wardrobeDbContext)
    {
        _wardrobeDbContext = wardrobeDbContext;
    }

    public async Task AddClothingItemAsync(ClothingItem item)
    {
        await _wardrobeDbContext.Items.AddAsync(item);

        await _wardrobeDbContext.SaveChangesAsync();
    }

    public async Task<List<ClothingItem>> GetAllClothingItemsAsync()
    {
        var items = _wardrobeDbContext.Items.ToListAsync();

        return await items;
    }

    public async Task<ClothingItem> GetClothingItemAsync(int id)
    {
        return await _wardrobeDbContext.Items.FindAsync(id);
    }

    public async Task UpdateClothingItemAsync(ClothingItem item)
    {
        _wardrobeDbContext.Items.Update(item);

        await _wardrobeDbContext.SaveChangesAsync();
    }

    public async Task DeleteClothingItemAsync(int id)
    {
        var item = await GetClothingItemAsync(id);

        _wardrobeDbContext.Items.Remove(item);

        await _wardrobeDbContext.SaveChangesAsync();
    }

    public List<string> GetClothingCategories()
    {
        var Categories = new List<string>();

        foreach (ClothingCategory category in Enum.GetValues(typeof(ClothingCategory)))
            Categories.Add(category.ToString());

        return Categories;
    }
}
