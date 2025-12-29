using System;
using System.Collections;
namespace NullConditionalOperator
{
  internal class Program
  {
    static void Main(string[] args)
    {
      ArrayList? a = null;
      a?.Add("야구");
      a?.Add("축구");
      Console.WriteLine($"Count: {a?.Count}");
      Console.WriteLine($"{a?[0]}");
      Console.WriteLine($"{a?[1]}");
      a = new ArrayList();
      a?.Add("야구");
      a?.Add("축구");
      Console.WriteLine($"Count: {a?.Count}");
      Console.WriteLine($"{a?[0]}");
      Console.WriteLine($"{a?[1]}");
    }
  }
}
