// See https://aka.ms/new-console-template for more information
using static System.Console;
using System.Collections.Generic;
using System.Runtime.InteropServices;

decimal number = 3;
WriteLine($"Decimal size {Marshal.SizeOf(number)}, {number}");

var keywords = new Dictionary<string, string>();
keywords.Add("int", $"{Marshal.SizeOf<int>()*8}-bit integer data type");
keywords.Add("long", $"{Marshal.SizeOf<long>() * 8}-bit integer data type");
keywords.Add("float", $"{Marshal.SizeOf<float>() * 8}-bit single precision floating point number");
keywords.Add("double", $"{Marshal.SizeOf<double>() * 8}-bit double precision floating point number");
keywords.Add("decimal", $"{Marshal.SizeOf<decimal>() * 8}-bit high precision floating point number");

WriteLine("Keywords and their definitions");
foreach(KeyValuePair<string, string> item in keywords)
{
  WriteLine($"  {item.Key}: {item.Value}");
}
WriteLine($"The definition of long is {keywords["long"]}");
