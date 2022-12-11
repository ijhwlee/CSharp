// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;

using static System.Console;
using static System.Environment;
using static System.IO.Path;

SaveBookWithJson();

static void SaveBookWithJson()
{
  WriteLine("================ SaveBookWithJason ===================");
  Book csharp10 = new(title: "C# 10 and .NET 6 - Modern Cross-Platform Development")
  {
    Author = "Mark J Price",
    PublishDate = new(year:2021, month:11, day:9),
    Pages = 823,
    Created = DateTimeOffset.UtcNow,
  };
  Book cprogram = new(title: "Hi C, What is this? - The basic program language")
  {
    Author = "Hyung Won Lee",
    PublishDate = new(year: 2023, month: 6, day: 21),
    Pages = 324,
    Created = DateTimeOffset.UtcNow,
  };

  JsonSerializerOptions options = new()
  {
    IncludeFields = true,
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
  };

  string filePath = Combine(CurrentDirectory, "book.json");

  using (Stream fileStream = File.Create(filePath))
  {
    JsonSerializer.Serialize<Book>(
      utf8Json: fileStream, value: csharp10, options: options );
    JsonSerializer.Serialize<Book>(
      utf8Json: fileStream, value: cprogram, options: options);
  }
  WriteLine("Written {0:N0} bytes of JSON to {1}",
    arg0: new FileInfo(filePath).Length,
    arg1: filePath);
  WriteLine();
  WriteLine(File.ReadAllText(filePath));
}
public class Book
{
  public string Title { get; set; }
  public string? Author { get; set; }

  [JsonInclude]
  public DateTime PublishDate;
  [JsonInclude]
  public DateTimeOffset Created;

  public ushort Pages;

  public Book(string title)
  {
    Title = title;
  }
}