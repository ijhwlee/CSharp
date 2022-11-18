// See https://aka.ms/new-console-template for more information
using static System.Console;

string GetPlatformName(PlatformID id)
{
  string name;
  switch(id)
  {
    case PlatformID.Win32NT:
      name = "Windows NT or later";
      break;
    case PlatformID.Unix:
      name = "Unix";
      break;
    case PlatformID.Other:
      name = "Other";
      break;
    default:
      name = "Unknown";
      break;
  }
  return name;
}

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

if(args.Length < 3)
{
  WriteLine("You must specify two colors and cursor size, e.g.");
  WriteLine($"dotnet {AppDomain.CurrentDomain.FriendlyName} red yellow 50");
  return;
}

ForegroundColor = (ConsoleColor)Enum.Parse(
  enumType: typeof(ConsoleColor),
  value: args[0],
  ignoreCase: true);

BackgroundColor = (ConsoleColor)Enum.Parse(
  enumType: typeof(ConsoleColor),
  value: args[1],
  ignoreCase: true);

OperatingSystem os = Environment.OSVersion;
PlatformID platformID = os.Platform;
try
{
  CursorSize = int.Parse(args[2]);
}
catch (PlatformNotSupportedException)
{
  WriteLine($"The current platform({GetPlatformName(platformID)}) does not support changing the size of the cursor.");
}
