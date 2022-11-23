// See https://aka.ms/new-console-template for more information
using static System.Console;

//TimesTable(255);
//decimal taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "FR");
//WriteLine($"You must pay {taxToPay} in tax.");
//RunFibImperative();
RunFibFunctional();

static void TimesTable(byte number)
{
  WriteLine($"This is the {number} times table:");
  for(int row = 1; row<=12; row++)
  {
    WriteLine($"{row} X {number} = {row*number}");
  }
  WriteLine();
}

static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
{
  decimal rate = 0.0M;
  switch(twoLetterRegionCode) 
  {
    case "CH":
      rate = 0.0M;
      break;
    case "DK":
    case "NO":
      rate = 0.25M;
      break;
    case "GB":
    case "FR":
      rate = 0.2M;
      break;
    case "HU":
      rate = 0.27M;
      break;
    case "OR":
    case "AK":
    case "MT":
      rate = 0.0M;
      break;
    case "ND":
    case "WI":
    case "ME":
    case "VA":
      rate = 0.05M;
      break;
    case "CA":
      rate = 0.0825M;
      break;
    default:
      rate = 0.06M;
      break;
  }
  return amount * rate;
}

static string CardinalToOrdinal(int number)
{
  switch(number)
  {
    case 11:
    case 12:
    case 13:
      return $"{number}th";
    default:
      int lastDigit = number % 10;
      string suffix = lastDigit switch
      {
        1 => "st",
        2 => "nd",
        3 => "rd",
        _ => "th"
      };
      return $"{number}{suffix}";
  }
}
static int FibImperative(int term)
{
  if(term == 1)
  {
    return 0;
  }
  else if (term == 2)
  {
    return 1;
  }
  else
  {
    return FibImperative(term - 1) + FibImperative(term - 2);
  }
}

static void RunFibImperative()
{
  for(int i=1; i <= 30; i++)
  {
    WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
      arg0: CardinalToOrdinal(i),
      arg1: FibImperative(term: i));
  }
}

static int FibFunctional(int term) =>
  term switch
  {
    1 => 0,
    2 => 1,
    _ => FibFunctional(term - 1) + FibFunctional(term - 2)
  };

static void RunFibFunctional()
{
  for(int i=1; i<=30; i++)
  {
    WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
      arg0: CardinalToOrdinal(i),
      arg1: FibFunctional(term: i));
  }
}