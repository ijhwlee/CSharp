// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;
using System.Diagnostics.Metrics;

CallSeparateThreads();
SharedObjects.Message += "-";
CallSeparateThreadsTry();

static void CallSeparateThreadsTry()
{
  WriteLine("===================== CallSeparateThreads ===============");
  WriteLine("Please wait for the tasks to complete.");
  Stopwatch watch = Stopwatch.StartNew();
  Task a = Task.Factory.StartNew(MethodATry);
  Task b = Task.Factory.StartNew(MethodBTry);
  Task.WaitAll(new Task[] { a, b });
  WriteLine();
  WriteLine($"Results: {SharedObjects.Message}");
  WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");
  WriteLine($"{SharedObjects.Count} string modifications.");
}

static void CallSeparateThreads()
{
  WriteLine("===================== CallSeparateThreads ===============");
  WriteLine("Please wait for the tasks to complete.");
  Stopwatch watch = Stopwatch.StartNew();
  Task a = Task.Factory.StartNew(MethodA);
  Task b = Task.Factory.StartNew(MethodB);
  Task.WaitAll(new Task[] { a, b });
  WriteLine();
  WriteLine($"Results: {SharedObjects.Message}");
  WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");
  WriteLine($"{SharedObjects.Count} string modifications.");
}

static void MethodA()
{
  lock (SharedObjects.Conch)
  {
    for (int i = 0; i < 5; i++)
    {
      Thread.Sleep(SharedObjects.Random.Next(2000));
      SharedObjects.Message += "A";
      Interlocked.Increment(ref SharedObjects.Count);
      Write(".");
    }
  }
}
static void MethodB()
{
  lock (SharedObjects.Conch)
  {
    for (int i = 0; i < 5; i++)
    {
      Thread.Sleep(SharedObjects.Random.Next(2000));
      SharedObjects.Message += "B";
      Interlocked.Increment(ref SharedObjects.Count);
      Write(",");
    }
  }
}
static void MethodATry()
{
  try
  {
    if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
    {
      for (int i = 0; i < 5; i++)
      {
        Thread.Sleep(SharedObjects.Random.Next(2000));
        SharedObjects.Message += "A";
        Interlocked.Increment(ref SharedObjects.Count);
        Write(".");
      }
    }
    else
    {
      WriteLine("Method A failed to enter a monitor lock.");
    }
  }
  finally
  {
    Monitor.Exit(SharedObjects.Conch);
  }
}
static void MethodBTry()
{
  try
  {
    if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
    {
      for (int i = 0; i < 5; i++)
      {
        Thread.Sleep(SharedObjects.Random.Next(2000));
        SharedObjects.Message += "B";
        Interlocked.Increment(ref SharedObjects.Count);
        Write(",");
      }
    }
    else
    {
      WriteLine("Method B failed to enter a monitor lock.");
    }
  }
  finally
  {
    Monitor.Exit(SharedObjects.Conch);
  }
}

static class SharedObjects
{
  public static Random Random = new();
  public static string? Message;
  public static object Conch = new();
  public static int Count;
}

