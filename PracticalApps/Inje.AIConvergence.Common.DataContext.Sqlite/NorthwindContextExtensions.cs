using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inje.AIConvergence.Shared;

public static class NorthwindContextExtensions
{
  public static IServiceCollection AddNorthwindContext(
    this IServiceCollection services, string relativePath = "..")
  {
    string databasePath = Path.Combine(relativePath, "Northwind.db");
    services.AddDbContext<NorthwindContext>(options =>
      options.UseSqlite($"Data Source={databasePath}"));
    return services;
  }
}
