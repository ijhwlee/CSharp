using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace AIConvergence.Shared;

public class Northwind : DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Product>? Products { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseLazyLoadingProxies();
    if(ProjectConstants.DatabaseProvider == ProjectConstants.SQLite)
    {
      string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
      WriteLine($"Using {path} database file.");
      optionsBuilder.UseSqlite($"Filename={path}");
    }
    else
    {
      string connection = "Data Source=.;" +
        "Initial Catalog=Northwind;" +
        "Integrated Security=true;" +
        "MultipleActiveResultSets=true;";
      optionsBuilder.UseSqlServer(connection);
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>()
      .Property(category => category.CategoryName)
      .IsRequired()
      .HasMaxLength(15);
    modelBuilder.Entity<Product>()
      .HasQueryFilter(p => !p.Discontinued);

    if (ProjectConstants.DatabaseProvider == ProjectConstants.SQLite)
    {
      modelBuilder.Entity<Product>()
        .Property(product => product.Cost)
        .HasConversion<double>();
    }
  }
}
