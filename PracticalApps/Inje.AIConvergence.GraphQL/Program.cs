using GraphQL;
using GraphQL.MicrosoftDI;
//using GraphQL.Server;
using GraphQL.Types;
using Inje.AIConvergence.GraphQL;
using Inje.AIConvergence.Shared;
using static System.Console;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

WriteLine("[DEBUG-hwlee]000 Program.cs");
builder.Services.AddControllers();
builder.Services.AddNorthwindContext();
WriteLine("[DEBUG-hwlee]001 Program.cs");
builder.Services.AddSingleton<ISchema, NorthwindSchema>(services => new NorthwindSchema(new SelfActivatingServiceProvider(services)));
//builder.Services.AddGraphQL()
//  .AddGraphTypes(typeof(NorthwindSchema), ServiceLifetime.Scoped)
//  .AddDataLoader()
//  .AddSystemTextJson();
builder.Services.AddGraphQL(options =>
    {
      options.AddSystemTextJson().AddDataLoader();
    });
WriteLine("[DEBUG-hwlee]002 Program.cs");

var app = builder.Build();

// Configure the HTTP request pipeline.
WriteLine("[DEBUG-hwlee]003 Program.cs");
if (builder.Environment.IsDevelopment())
{
  app.UseGraphQLPlayground();
}
app.UseGraphQL();
WriteLine("[DEBUG-hwlee]004 Program.cs");

WriteLine("[DEBUG-hwlee]005 Program.cs");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
