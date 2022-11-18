// See https://aka.ms/new-console-template for more information
using static System.Console;
int x = 0;

while(x < 10)
{
  WriteLine(x);
  x++;
}

int tries = 0;
string? password;
do
{
  Write("Enter your password: ");
  password = ReadLine();
  tries++;
} while(password != "Pa$$w0rd" && tries < 10);
if (tries < 10)
{
  WriteLine("Correct!");
}
else
{
  WriteLine("You are wrong as 10 times!");
}
