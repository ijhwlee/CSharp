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
    this IServiceCollection services, string connectionString =
    "Data Source=.\\SQLEXPRESS;" + "Initial Catalog=Northwind;" +
    "Integrated Security=true;" + "MultipleActiveResultSets=true;")
  {
    services.AddDbContext<NorthwindContext>(options =>
      options.UseSqlServer(connectionString));
    return services;
  }
}
