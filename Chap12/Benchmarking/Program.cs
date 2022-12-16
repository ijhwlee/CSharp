// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Benchmarking;
using static System.Console;

RunStringBecnhmark();

static void RunStringBecnhmark()
{
  WriteLine("=============== RunStringBecnhmark ============");
  BenchmarkRunner.Run<StringBenchmark>();
}
