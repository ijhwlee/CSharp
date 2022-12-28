using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Inje.AIConvergence.Shared;

public static class NumbersToWords
{
  public enum NumberSystem
  {
    None, Eng, Kor
  };
  public static NumberSystem numberSystem = NumberSystem.Eng;
  // Single-digit and small number names
  private static string[] smallNumbers = new string[]
    {
        "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
        "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
        "sixteen", "seventeen", "eighteen", "nineteen"
    };
  private static string[] unitsKorean = new string[]
    {
        "", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구"
    };

  // Tens number names from twenty upwards
  private static string[] tens = new string[]
    {
        "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy",
        "eighty", "ninety"
    };
  private static string[] tensKorean = new string[]
    {
        "", "십", "이십", "삼십", "사십", "오십", "육십", "칠십",
        "팔십", "구십"
    };
  private static string[] hundredsKorean = new string[]
    {
        "", "백", "이백", "삼백", "사백", "오백", "육백", "칠백",
        "팔백", "구백"
    };
  private static string[] thousandsKorean = new string[]
    {
        "", "천", "이천", "삼천", "사천", "오천", "육천", "칠천",
        "팔천", "구천"
    };

  // Scale number names for use during recombination
  private static string[] scaleNumbers = new string[]
    {
        "", "thousand", "million", "billion", "trillion",
        "quadrillion", "quintillion"
    };
  private static string[] scaleNumbersKorean = new string[]
    {
        "", "만", "억", "조",
        "경", "해", "자", "양", "구", "간", "정", "재", "극"
    };
  // 경:10^16, 해:10^20, 자:10^24, 양:10^28, 구:10^32, 간:10^36, 정:10^40, 재:10^44, 극:10^48

  private static readonly int groups = 7; // i.e. up to quintillion
  private static readonly int groupsKorean = 13; // i.e. up to 극

  public static void SetNumberSystem(NumberSystem system)
  {
    WriteLine($"[DEBUG-hwlee]NumbersToWords:SetNumberSystem system = {system} ============");
    numberSystem = system;
  }
  public static string ToWords(this int number)
  {
    return ToWords((BigInteger)number);
  }

  public static string ToWords(this long number)
  {
    return ToWords((BigInteger)number);
  }

