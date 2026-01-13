using System;
namespace IfElse
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("숫자를 입력하세요...");
      string? input = Console.ReadLine();
      int number = Int32.Parse(input);
      if (number < 0)
      {
        Console.WriteLine("입력한 숫자는 음수입니다.");
      }
    }
  }
}
