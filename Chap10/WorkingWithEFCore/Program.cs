﻿// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AIConvergence.Shared;
using static System.Console;

WriteLine($"Using {ProjectConstants.DatabaseProvider} dadabase provider.");
QueryingCategories();
FilteredIncludes();
QueryingProducts();
QueryingWithLike();

//if (AddProduct(categoryId: 6, productName: "Bob's Burger", price: 500M))
//{
//  WriteLine("Add a product successfully.");
//}

//if (IncreaseProductPrice(productNameStartWith: "Bob", amount: 20M))
//{
//  WriteLine("Update product price successfully.");
//}

int deleted = DeleteProducts(productNameStartWith: "Bob");
WriteLine($"{deleted} product(s) were deleted.");

ListProducts();

static int DeleteProducts(
  string productNameStartWith)
{
  using (Northwind db = new())
  {
    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
    loggerFactory.AddProvider(new ConsoleLoggerProvider());
    using (IDbContextTransaction t = db.Database.BeginTransaction())
    {
      WriteLine("Transaction iolation level: {0}",
        arg0: t.GetDbTransaction().IsolationLevel);
      IQueryable<Product>? products = db.Products?.Where(
        p => p.ProductName.StartsWith(productNameStartWith));
      if (products is null)
      {
        WriteLine("No products found to delete.");
        return 0;
      }
      else
      {
        db.Products?.RemoveRange(products);
      }
      int affected = db.SaveChanges();
      t.Commit();
      return affected;
    }
  }
}

static bool IncreaseProductPrice(
  string productNameStartWith, decimal amount)
{
  using (Northwind db = new())
  {
    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
    loggerFactory.AddProvider(new ConsoleLoggerProvider());
    Product updateProduct = db.Products.First(
      p => p.ProductName.StartsWith(productNameStartWith));
    updateProduct.Cost += amount;
    int affected = db.SaveChanges();
    return (affected == 1);
  }
}

static bool AddProduct(
  int categoryId, string productName, decimal? price)
{
  using (Northwind db = new())
  {
    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
    loggerFactory.AddProvider(new ConsoleLoggerProvider());
    Product p = new()
    {
      CategoryId = categoryId,
      ProductName = productName,
      Cost = price
    };
    db.Products?.Add(p);
    int affected = db.SaveChanges();
    return (affected == 1);
  }
}

static void ListProducts()
{
  using (Northwind db = new())
  {
    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
    loggerFactory.AddProvider(new ConsoleLoggerProvider());
    WriteLine("{0:-3} {1:-35} {2, 8} {3,5} {4}",
      "Id", "Product Name", "Cost", "Stock", "Disc.");

    foreach(Product p in db.Products
      .OrderByDescending(product => product.Cost) )
    {
      WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
        p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
    }
  }
}

static void QueryingWithLike()
{
  using (Northwind db = new())
  {
    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
    loggerFactory.AddProvider(new ConsoleLoggerProvider());
    Write("Enter part of a product name: ");
    string? input = ReadLine();

    IQueryable<Product>? products = db.Products?
      .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
    if (products is null)
    {
      WriteLine("No products found.");
      return;
    }
    foreach (Product p in products)
    {
      WriteLine("{0} has {1} units in stock. Discontinued? {2}",
        p.ProductName, p.Stock, p.Discontinued);
    }
  }
}

static void QueryingProducts()
{
  using (Northwind db = new())
  {
    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
    loggerFactory.AddProvider(new ConsoleLoggerProvider());
    WriteLine("Products that cost more than a price, highest at top.");
    string? input;
    decimal price;

    do
    {
      Write("Enter a product price: ");
      input = ReadLine();
    } while(!decimal.TryParse(input, out price));

    IQueryable<Product>? products = db.Products?
      .TagWith("Products filtered by price and sorted.")
      .Where(product => product.Cost > price)
      .OrderByDescending(product => product.Cost);
    if (products is null)
    {
      WriteLine("No products found.");
      return;
    }
    foreach (Product p in products)
    {
      WriteLine("{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
        p.ProductId, p.ProductName, p.Cost, p.Stock);
    }
  }
}

static void QueryingCategories()
{
  using (Northwind db = new())
  {
    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
    loggerFactory.AddProvider(new ConsoleLoggerProvider());
    WriteLine("Categories and how many products they have:");
    IQueryable<Category>? categories;
    //= db.Categories; 
    //?.Include(c => c.Products);
    db.ChangeTracker.LazyLoadingEnabled = false;

    Write("Enable eager loading? (Y/N): ");
    bool eagerLoading = (ReadKey().Key == ConsoleKey.Y);
    bool explicitLoading = false;
    WriteLine();

    if(eagerLoading)
    {
      categories = db.Categories?.Include(c => c.Products);
    }
    else
    {
      categories = db.Categories;
      Write("Enable explicit loading? (Y/N): ");
      explicitLoading = (ReadKey().Key == ConsoleKey.Y);
      WriteLine();
    }
    if(categories is null)
    {
      WriteLine("No categories found.");
      return;
    }
    foreach(Category c in categories)
    {
      if (explicitLoading)
      {
        Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
        ConsoleKeyInfo key = ReadKey();
        WriteLine();
        if(key.Key == ConsoleKey.Y)
        {
          CollectionEntry<Category, Product> products =
            db.Entry(c).Collection(c2 => c2.Products);
          if(!products.IsLoaded) products.Load();
        }
      }
      WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
    }
  }
}

static void FilteredIncludes()
{
  using (Northwind db = new())
  {
    Write("Enter a minimum for units is stock: ");
    string unitsInStock = ReadLine()??"10";
    int stock = int.Parse(unitsInStock);

    IQueryable<Category>? categories = db.Categories?
      .Include(c => c.Products.Where(p => p.Stock >= stock));
    if (categories is null)
    {
      WriteLine("No categories found.");
      return;
    }
    WriteLine($"ToQueryString: {categories.ToQueryString()}");
    foreach (Category c in categories)
    {
      WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");
      foreach(Product p in c.Products)
      {
        WriteLine($"  {p.ProductName} has {p.Stock} units in stock.");
      }
    }
  }
}