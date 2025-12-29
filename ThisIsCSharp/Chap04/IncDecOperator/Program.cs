using System;
namespace IncDecOperator
{
  internal class Program
  {
    static void Main(string[] args)
    {
      int a = 10;
      Console.WriteLine(a++); // Outputs 10, then a becomes 11
      Console.WriteLine(++a); // a becomes 12, then outputs 12
      Console.WriteLine(a--); // Outputs 12, then a becomes 11
      Console.WriteLine(--a); // a becomes 10, then outputs 10
    }
  }
}