  public static string ToWords(this BigInteger number)
  {
    WriteLine($"[DEBUG-hwlee]NumbersToWords:ToWords system = {numberSystem}, number = {number} ============");
    if (numberSystem == NumberSystem.Kor)
    {
      WriteLine($"[DEBUG-hwlee]NumbersToWords:ToWords calling ToWordsKorean ============");
      return ToWordsKorean(number);
    }
    /* 
      Convert A Number into Words
      by Richard Carr, published at http://www.blackwasp.co.uk/numbertowords.aspx
    */

    /*
      Zero Rule.
      If the value is 0 then the number in words is 'zero' and no other rules apply.
    */
    if (number == 0)
    {
      return "zero";
    }

    /*
      Three Digit Rule.
      The integer value is split into groups of three digits starting from the 
      right-hand side. Each set of three digits is then processed individually 
      as a number of hundreds, tens and units. Once converted to text, the 
      three-digit groups are recombined with the addition of the relevant scale 
      number (thousand, million, billion).
    */

    // Array to hold the specified number of three-digit groups
    int[] digitGroups = new int[groups];

    // Ensure a positive number to extract from
    var positive = BigInteger.Abs(number);

    // Extract the three-digit groups
    for (int i = 0; i < groups; i++)
    {
      digitGroups[i] = (int)(positive % 1000);
      positive /= 1000;
    }

    // Convert each three-digit group to words
    string[] groupTexts = new string[groups];

    for (int i = 0; i < groups; i++)
    {
      // call a local function (see below)
      groupTexts[i] = ThreeDigitGroupToWords(digitGroups[i]);
    }

    /*
      Recombination Rules.
      When recombining the translated three-digit groups, each group except the 
      last is followed by a large number name and a comma, unless the group is 
      blank and therefore not included at all. One exception is when the final 
      group does not include any hundreds and there is more than one non-blank 
      group. In this case, the final comma is replaced with 'and'. eg. 
      'one billion, one million and twelve'.
    */

    // Recombine the three-digit groups
    string combined = groupTexts[0];
    bool appendAnd;

    // Determine whether an 'and' is needed
    appendAnd = (digitGroups[0] > 0) && (digitGroups[0] < 100);

    // Process the remaining groups in turn, smallest to largest
    for (int i = 1; i < groups; i++)
    {
      // Only add non-zero items
      if (digitGroups[i] != 0)
      {
        // Build the string to add as a prefix
        string prefix = groupTexts[i] + " " + scaleNumbers[i];

        if (combined.Length != 0)
        {
          prefix += appendAnd ? " and " : ", ";
        }

        // Opportunity to add 'and' is ended
        appendAnd = false;

        // Add the three-digit group to the combined string
        combined = prefix + combined;
      }
    }

    // Converts a three-digit group into English words
    string ThreeDigitGroupToWords(int threeDigits)
    {
      // Initialise the return text
      string groupText = "";

      // Determine the hundreds and the remainder
      int hundreds = threeDigits / 100;
      int tensUnits = threeDigits % 100;

      /* 
        Hundreds Rules.
        If the hundreds portion of a three-digit group is not zero, the number of 
        hundreds is added as a word. If the three-digit group is exactly divisible 
        by one hundred, the text 'hundred' is appended. If not, the text 
        "hundred and" is appended. eg. 'two hundred' or 'one hundred and twelve'
      */

      if (hundreds != 0)
      {
        groupText += smallNumbers[hundreds] + " hundred";

        if (tensUnits != 0)
        {
          groupText += " and ";
        }
      }

      // Determine the tens and units
      int tens = tensUnits / 10;
      int units = tensUnits % 10;

      /* Tens Rules.
         If the tens section of a three-digit group is two or higher, the appropriate 
         '-ty' word (twenty, thirty, etc.) is added to the text and followed by the 
         name of the third digit (unless the third digit is a zero, which is ignored). 
         If the tens and the units are both zero, no text is added. For any other value, 
         the name of the one or two-digit number is added as a special case.
      */

      if (tens >= 2)
      {
        groupText += NumbersToWords.tens[tens];
        if (units != 0)
        {
          groupText += " " + smallNumbers[units];
        }
      }
      else if (tensUnits != 0)
        groupText += smallNumbers[tensUnits];

      return groupText;
    }

    /* Negative Rule.
       Negative numbers are always preceded by the text 'negative'.
    */
    if (number < 0)
    {
      combined = "negative " + combined;
    }

    return combined;
  }
  private static string ToWordsKorean(BigInteger number)
  {
    /* 
      Convert A Number into Words
      by Richard Carr, published at http://www.blackwasp.co.uk/numbertowords.aspx
    */

    /*
      Zero Rule.
      If the value is 0 then the number in words is 'zero' and no other rules apply.
    */
    WriteLine($"[DEBUG-hwlee]NumbersToWords:ToWordsKorean system = {numberSystem}, number = {number} ============");
    if (number == 0)
    {
      return "영";
    }

    /*
      Three Digit Rule.
      The integer value is split into groups of three digits starting from the 
      right-hand side. Each set of four digits is then processed individually 
      as a number of thounands, hundreds, tens and units. Once converted to text, the 
      four-digit groups are recombined with the addition of the relevant scale 
      number (천, 만, 억, 조).
    */

    // Array to hold the specified number of four-digit groups
    int[] digitGroups = new int[groupsKorean];

    // Ensure a positive number to extract from
    var positive = BigInteger.Abs(number);

    // Extract the three-digit groups
    for (int i = 0; i < groupsKorean; i++)
    {
      digitGroups[i] = (int)(positive % 10000);
      positive /= 10000;
    }

    // Convert each three-digit group to words
    string[] groupTexts = new string[groupsKorean];

    for (int i = 0; i < groupsKorean; i++)
    {
      // call a local function (see below)
      groupTexts[i] = FourDigitGroupToWords(digitGroups[i]);
    }

    /*
      Recombination Rules.
      When recombining the translated three-digit groups, each group except the 
      last is followed by a large number name and a comma, unless the group is 
      blank and therefore not included at all. One exception is when the final 
      group does not include any hundreds and there is more than one non-blank 
      group. In this case, the final comma is replaced with 'and'. eg. 
      'one billion, one million and twelve'.
    */

    // Recombine the three-digit groups
    string combined = groupTexts[0];

    // Process the remaining groups in turn, smallest to largest
    for (int i = 1; i < groups; i++)
    {
      // Only add non-zero items
      if (digitGroups[i] != 0)
      {
        // Build the string to add as a prefix
        string prefix = groupTexts[i] + scaleNumbersKorean[i] + " ";

        // Add the three-digit group to the combined string
        combined = prefix + combined;
      }
    }

    WriteLine($"[DEBUG-hwlee]NumbersToWords:ToWordsKorean combined = {combined} ============");
    // Converts a four-digit group into English words
    string FourDigitGroupToWords(int fourDigits)
    {
      // Initialise the return text
      string groupText = "";

      // Determine the hundreds and the remainder
      int thousands = fourDigits / 1000;
      int hundreds = (fourDigits%1000) / 100;
      int tensUnits = (fourDigits % 100) / 10;
      int units = fourDigits % 10;

      groupText += thousandsKorean[thousands];
      groupText += hundredsKorean[hundreds];
      groupText += tensKorean[tensUnits];
      groupText += unitsKorean[units];

      return groupText;
    }

    /* Negative Rule.
       Negative numbers are always preceded by the text 'negative'.
    */
    if (number < 0)
    {
      combined = "음수 " + combined;
    }

    WriteLine($"[DEBUG-hwlee]NumbersToWords:ToWordsKorean Final combined = {combined} ============");
    return combined;
  }
}