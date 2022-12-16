// See https://aka.ms/new-console-template for more information
using static System.Console;

await AsyncStreams();

static async Task<int> AsyncStreams()
{
  WriteLine("=============== AsyncStreams ===============");
  await foreach(int number in GetNumbersAsync())
  {
    WriteLine($"Number: {number}");
  }
  return 0;
}
async static IAsyncEnumerable<int> GetNumbersAsync()
{
  Random r = new();
  await Task.Delay(r.Next(1500, 3000));
  yield return r.Next(0, 1001);
  await Task.Delay(r.Next(1500, 3000));
  yield return r.Next(0, 1001);
  await Task.Delay(r.Next(1500, 3000));
  yield return r.Next(0, 1001);
}