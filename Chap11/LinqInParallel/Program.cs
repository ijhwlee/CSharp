// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

AddTwoBillionSingle();
AddTwoBillionParallel();

static void AddTwoBillionSingle()
{
  WriteLine("=============== AddTwoBillionSingle =====================");
  var watch = new Stopwatch();
  Write("Press ENTER to start: ");
  ReadLine();
  watch.Start();

  IEnumerable<int> numbers = Enumerable.Range(1, 2_000_000_000);
  var squares = numbers.Select(number => number * number).ToArray();

  watch.Stop();
  WriteLine("{0:#,##0} elapsed milliseconds.",
    arg0: watch.ElapsedMilliseconds);
  WriteLine();
}

static void AddTwoBillionParallel()
{
  WriteLine("=============== AddTwoBillionParallel =====================");
  var watch = new Stopwatch();
  Write("Press ENTER to start: ");
  ReadLine();
  watch.Start();

  IEnumerable<int> numbers = Enumerable.Range(1, 2_000_000_000);
  var squares = numbers.AsParallel().Select(number => number * number).ToArray();

  watch.Stop();
  WriteLine("{0:#,##0} elapsed milliseconds.",
    arg0: watch.ElapsedMilliseconds);
  WriteLine();
}