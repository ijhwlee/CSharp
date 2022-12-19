
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Inje.AIConvergence.Shared
{

  public static class StringExtensions
  {
    public static Task<bool> IsValidXmlTagAsync(this string input)
    {
      if(input == null)
      {
        return Task.FromException<bool>(
          new ArgumentNullException("Missing input parameter"));
      }
      if (input.Length == 0)
      {
        return Task.FromException<bool>(
          new ArgumentNullException("Input parameter is empty"));
      }
      return Task.FromResult(Regex.IsMatch(input,
        @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$"));
    }
    public static bool IsValidXmlTag(this string input)
    {
      return Regex.IsMatch(input,
        @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
    }
    public static bool IsValidPassword(this string input)
    {
      return Regex.IsMatch(input, "^[a-zA-Z0-9_-]{8,}$");
    }
    public static bool IsValidHex(this string input)
    {
      return Regex.IsMatch(input,
        "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
    }
    public static bool IsValidURL(this string input)
    {
      string regex = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";
      return Regex.IsMatch(input, regex);
    }
  }
}