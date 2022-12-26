using GraphQL.Types;
using static System.Console;

namespace Inje.AIConvergence.GraphQL;

public class NorthwindSchema : Schema
{
  public NorthwindSchema(IServiceProvider provider) : base(provider)
  {
    WriteLine("[DEBUG-hwlee]NorthwindSchema ===============");
    //Query = provider.GetRequiredService<GreetQuery>();
    Query = new GreetQuery();
  }

}
