using System;
using static System.Console;
namespace Test01
{
  internal class MainApp
  {
    static void Main(string[] args)
    {
      if (args.Length > 0)
      {
        WriteLine("매개변수 목록:");
        foreach (var arg in args)
        {
          WriteLine("매개변수 : {0}!", arg);
        }
      }
      else
      {
        WriteLine("사용법 : Test01.exe [이름 ...]");
      }
    }
  }
}
