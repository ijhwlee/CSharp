using GraphQL.Types;

namespace Inje.AIConvergence.GraphQL;

public class GreetQuery : ObjectGraphType
{
  public GreetQuery()
  {
    Field<StringGraphType>(name: "greet",
      description: "A query type that greets the world.",
      resolve: context => "Hello, World from GraphQL web service!");
  }
}
