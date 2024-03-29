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

object[] passengers =
{
  new FirstClassPassenger {AirMiles = 1_419},
  new FirstClassPassenger {AirMiles = 16_562},
  new BusinessClassPassenger(),
  new CoachClassPassenger { CarryOnKG = 25.7},
  new CoachClassPassenger { CarryOnKG = 0},
};

foreach (object passenger in passengers)
{
  decimal flightCost = passenger switch
  {
    //FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
    //FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
    //FirstClassPassenger _ => 2000M,
    FirstClassPassenger p => p.AirMiles switch
    {
      > 35000 => 1500M,
      > 1500 => 1750M,
      _ => 2000M
    },
    BusinessClassPassenger _ => 1000M,
    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
    CoachClassPassenger _ => 650M,
    _ => 800M
  };
  WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

ImmutablePerson jeff = new()
{
  FirstName = "Jeff",
  LastName = "Winger"
};
//jeff.FirstName = "Goeff";

ImmutableVechicle car = new()
{
  Brand = "Hyundai G80 3.3HTRAC",
  Color = "Silver White Tint",
  Wheels = 4
};
ImmutableVechicle repaintedCar = car
  with { Color = "Polynomial Bronze" };

WriteLine($"Original car color was {car.Color}");
WriteLine($"New car color is {repaintedCar.Color}");

ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar;
WriteLine($"{who} is a {what}");