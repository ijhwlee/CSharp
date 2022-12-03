// See https://aka.ms/new-console-template for more information
using static System.Console;

string city = "London";
string city1 = "김해";
WriteLine($"{city} is {city.Length} characters long.");
WriteLine($"{city1} is {city1.Length} characters long.");

WriteLine($"First char is {city[0]} and third is {city[2]}.");

string cities = "Paris,Rome ,London,서울, New York,Milano";
string[] citiesArray = cities.Split(',');
WriteLine($"There are {citiesArray.Length} items in the array.");
foreach(string item in citiesArray)
{
  WriteLine(item.Trim());
}

string fullName = "Alan Jones";
int indexOfSpace = fullName.IndexOf(' ');
string firstName = fullName.Substring(startIndex:0, length:indexOfSpace);
string lastName = fullName.Substring(startIndex: indexOfSpace + 1);
WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {lastName}, {firstName}");

string company = "Microsoft";
bool startsWithM = company.StartsWith("M");
bool containsN = company.Contains("N");
WriteLine($"Text: {company}");
WriteLine($"Starts with M: {startsWithM}, contains N : {containsN}");

string recombined = string.Join(" => ", citiesArray);
WriteLine(recombined);

string recombined1 = string.Join(" => ", citiesArray.Select(item => item.Trim()));
WriteLine(recombined1);

string fruit = "Apples";
decimal price = 2100M;
DateTime when = DateTime.Now;
WriteLine($"Interpolated: {fruit} cost {price:C} on {when:dddd}.");
WriteLine(string.Format("string.Format: {0} cost {1:C} on {2:dddd}.",
  arg0: fruit, arg1: price, arg2: when));
WriteLine("WriteLine: {0} cost {1:C} on {2:dddd}.",
  arg0: fruit, arg1: price, arg2: when);
