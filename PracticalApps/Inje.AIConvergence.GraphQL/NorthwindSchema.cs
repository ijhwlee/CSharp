using GraphQL.Types;

namespace Inje.AIConvergence.GraphQL;

public class NorthwindSchema : Schema
{
  public NorthwindSchema(IServiceProvider provider) : base(provider)
  {
    Query = new GreetQuery();
  }
}
