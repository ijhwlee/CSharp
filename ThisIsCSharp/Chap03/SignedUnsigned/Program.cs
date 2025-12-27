using System;
namespace SignedUnsigned
{
  internal class Program
  {
    static void Main(string[] args)
    {
      byte a = 255; // byte is unsigned (0 to 255)
      sbyte b = (sbyte)a;
      Console.WriteLine(a);
      Console.WriteLine(b);
    }
  }
}
