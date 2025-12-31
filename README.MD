# Wardrobe Inventory

A full-featured wardrobe inventory web app built with **ASP.NET Blazor** and **.NET 10** that helps you catalog and manage your clothing collection in a clean, modern UI. The app provides a streamlined workflow for adding items, updating details, uploading images, and browsing your wardrobe efficiently—making it easy to stay organized and quickly find what you own.

![HomeScreen.gif](Wardrobe-Inventory/docs/images/HomeScreen.gif)

## Features

- **Add new clothing items** — Create wardrobe entries with core details such as name, category, brand, color, size, and an image.
- **Edit existing clothing items** — Update item metadata at any time to keep your inventory accurate as items change.
- **Upload clothing item images (up to 2 MB)** — Attach a photo to each item for quick visual identification; images are stored and served back in the UI.
- **Delete clothing items** — Remove items from your inventory with a simple delete action (with confirmation to help prevent accidental removals).
- **Pagination** — Browse large wardrobes efficiently with paged results to keep tables fast and responsive.
- **Search by category** — Filter the inventory by clothing category to quickly narrow down what you’re looking for.
- **Modals for CRUD operations** — Perform create, view, edit, and delete workflows in modal dialogs without leaving the current page.
- **Form validation** — Built-in validation provides immediate feedback for required fields and invalid input before saving changes.
  - The size field changes depending on the category selected. E.g.: If jeans are selected, the form will ask for waist and inseam sizes

## Edit:
![Edit.gif](Wardrobe-Inventory/docs/images/Edit.gif)

## Delete:
![Delete.gif](Wardrobe-Inventory/docs/images/Delete.gif)

## Form Vaildation:
![FormValidation.gif](Wardrobe-Inventory/docs/images/FormValidation.gif)

## Getting Started

### Prerequisites

- .NET 10
- MSSQL Local Database

### Configuration

- Update connection strings and environment-specific settings in:
  - appsettings.json

### Running the App

1. **Clone the repository:**

   ```bash
   git clone https://github.com/andymartinez1/Wardrobe-Inventory.git
   ```

2. **Navigate to the project directory:**

   ```bash
   cd Wardrobe-Inventory
   ```

3. **Restore dependencies:**

   ```bash
   dotnet restore
   ```

4. Update the database

   ```bash
   dotnet ef database update
   ```

5. Build and run the app:
   ```bash
   dotnet build
   dotnet run
   ```

## Tech Stack

- **ASP.NET Blazor** — Component-based UI framework for building interactive web apps with C# (Blazor Server/WebAssembly patterns).
- **.NET 10** — Runtime and SDK used for the application backend, DI, configuration, logging, and overall project tooling.
- **Microsoft SQL Server LocalDB** — Lightweight SQL Server instance for local development; used to persist wardrobe items, categories, and metadata.
- **Blazor Bootstrap** — Bootstrap-based UI components for Blazor (modals, forms, buttons, tables) to build a clean, responsive interface quickly.
- **QuickGrid** — High-performance Blazor grid component used for displaying and interacting with tabular data (sorting/paging scenarios).
- **Entity Framework Core** — ORM for data access, migrations, and database updates (`dotnet ef database update`).
- **ASP.NET Core Validation** — Built-in data annotations and validation components for enforcing form rules and providing user feedback.
- **Static file / image handling** — Supports uploading item images (up to **2 MB**) and serving them back in the UI.
