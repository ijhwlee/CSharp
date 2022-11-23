// See https://aka.ms/new-console-template for more information
using static System.Console;

//TimesTable(255);
decimal taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "FR");
WriteLine($"You must pay {taxToPay} in tax.");

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
