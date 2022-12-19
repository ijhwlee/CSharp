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
    app.Use(async (HttpContext context, Func<Task> next) =>
    {
      RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;
      if(rep is not null)
      {
        WriteLine($"Endpoint name: {rep.DisplayName}");
        WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
      }
      if(context.Request.Path == "/buongiorno")
      {
        await context.Response.WriteAsync("Buon giorno mondo!");
        return;
      }
      await next();
    });
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
