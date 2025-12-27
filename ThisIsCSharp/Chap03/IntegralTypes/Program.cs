using System;
namespace IntegralTypes
{
  internal class Program
  {
    static void Main(string[] args)
    {
      sbyte a = -10;
      byte b = 40;
      Console.WriteLine($"a = {a}, b = {b}");
      short c = -30000;
      ushort d = 60000;
      Console.WriteLine($"c = {c}, d = {d}");
      long g = -5000_0000_0000;
      ulong h = 200_0000_0000_0000_0000;
      Console.WriteLine($"g = {g}, h = {h}");
    }
  }
}
