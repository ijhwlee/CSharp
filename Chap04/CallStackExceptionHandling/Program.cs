// See https://aka.ms/new-console-template for more information
using AIConvergence;
using static System.Console;

WriteLine("In Main");
Alpha();

static void Alpha()
{
  WriteLine("In ALpha");
  Beta();
}

static void Beta()
{
  WriteLine("In Beta");
  try 
  {
    Calculator.Gamma();
  }
  catch (Exception ex)
  {
    WriteLine($"Cauught this: {ex.Message}");
    throw;
  }
}