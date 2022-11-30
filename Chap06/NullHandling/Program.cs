// See https://aka.ms/new-console-template for more information
using static System.Console;

int thisCannotBeNull = 4;
//thisCannotBeNull = null;

int? thisCouldBeNull = null;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

thisCouldBeNull = 7;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

Address address = new();
address.Building = null;
address.Street = "Inje-ro"; // null;
address.City = "London";
address.Region = "Gyeongsangnam-do"; // null;

class Address
{
  public string? Building;
  public string Street =string.Empty;
  public string City = string.Empty;
  public string Region = string.Empty;
}