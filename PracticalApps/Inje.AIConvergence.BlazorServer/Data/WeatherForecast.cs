using System.Drawing;

namespace Inje.AIConvergence.BlazorServer.Data;

public class WeatherForecast
{
  public static readonly int MinTemperatureC = -30;
  public static readonly int MaxTemperatureC = 40;
  private static readonly string[] Summaries = new[]
  {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };
  public DateTime Date { get; set; }
  private int _temperatureC = 0;

  public int TemperatureC {
    get => _temperatureC;
    set
    {
      int size = Summaries.Length;
      _temperatureC = value;
      int delta = (int)((double)(MaxTemperatureC - MinTemperatureC) / (size - 1));
      int index = (int)((double)(_temperatureC - MinTemperatureC) / delta);
      if (index < 0)
      {
        index = 0;
      }
      else if (index > size - 1)
      {
        index = size - 1;
      }
      _summary = Summaries[index];
    }
  }

  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

  private string _summary = string.Empty;
  public string? Summary { 
    get => _summary;
  }
}