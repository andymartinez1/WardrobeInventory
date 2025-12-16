using Microsoft.EntityFrameworkCore;
using Wardrobe_Inventory.Models;

namespace Wardrobe_Inventory.Data;

public class WardrobeDbContext : DbContext
{
    public WardrobeDbContext(DbContextOptions<WardrobeDbContext> options) : base(options)
    {
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<ClothingCategory> Categories { get; set; }
    public DbSet<ClothingItem> Items { get; set; }
    public DbSet<ItemImage> Images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ClothingItem>()
            .HasOne(c => c.Brand)
            .WithMany(b => b.Items)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        modelBuilder
            .Entity<ClothingItem>()
            .HasOne(c => c.Category)
            .WithMany(c => c.Items)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        modelBuilder
            .Entity<ClothingItem>()
            .HasMany(c => c.Images)
            .WithOne(i => i.ClothingItem)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}