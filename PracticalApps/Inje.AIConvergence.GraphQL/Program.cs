using GraphQL.Server;
using Inje.AIConvergence.GraphQL;
using Inje.AIConvergence.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddNorthwindContext();
//builder.Services.AddGraphQL()
//  .AddGraphTypes(typeof(NorthwindSchema), ServiceLifetime.Scoped)
//  .AddDataLoader()
//  .AddSystemTextJson();

builder.Services.AddGraphQL(options => options
    .AddSystemTextJson()
    .AddSchema<NorthwindSchema>());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
