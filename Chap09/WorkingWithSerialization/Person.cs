﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AIConvergence.Shared;

public class Person
{
  [XmlAttribute("fname")]
  public string? FirstName { get; set; }
  [XmlAttribute("lname")]
  public string? LastName { get; set; }
  [XmlAttribute("dob")]
  public DateTime DateOfBirth { get; set; }
  public HashSet<Person>? Children { get; set; }
  protected decimal Salary { get; set; }

  public Person() { }
  public Person(decimal initialSalary)
  {
    Salary = initialSalary;
  }
}
