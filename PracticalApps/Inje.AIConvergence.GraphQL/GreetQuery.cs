using GraphQL;
using GraphQL.Types;

namespace Inje.AIConvergence.GraphQL;

public class GreetQuery : ObjectGraphType
{
  public GreetQuery()
  {
    //Name = "greet";
    //Description = "A query type that greets the world.";

    //Field<StringGraphType>(name: "greet",
    //  description: "A query type that greets the world.",
    //  resolve: context => "Hello, World from GraphQL web service!");
    Field<StringGraphType>("greet")
      .Description("A query type that greets the world.")
      .Resolve(context => new string("Hello, World from GraphQL web service v7.2.1!"));
  }
}
