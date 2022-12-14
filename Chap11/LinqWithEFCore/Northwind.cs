using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIConvergence.Shared;

public class Northwind : DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Product> Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    //string path = Path.Combine(
    //  Environment.CurrentDirectory, "Northwind.db");
    //optionsBuilder.UseSqlite($"Filename={path}");

    string connection = "Data Source=.\\SQLEXPRESS;" +
      "Initial Catalog=Northwind;" +
      "Integrated Security=true;" +
      "MultipleActiveResultSets=true;";
    optionsBuilder.UseSqlServer(connection);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>()
      .Property(product => product.UnitPrice)
      .HasConversion<double>();
  }
}
