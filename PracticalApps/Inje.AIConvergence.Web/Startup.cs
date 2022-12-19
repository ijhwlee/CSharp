using static System.Console;
using Inje.AIConvergence.Shared;

namespace Inje.AIConvergence.Web;

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddRazorPages();
    services.AddNorthwindContext();
  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    WriteLine("[DEBUG-hwlee]Configure: ");
    if(!env.IsDevelopment())
    {
      app.UseHsts();
    }
    app.UseRouting(); // start endpoint routing
    app.UseHttpsRedirection();
    app.UseDefaultFiles();
    app.UseStaticFiles();
    app.UseEndpoints(endpoints =>
    {
      endpoints.MapRazorPages();
      endpoints.MapGet("/hello", () => "Hello World from Startup.cs!");
    });
    WriteLine("[DEBUG-hwlee]Finishing Configure... ");
  }
}
