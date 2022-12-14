// See https://aka.ms/new-console-template for more information
using System.Linq;
using static System.Console;

LinqWithArrayOfStrings();
LinqWithArrayOfExceptions();

static void LinqWithArrayOfStrings()
{
  WriteLine("===================== LinqWithArrayOfStrings =====================");
  var names = new string[] {"Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin",
    "Toby", "Creed", "철수"};
  //var query = names.Where(new Func<string, bool>(NameLongerThanFour));
  //var query = names.Where(NameLongerThanFour);
  var query = names.Where(name => name.Length > 4)
    .OrderBy(name => name.Length)
    .ThenBy(name => name);

  foreach(string item in query)
  {
    WriteLine(item);
  }
}

static void LinqWithArrayOfExceptions()
{
  WriteLine("================ LinqWithArrayOfExceptions ======================");
  var errors = new Exception[]
  {
    new ArgumentException(),
    new SystemException(),
    new IndexOutOfRangeException(),
    new InvalidOperationException(),
    new NullReferenceException(),
    new InvalidCastException(),
    new OverflowException(),
    new DivideByZeroException(),
    new ApplicationException()
  };
  var numberErrors = errors.OfType<ArithmeticException>();
  foreach(var error in numberErrors)
  {
    WriteLine(error);
  }
}
static bool NameLongerThanFour(string name)
{
  return name.Length > 4;
}