using Inje.AIConvergence.Web;
using static System.Console;

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World! by hwlee");

//app.Run();

Host.CreateDefaultBuilder(args)
  .ConfigureWebHostDefaults(webBuilder =>
  {
    webBuilder.UseStartup<Startup>();
  }).Build().Run();

WriteLine("Output after server finished.");