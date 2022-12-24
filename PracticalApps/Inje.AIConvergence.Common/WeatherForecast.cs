namespace Inje.AIConvergence.Common;

public class WeatherForecast
{
  public static readonly int MinTemperatureC = -30;
  public static readonly int MaxTemperatureC = 40;
  public static readonly string[] Summaries = new[]
  {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild",
    "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };
  public DateTime Date { get; set; }
  private int _temperatureC = 0;
  public int TemperatureC
  {
    get => _temperatureC;
    set
    {
      _temperatureC = value;
      int delta = (MaxTemperatureC - MinTemperatureC) / (Summaries.Length - 1);
      int index = (int)((double)(_temperatureC - MinTemperatureC) / delta);
      _summary = Summaries[0];
      if (index < 0)
      {
        index = 0;
      }
      else if (index > Summaries.Length - 1)
      {
        index = Summaries.Length - 1;
      }
      _summary = Summaries[index];
    }
  }
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
  private string _summary = string.Empty;
  public string? Summary { get => _summary; }
}