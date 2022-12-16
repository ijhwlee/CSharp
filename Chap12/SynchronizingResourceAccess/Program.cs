// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;
using System.Diagnostics.Metrics;

internal class Program
{
  static Random r = new Random();
  static string Message;
  static object conch = new object();
  static int Count;
  private static void Main(string[] args)
  {
    CallSeparateThreads();
    Message += "-";
    CallSeparateThreadsTry();
  }

  static void CallSeparateThreadsTry()
  {
    WriteLine("===================== CallSeparateThreads ===============");
    WriteLine("Please wait for the tasks to complete.");
    Stopwatch watch = Stopwatch.StartNew();
    Task a = Task.Factory.StartNew(MethodATry);
    Task b = Task.Factory.StartNew(MethodBTry);
    Task.WaitAll(new Task[] { a, b });
    WriteLine();
    WriteLine($"Results: {Message}");
    WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");
    WriteLine($"{Count} string modifications.");
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
    WriteLine($"Results: {Message}");
    WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");
    WriteLine($"{Count} string modifications.");
  }

  static void MethodA()
  {
    lock (conch)
    {
      for (int i = 0; i < 5; i++)
      {
        Thread.Sleep(r.Next(2000));
        Message += "A";
        Interlocked.Increment(ref Count);
        Write(".");
      }
    }
  }
  static void MethodB()
  {
    lock (conch)
    {
      for (int i = 0; i < 5; i++)
      {
        Thread.Sleep(r.Next(2000));
        Message += "B";
        Interlocked.Increment(ref Count);
        Write(",");
      }
    }
  }
  static void MethodATry()
  {
    try
    {
      if (Monitor.TryEnter(conch, TimeSpan.FromSeconds(15)))
      {
        for (int i = 0; i < 5; i++)
        {
          Thread.Sleep(r.Next(2000));
          Message += "A";
          Interlocked.Increment(ref Count);
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
      Monitor.Exit(conch);
    }
  }
  static void MethodBTry()
  {
    try
    {
      if (Monitor.TryEnter(conch, TimeSpan.FromSeconds(15)))
      {
        for (int i = 0; i < 5; i++)
        {
          Thread.Sleep(r.Next(2000));
          Message += "B";
          Interlocked.Increment(ref Count);
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
      Monitor.Exit(conch);
    }
  }
}
