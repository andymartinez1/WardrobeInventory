using Microsoft.EntityFrameworkCore;
using WardrobeInventory.Data;
using WardrobeInventory.Models;
using WardrobeInventory.Services;

namespace WardrobeInventory.Tests;

[TestFixture]
public class ClothingItemServiceTests
{
    private WardrobeDbContext _context;
    private ClothingItemService _service;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<WardrobeDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new WardrobeDbContext(options);
        _service = new ClothingItemService(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task AddClothingItemAsync_ShouldAddItemToDatabase()
    {
        // Arrange
        var item = new ClothingItem
        {
            Name = "Test Shirt",
            Category = ClothingCategory.Shirts,
            Brand = "Test Brand",
            Color = "Blue"
        };

        // Act
        await _service.AddClothingItemAsync(item);

        // Assert
        var savedItem = await _context.Items.FirstOrDefaultAsync();
        Assert.That(savedItem, Is.Not.Null);
        Assert.That(savedItem.Name, Is.EqualTo("Test Shirt"));
    }

    [Test]
    public async Task GetAllClothingItemsAsync_ShouldReturnAllItems()
    {
        // Arrange
        _context.Items.Add(new ClothingItem { Name = "Item 1", Brand = "B1", Color = "C1" });
        _context.Items.Add(new ClothingItem { Name = "Item 2", Brand = "B2", Color = "C2" });
        await _context.SaveChangesAsync();

        // Act
        var items = await _service.GetAllClothingItemsAsync();

        // Assert
        Assert.That(items.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task GetClothingItemAsync_ShouldReturnCorrectItem()
    {
        // Arrange
        var item = new ClothingItem { Name = "Find Me", Brand = "B1", Color = "C1" };
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetClothingItemAsync(item.Id);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo("Find Me"));
    }

    [Test]
    public async Task UpdateClothingItemAsync_ShouldUpdateExistingItem()
    {
        // Arrange
        var item = new ClothingItem { Name = "Old Name", Brand = "B1", Color = "C1" };
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        // Act
        item.Name = "New Name";
        await _service.UpdateClothingItemAsync(item);

        // Assert
        var updatedItem = await _context.Items.FindAsync(item.Id);
        Assert.That(updatedItem.Name, Is.EqualTo("New Name"));
    }

    [Test]
    public async Task DeleteClothingItemAsync_ShouldRemoveItem()
    {
        // Arrange
        var item = new ClothingItem { Name = "Delete Me", Brand = "B1", Color = "C1" };
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        // Act
        await _service.DeleteClothingItemAsync(item.Id);

        // Assert
        var result = await _context.Items.FindAsync(item.Id);
        Assert.That(result, Is.Null);
    }

    [Test]
    public void GetClothingCategories_ShouldReturnAllEnumValues()
    {
        // Act
        var categories = _service.GetClothingCategories();

        // Assert
        var enumValues = Enum.GetValues<ClothingCategory>().Select(e => e.ToString()).ToList();
        Assert.That(categories, Is.EquivalentTo(enumValues));
    }
}
