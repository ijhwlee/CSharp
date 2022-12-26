using Inje.AIConvergence.Shared;

namespace Inje.AIConvergence.Mvc.Models;

public class GraphQLProducts
{
  public class DataProducts
  {
    public Product[]? Products { get; set; }
  }
  public DataProducts? Data { get; set; }
}
