namespace Inje.AIConvergence.BlazorServer.Data;

public class WeatherForecastService
{
  public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
  {
    return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = startDate.AddDays(index),
      TemperatureC = Random.Shared.Next(WeatherForecast.MinTemperatureC, WeatherForecast.MaxTemperatureC),
      //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    }).ToArray());
  }
}