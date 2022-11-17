// See https://aka.ms/new-console-template for more information
using static System.Console;

int numberOfApples = 12;
decimal pricePerApple = 0.35M;

WriteLine($"There are {args.Length} arguments.");

WriteLine(
  format: "{0} apples costs {1:C}",
  arg0: numberOfApples,
  arg1: pricePerApple * numberOfApples);

string formatted = string.Format(
  format: "{0} apples costs {1:C}",
  arg0: numberOfApples,
  arg1: pricePerApple * numberOfApples);

//WriteToFile(formatted);

Write("Type your first name and press ENTER: ");
string? firstName = ReadLine();

Write("Type your age and press ENTER: ");
string? age = ReadLine();

WriteLine(
  $"Hello {firstName}, you look for {age}.");

while (true)
{
  Write("Press any key combination(Press Ctrl-Z to stop): ");
  ConsoleKeyInfo key = ReadKey();
  WriteLine();
  WriteLine("Key: {0}, Char: {1}, Modifier: {2}",
    arg0: key.Key,
    arg1: key.KeyChar,
    arg2: key.Modifiers);
  if (key.Key == ConsoleKey.Z && key.Modifiers == ConsoleModifiers.Control)
    break;
}