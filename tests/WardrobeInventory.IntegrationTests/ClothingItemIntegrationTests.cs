using Microsoft.Extensions.DependencyInjection;
using WardrobeInventory.Data;
using WardrobeInventory.Models;
using WardrobeInventory.Services;

namespace WardrobeInventory.IntegrationTests;

[TestFixture]
public class ClothingItemIntegrationTests
{
    private WardrobeWebApplicationFactory<Program> _factory;
    private IServiceScope _scope;
    private IClothingItemService _service;
    private WardrobeDbContext _context;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _factory = new WardrobeWebApplicationFactory<Program>();
    }

    [SetUp]
    public void SetUp()
    {
        _scope = _factory.Services.CreateScope();
        _service = _scope.ServiceProvider.GetRequiredService<IClothingItemService>();
        _context = _scope.ServiceProvider.GetRequiredService<WardrobeDbContext>();
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
        _scope.Dispose();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _factory.Dispose();
    }

    [Test]
    public async Task AddAndRetrieveClothingItem_ShouldWorkInIntegratedEnvironment()
    {
        // Arrange
        var item = new ClothingItem
        {
            Name = "Integration Test Jacket",
            Category = ClothingCategory.Jackets,
            Brand = "Integration Brand",
            Color = "Black",
        };

        // Act
        await _service.AddClothingItemAsync(item);
        var items = await _service.GetAllClothingItemsAsync();

        // Assert
        Assert.That(items, Is.Not.Empty);
        Assert.That(items.First().Name, Is.EqualTo("Integration Test Jacket"));
    }

    [Test]
    public async Task DeleteClothingItem_ShouldRemoveFromDatabase()
    {
        // Arrange
        var item = new ClothingItem
        {
            Name = "To Delete",
            Category = ClothingCategory.Shorts,
            Brand = "Brand",
            Color = "Red",
        };
        await _service.AddClothingItemAsync(item);
        var addedItem = (await _service.GetAllClothingItemsAsync()).First();

        // Act
        await _service.DeleteClothingItemAsync(addedItem.Id);
        var itemsAfterDelete = await _service.GetAllClothingItemsAsync();

        // Assert
        Assert.That(itemsAfterDelete, Is.Empty);
    }
}
