using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Inje.AIConvergence.Shared;

public static class NorthwindContextExtensions
{
  private static Dictionary<string, string> SourceData = new Dictionary<string, string>
  { {"LAPTOP-CMAETB3C", ".;" },
    {"HOME-201119", ".\\SQLEXPRESS01;" },
    {"LAPTOP-8N40M1AT", ".\\SQLEXPRESS;" }};
  public static IServiceCollection AddNorthwindContext(
    this IServiceCollection services, string connectionString = "")
  //this IServiceCollection services, string connectionString =
  //"Data Source=.;" + "Initial Catalog=Northwind;" +
  //"Integrated Security=true;" + "MultipleActiveResultSets=true;")
  {
    WriteLine($"[DEBUG-hwlee]NorthwindExtensions:AddNorthwindContext connectionString = {connectionString}");
    if (connectionString == string.Empty)
    {
      string dbServer = SourceData[System.Environment.MachineName];
      connectionString =
      "Data Source=" + dbServer + "Initial Catalog=Northwind;" +
      "Integrated Security=true;" + "MultipleActiveResultSets=true;";
    }
    WriteLine($"[DEBUG-hwlee]NorthwindExtensions:AddNorthwindContext(after) connectionString = {connectionString}");
    services.AddDbContext<NorthwindContext>(options =>
      options.UseSqlServer(connectionString));
    return services;
  }
}
