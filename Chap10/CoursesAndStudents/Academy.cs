using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using static System.Console;

namespace CoursesAndStudents;

public class Academy : DbContext
{
  public DbSet<Student>? Students { get; set; }
  public DbSet<Course>? Courses { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    //string path = Path.Combine(
    //  Environment.CurrentDirectory, "Academy.db");
    //WriteLine($"Using {path} database file.");
    //optionsBuilder.UseSqlite($"Filename={path}");
    //SQLitePCL.Batteries.Init();

    WriteLine($"Connecting SQL Server...");
    string connection = "Data Source=.\\SQLEXPRESS;" +
      "Initial Catalog=Academy;" +
      "Integrated Security=true;" +
      "MultipleActiveResultSets=true;";
    optionsBuilder.UseSqlServer(connection);
    //optionsBuilder.UseSqlServer(
    //  @"Data Source=.\SQLEXPRESS;Initial Catalog=Academy;Integrated Security=true;MultipleActiveResultSets=true;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Student>()
      .Property(s => s.LastName).HasMaxLength(30).IsRequired();
    Student alice = new() { StudentId = 20230001, FirstName = "Alice", LastName = "Jones" };
    Student bob = new() { StudentId = 20230002, FirstName = "Bob", LastName = "Smith" };
    Student hwlee = new() { StudentId = 20230003, FirstName = "형원", LastName = "이" };
    Student cecillia = new() { StudentId = 20230004, FirstName = "Cecillia", LastName = "Ramirez" };

    Course csharp = new()
    {
      CourseId = 1,
      Title = "C# 10 and .NET",
    };
    Course web = new()
    {
      CourseId = 2,
      Title = "Web Programming",
    };
    Course unity = new()
    {
      CourseId = 3,
      Title = "Game Development with Unity",
    };

    modelBuilder.Entity<Student>()
      .HasData(alice, bob, hwlee, cecillia);

    modelBuilder.Entity<Course>()
      .HasData(csharp, web, unity);
    modelBuilder.Entity<Course>()
      .HasMany(c => c.Students)
      .WithMany(s => s.Courses)
      .UsingEntity(e => e.HasData(
        new { CoursesCourseId = 1, StudentsStudentId = 20230001 },
        new { CoursesCourseId = 1, StudentsStudentId = 20230002 },
        new { CoursesCourseId = 1, StudentsStudentId = 20230003 },
        new { CoursesCourseId = 1, StudentsStudentId = 20230004 },
        new { CoursesCourseId = 2, StudentsStudentId = 20230002 },
        new { CoursesCourseId = 3, StudentsStudentId = 20230004 }
        ));
  }
}
