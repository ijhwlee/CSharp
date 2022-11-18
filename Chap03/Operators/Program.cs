// See https://aka.ms/new-console-template for more information
using static System.Console;

int a = 3;
int b = a++;
WriteLine($"a is {a} , b is {b}");
int c = 3;
int d = ++c;
WriteLine($"c is {c} , d is {d}");

int e = 11;
int f = 3;
WriteLine($"e is {e}, f is {f}");
WriteLine($" e + f = {e + f}");
WriteLine($" e - f = {e - f}");
WriteLine($" e * f = {e * f}");
WriteLine($" e / f = {e / f}");
WriteLine($" e % f = {e % f}");

double g = 11.0;
WriteLine($"g is {g:N1}, f is {f}");
WriteLine($"g / f = {g / f}");

bool a1 = true;
bool b1 = false;
WriteLine($"a1 & DoStuff() = {a1 & DoStuff()}");
WriteLine($"b1 & DoStuff() = {b1 & DoStuff()}");

WriteLine($"a1 && DoStuff() = {a1 && DoStuff()}");
WriteLine($"b1 && DoStuff() = {b1 && DoStuff()}");

WriteLine("Output integers as binary: ");
WriteLine($"a =   {ToBinaryString(a)}");
WriteLine($"b =   {ToBinaryString(b)}");
WriteLine($"a & b =   {ToBinaryString(a&b)}");

static bool DoStuff()
{
  WriteLine("I am doing some stuff.");
  return true;
}

static string ToBinaryString(int value)
{
  return Convert.ToString(value, toBase: 2).PadLeft(8, '0');
}