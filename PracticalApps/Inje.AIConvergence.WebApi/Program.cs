using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Mvc.Formatters;
using Inje.AIConvergence.Shared;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using Inje.AIConvergence.WebApi.Repositories;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("https://localhost:5003/");

// Add services to the container.
builder.Services.AddCors();
var connectionNorthwind = builder.Configuration.GetConnectionString("NorthwindHOME-201119");
if (System.Environment.MachineName == "HOME-201119")
{
  connectionNorthwind = builder.Configuration.GetConnectionString("NorthwindHOME-201119");
}
else if (System.Environment.MachineName == "LAPTOP-CMAETB3C")
{
  connectionNorthwind = builder.Configuration.GetConnectionString("NorthwindLaptop");
}
else if (System.Environment.MachineName == "LAPTOP-8N40M1AT")
{
  connectionNorthwind = builder.Configuration.GetConnectionString("NorthwindOdyssey");
}
builder.Services.AddNorthwindContext(connectionNorthwind);
//builder.Services.AddDbContext<NorthwindContext>(options =>
//    options.UseSqlServer(connectionNorthwind));

builder.Services.AddControllers(options =>
{
  WriteLine("Default output formatters:");
  foreach (IOutputFormatter formatter in options.OutputFormatters)
  {
    OutputFormatter? mediaFormatter = formatter as OutputFormatter;
    if (mediaFormatter == null)
    {
      WriteLine($"  {formatter.GetType().Name}. Output");
    }
    else
    {
      WriteLine("  {0}, Media types: {1}",
        arg0: mediaFormatter.GetType().Name,
        arg1: string.Join(", ", mediaFormatter.SupportedMediaTypes));
    }
  }
})
.AddXmlDataContractSerializerFormatters()
.AddXmlSerializerFormatters();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddHttpLogging(options =>
{
  options.LoggingFields = HttpLoggingFields.All;
  options.RequestBodyLogLimit = 4096;
  options.ResponseBodyLogLimit = 4096;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new() { Title = "Inje University AI Convergence API", Version = "v1" });
});

builder.Services.AddHealthChecks()
  .AddDbContextCheck<NorthwindContext>();
  // execute SELECT 1 using the specified connection string
  //.AddSqlServer(connectionNorthwind);

var app = builder.Build();

app.UseCors(configurePolicy: options =>
{
  options.WithMethods("GET", "POST", "PUT", "DELETE");
  options.WithOrigins(
    "https://localhost:5001" // allow requests from the MVC client
  );
});

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI( c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
      "Inje University AI Convergence API Version 1");
    c.SupportedSubmitMethods(new[]
    {
      SubmitMethod.Get, SubmitMethod.Post,
      SubmitMethod.Put, SubmitMethod.Delete
    });
  });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHealthChecks(path: "/howdoyoufeel");

app.MapControllers();

app.Run();
