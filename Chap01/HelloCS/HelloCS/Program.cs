// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
if (args.Length > 0)
{
  //foreach (var arg in args)
  for(var i = 0; i < args.Length; i++)
  {
    Console.WriteLine($"Argument[{i}]={args[i]}");
  }
}
else
{
  Console.WriteLine("No arguments");
}