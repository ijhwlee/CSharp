﻿// See https://aka.ms/new-console-template for more information
using AIConvergence.Shared;
using System;
using static System.Console;

Person bob = new();
bob.Name = "Bob Smith";
bob.DateOfBirth = new DateTime(1965, 12, 22);
WriteLine($"{bob.Name} Is a {Person.Species}");
WriteLine($"{bob.Name} was born on {bob.HomePlanet}");
WriteLine(format: "{0} was born on {1:yyyy년 MMMM d일, dddd}",
  arg0: bob.Name,
  arg1: bob.DateOfBirth);
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon |
  WondersOfTheAncientWorld.ColossusOfRhodes;
WriteLine(format: "{0}'s favorite wonder is {1}. Its integer is {2}",
  arg0: bob.Name,
  arg1: bob.FavoriteAncientWonder,
  arg2: (int)bob.FavoriteAncientWonder);
WriteLine(format: "{0}'s bucket list is {1}. Its integer is {2}",
  arg0: bob.Name,
  arg1: bob.BucketList,
  arg2: (int)bob.BucketList);

bob.Children.Add(new Person { Name = "Alfred" });
bob.Children.Add(new Person { Name = "Zoe" });

WriteLine($"{bob.Name} has {bob.Children.Count} children:");
for(int childIndex=0; childIndex < bob.Children.Count; childIndex++)
{
  WriteLine($"  {bob.Children[childIndex].Name}");
}
foreach(Person person in bob.Children)
{
  WriteLine($"  {person.Name}");
}
bob.WriteToConsole();
WriteLine(bob.GetOrigin());
(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");
var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");
(string name, int number) = bob.GetNamedFruit();
WriteLine($"Deconstructed: {name}, {number}.");

var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

Person alice = new()
{
  Name = "Alice Jones",
  DateOfBirth = new(1998, 3, 7)
};
WriteLine(format: "{0} was born on {1:yyyy년 MMMM d일, dddd}",
  arg0: alice.Name,
  arg1: alice.DateOfBirth);

//BankAccount.InterestRate = 0.012M;

BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;
WriteLine(format: "{0} earned {1:C} interest.",
  arg0: jonesAccount.AccountName,
  arg1: jonesAccount.Balance*BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine(format: "{0} earned {1:C} interest.",
  arg0: gerrierAccount.AccountName,
  arg1: gerrierAccount.Balance * BankAccount.InterestRate);

Person blankPerson = new();
WriteLine(format:
  "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
  arg0: blankPerson.Name,
  arg1: blankPerson.HomePlanet,
  arg2: blankPerson.Instantiated);

Person gunnyPerson = new(initialName: "Gunny", homePlanet: "Mars");
WriteLine(format:
  "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
  arg0: gunnyPerson.Name,
  arg1: gunnyPerson.HomePlanet,
  arg2: gunnyPerson.Instantiated);

var (name1, dob1) = bob;
WriteLine($"Deconstructed: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");

WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily"));

WriteLine(bob.OptionalParameters());
WriteLine(bob.OptionalParameters("Jump!", 78.9));
WriteLine(bob.OptionalParameters(number: 23.5, command: "Hide"));
WriteLine(bob.OptionalParameters("Poke!", active:false));

int a = 10;
int b = 20;
int c = 30;
WriteLine($"Before: a = {a}, b = {b}, c = {c}");
bob.PassingParameters(a, ref b, out c);
WriteLine($"After: a = {a}, b = {b}, c = {c}");

Person sam = new()
{
  Name = "Sam",
  DateOfBirth = new(1972, 1, 27)
};
WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);
sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"{sam.Name}'s favorite ice-cream is {sam.FavoriteIceCream}");
sam.FavoritePrimaryColor = "Green";
WriteLine($"{sam.Name}'s favorite primary color is {sam.FavoritePrimaryColor}");

sam.Children.Add(new() { Name = "Charlie"});
sam.Children.Add(new() { Name = "Ella" });
WriteLine($"{sam.Name}'s first child is is {sam.Children[0].Name}");
WriteLine($"{sam.Name}'s second child is is {sam.Children[1].Name}");

WriteLine($"{sam.Name}'s first child is is {sam[0].Name}");
WriteLine($"{sam.Name}'s second child is is {sam[1].Name}");

var harry = new Person { Name = "Harry" };
var mary = new Person { Name = "Mary" };
var jill = new Person { Name = "Jill" };

var baby1 = mary.ProcreateWith(harry);
baby1.Name = "Gary";

var baby2 = Person.Procreate(harry, jill);
var baby3 = harry * mary;

WriteLine($"{harry.Name} has {harry.Children.Count} children.");
WriteLine($"{mary.Name} has {mary.Children.Count} children.");
WriteLine($"{jill.Name} has {jill.Children.Count} children.");
WriteLine(
  format: "{0}'s first child is named \"{1}\".",
  arg0: harry.Name,
  arg1: harry.Children[0].Name);

WriteLine($"5! is {Person.Factorial(5)}");

static void Harry_Shout(object? sender, EventArgs e)
{
  if (sender is null) return;
  Person p = (Person)sender;
  WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
}

harry.Shout += Harry_Shout;
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2;
WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookupObject[key]);

WriteLine(format: "Key {0} has value: {1}",
  arg0: harry,
  arg1: lookupObject[harry]);

Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

key = 3;
WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookupIntString[key]);

Person[] people =
{
  new() {Name = "Simon" },
  new() {Name = "Jenny" },
  new() {Name = "Adam" },
  new() {Name = "Richard" }
};

WriteLine("Initial list of people:");
foreach(Person p in people)
{
  WriteLine($"  {p.Name}");
}

WriteLine("Use Person;s IComparable implementation to sort:");
Array.Sort(people);
foreach (Person p in people)
{
  WriteLine($"  {p.Name}");
}

WriteLine("Use PersonComparer's IComparer implementation to sort:");
Array.Sort(people, new PersonComparer());
foreach (Person p in people)
{
  WriteLine($"  {p.Name}");
}

DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;
WriteLine($"({dv1.x}, {dv1.y}) + ({dv2.x}, {dv2.y}) = ({dv3.x}, {dv3.y})");

Employee john = new()
{
  Name = "John Jones",
  DateOfBirth = new(year: 1990, month: 7, day: 28)
};
john.EmployeeCode = "IJ001";
john.HireDate = new(year: 2022, month: 12, day: 1);
john.WriteToConsole();
WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

WriteLine(john.ToString());

Employee aliceInEmployee = new Employee
{ Name = "Alice", EmployeeCode = "IJ002" };

Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

if (aliceInPerson is Employee)
{
  WriteLine($"{nameof(aliceInPerson)} IS an Employee");
  Employee explicitAlice = (Employee)aliceInPerson;
}

Employee aliceAsEmployee = aliceInPerson as Employee;
if(aliceAsEmployee != null)
{
  WriteLine($"{nameof(aliceInPerson)} AS an Employee");
}

try
{
  john.TimeTravel(new DateTime(2025, 12, 31));
  john.TimeTravel(new DateTime(1950, 12, 31));
}
catch (PersonException ex)
{
  WriteLine(ex.Message);
}

string email1 = "ijhwlee@gmail.com";
string email2 = "hwlee&inje.ac.kr";
WriteLine(
  "{0} is a valid e-mail address: {1}",
  arg0: email1,
  arg1: email1.IsValidEmail());

WriteLine(
  "{0} is a valid e-mail address: {1}",
  arg0: email2,
  arg1: email2.IsValidEmail());
