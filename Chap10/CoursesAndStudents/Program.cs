// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using CoursesAndStudents;
using static System.Console;

await GenerateData();

static async Task<int> GenerateData()
{
  WriteLine("============= GenerateDate in Code First Example ==================");
  using (Academy a = new())
  {
    bool deleted = await a.Database.EnsureDeletedAsync();
    //bool deleted = a.Database.EnsureDeleted();
    WriteLine($"Database deleted: {deleted}");
    bool created = await a.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}");

    WriteLine("SQL script used to create database:");
    WriteLine(a.Database.GenerateCreateScript());

    foreach(Student s in a.Students.Include( s => s.Courses))
    {
      WriteLine("{0} {1} attends the following {2} courses:",
        s.FirstName, s.LastName, s.Courses?.Count);
      foreach(Course c in s.Courses)
      { 
        WriteLine($"  {c.Title}");
      }
    }
  }
  return 0;
}