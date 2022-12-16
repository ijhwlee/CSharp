// See https://aka.ms/new-console-template for more information
using static System.Console;
using AIConvergenc.Shared;

TimerCheck();
ProcessingString();

static void ProcessingString()
{
  WriteLine("=============== ProcessingString ===================");
  int[] numbers = Enumerable.Range(1, 50_000).ToArray();
  WriteLine("Using string with +");
  Recorder.Start();
  string s = "";
  for(int i=0; i < numbers.Length; i++)
  {
    s += numbers[i] + ", ";
  }
  Recorder.Stop();

  WriteLine("Using StringBuffer");
  Recorder.Start();
  var builder = new System.Text.StringBuilder();
  for (int i = 0; i < numbers.Length; i++)
  {
    builder.Append(numbers[i]);
    builder.Append(", ");
  }
  Recorder.Stop();
}
static void TimerCheck()
{
  WriteLine("=============== TimerCheck ===================");
  WriteLine("Processing. Please wait...");
  Recorder.Start();

  int[] largeArrayOfInts = Enumerable.Range(1, 10_000).ToArray();
  System.Threading.Thread.Sleep(new Random().Next(5, 10)*1000);
  Recorder.Stop();
}