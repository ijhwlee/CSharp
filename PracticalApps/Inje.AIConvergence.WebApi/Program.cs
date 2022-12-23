using Microsoft.AspNetCore.Mvc.Formatters;
using Inje.AIConvergence.Shared;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using Inje.AIConvergence.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
