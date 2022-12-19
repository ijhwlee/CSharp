using static System.Console;

namespace Inje.AIConvergence.Web;

public class Startup
{
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    WriteLine("[DEBUG-hwlee]Configure: ");
    if(env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }
    else
    {
      app.UseHsts();
    }
    app.UseRouting(); // start endpoint routing
    app.UseEndpoints(endpoints =>
    {
      endpoints.MapGet("/", () => "Hello World from Startup.cs!");
    });
    WriteLine("[DEBUG-hwlee]Finishing Configure... ");
  }
}
