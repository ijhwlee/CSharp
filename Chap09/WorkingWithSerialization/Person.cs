using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIConvergence.Shared;

public class Person
{
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public DateTime DateOfBirth { get; set; }
  public HashSet<Person>? Children { get; set; }
  protected decimal Salary { get; set; }

  public Person() { }
  public Person(decimal initialSalary)
  {
    Salary = initialSalary;
  }
}
