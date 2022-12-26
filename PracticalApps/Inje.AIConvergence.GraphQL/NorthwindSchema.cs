using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Inje.AIConvergence.Shared;
using static System.Console;

namespace Inje.AIConvergence.GraphQL;

public class NorthwindSchema : Schema
{
  public NorthwindSchema(IServiceProvider provider) : base(provider)
  {
    WriteLine("[DEBUG-hwlee]NorthwindSchema ===============");
    //Query = provider.GetRequiredService<GreetQuery>();
    //Query = new GreetQuery();
    WriteLine($"[DEBUG-hwlee]NorthwindSchema, provider = {provider}");
    //Query = new NorthwindQuery(provider.GetService<NorthwindContext>());
    Query = new NorthwindQuery(provider.GetRequiredService<NorthwindContext>());
  }

}
