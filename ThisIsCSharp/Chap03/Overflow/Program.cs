using System;
namespace Overflow
{
  internal class Program
  {
    static void Main(string[] args)
    {
      uint a = uint.MaxValue;
      Console.WriteLine(a);
      a = a + 1;
      Console.WriteLine(a); 
    }
  }
}
