// See https://aka.ms/new-console-template for more information
using System.Runtime.Versioning;
using static System.Console;

Doer.DoSomething();

[RequiresPreviewFeatures]
public interface IWithStaticAbstract
{
  static abstract void DoSomething();
}

[RequiresPreviewFeatures]
public class Doer : IWithStaticAbstract
{
  public static void DoSomething()
  {
    WriteLine("I am an implementation of a static abstract method.");
  }
}