using WardrobeInventory.Models;

namespace WardrobeInventory.Services;

public interface IClothingItemService
{
    public Task AddClothingItemAsync(ClothingItem item);

    public Task<List<ClothingItem>> GetAllClothingItemsAsync();

    public Task<ClothingItem> GetClothingItemAsync(int id);

    public Task UpdateClothingItemAsync(ClothingItem item);

    public Task DeleteClothingItemAsync(int id);

    public List<string> GetClothingCategories();
}
