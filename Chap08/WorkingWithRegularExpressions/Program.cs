// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using static System.Console;

Write("Enter your age: ");
string? input = ReadLine();

Regex ageChecker = new(@"^\d{1,3}$");
if(ageChecker.IsMatch(input))
{
  WriteLine("Thanks!");
}
else
{
  WriteLine($"This is not a valid age: {input}");
}

string films = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";

WriteLine($"Films to split: {films}");

string[] filmsDumb = films.Split(',');

WriteLine("Splitting with string.Split method:");
foreach (string film in filmsDumb)
{
  WriteLine(film);
}

WriteLine();

Regex csv = new(
  "(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");

MatchCollection filmsSmart = csv.Matches(films);

WriteLine("Splitting with regular expression Group0:");
foreach (Match film in filmsSmart)
{
  WriteLine(film.Groups[0].Value);
}
WriteLine("Splitting with regular expression Group1:");
foreach (Match film in filmsSmart)
{
  WriteLine(film.Groups[1].Value);
}
WriteLine("Splitting with regular expression Group2:");
foreach (Match film in filmsSmart)
{
  WriteLine(film.Groups[2].Value);
}
