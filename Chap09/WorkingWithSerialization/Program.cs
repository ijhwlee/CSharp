// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using AIConvergence.Shared;

using static System.Console;
using static System.Environment;
using static System.IO.Path;

List<Person> people = GeneratePersons();
SaveXmlAndShow(people);

static void SaveXmlAndShow(List<Person> people)
{
  WriteLine("=============== SaveXmlAndShow =====================");
  XmlSerializer xs = new(people.GetType());
  string path = Combine(CurrentDirectory, "people.xml");
  using (FileStream stream = File.Create(path))
  {
    xs.Serialize(stream, people);
  }
  WriteLine("Written {0:N0} bytes of XML to {1}",
    arg0: new FileInfo(path).Length,
    arg1: path);
  WriteLine();

  WriteLine(File.ReadAllText(path));
}
static List<Person> GeneratePersons()
{
  List<Person> people = new()
  {
    new(30000M)
    {
      FirstName = "Alice",
      LastName = "Smith",
      DateOfBirth = new(1974, 3,14)
    },
    new(30000M)
    {
      FirstName = "Alice",
      LastName = "Smith",
      DateOfBirth = new(1974, 3,14)
    },
    new(20000M)
    {
      FirstName = "Bob",
      LastName = "Jones",
      DateOfBirth = new(1967, 11,1)
    },
    new(10000M)
    {
      FirstName = "Charlie",
      LastName = "Cox",
      DateOfBirth = new(1985, 7,30),
      Children = new()
      {
        new(0M)
        {
          FirstName = "Sally",
          LastName = "Cox",
          DateOfBirth = new(2001, 9, 11)
        }
      }
    },
    new(100_000_000_000M)
    {
      FirstName = "형원",
      LastName = "이",
      DateOfBirth = new(1959, 6,3),
      Children = new()
      {
        new(20000000M)
        {
          FirstName = "Keunmin",
          LastName = "Lee",
          DateOfBirth = new(1993, 9, 10)
        }
      }
    }
  };
  return people;
}