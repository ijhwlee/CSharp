// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Collections.Immutable;
using static System.Console;

var cities = new List<string>();
cities.Add("London");
cities.Add("Paris");
cities.Add("Roma");
cities.Add("서울");

WriteLine("Initial list");
foreach(string city in cities)
{
  WriteLine($" {city}");
}
WriteLine();

WriteLine($"The first city is {cities[0]}");
WriteLine($"The last city is {cities[cities.Count-1]}");

cities.Insert(0, "Gimhae");

WriteLine("After inserting Gimhae at index 0");
foreach (string city in cities)
{
  WriteLine($" {city}");
}
WriteLine();

cities.RemoveAt(1);
cities.Remove("Roma");

WriteLine("After removing two cities");
foreach (string city in cities)
{
  WriteLine($" {city}");
}

var immutableCities = cities.ToImmutableList();
var newList = immutableCities.Add("Milano");

Write("Immutable list of cities: ");
foreach(string city in immutableCities)
{
  Write($" {city}");
}
WriteLine();

Write("New list of cities: ");
foreach (string city in newList)
{
  Write($" {city}");
}
WriteLine();
