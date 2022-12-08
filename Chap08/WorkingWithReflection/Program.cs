// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Runtime.CompilerServices;
using AIConvergence.Shared;
using static System.Console;

ShowMetaData();

static void ShowMetaData()
{
  WriteLine("============== Showing Meta Data ================");
  WriteLine("Assembly metadata:");
  Assembly? assembly = Assembly.GetEntryAssembly();
  if(assembly is null)
  {
    WriteLine("Failed to get entry assembly.");
    return;
  }

  WriteLine($"  Full name: {assembly.FullName}");
  WriteLine($"  Location: {assembly.Location}");

  IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();

  WriteLine($"  Assembly-level attributes:");
  foreach(Attribute a in attributes)
  {
    WriteLine($"    {a.GetType()}");
  }

  AssemblyInformationalVersionAttribute? version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
  WriteLine($"  Version: {version?.InformationalVersion}");

  AssemblyCompanyAttribute? company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
  WriteLine($"  Company: {company?.Company}");

  WriteLine();
  WriteLine($"* Types:");
  Type[] types = assembly.GetTypes();
  foreach(Type t in types)
  {
    WriteLine();
    WriteLine($"Type: {t.FullName}");
    MemberInfo[] members = t.GetMembers();

    foreach(MemberInfo m in members)
    {
      WriteLine("{0}: {1} {2}",
        arg0: m.MemberType,
        arg1: m.Name,
        arg2: m.DeclaringType?.Name);

      IOrderedEnumerable<CoderAttribute> coders = 
        m.GetCustomAttributes<CoderAttribute>()
        .OrderByDescending(c => c.LastModified);

      foreach(CoderAttribute coder in coders)
      {
        WriteLine("-> Modified by {0} on {1}",
          coder.Coder, coder.LastModified.ToShortDateString());
      }
    }
  }
  return;
}
class Animal
{
  [Coder("Hyung Won Lee", "8 December 2022")]
  [Coder("Keunmin Ken Lee", "21 September 2022")]
  public void Speak()
  {
    WriteLine("Woof...");
  }
}