using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIConvergence.Shared;

public class ImmutablePerson
{
  public string? FirstName { get; init; }
  public string? LastName { get; init;}
}

public record ImmutableVechicle
{
  public int Wheels { get; init; }
  public string? Color { get; init; }
  public string? Brand { get; init; }
}

//public record ImmutableAnimal
//{
//  public string Name { get; init; }
//  public string Species { get; init; }
//  public ImmutableAnimal(string name, string species)
//  {
//    Name = name;
//    Species = species;
//  }
//  public void Deconstruct(out string name, out string species)
//  {
//    name = Name;
//    species = Species;
//  }
//}
public record ImmutableAnimal(string Name, string Species);