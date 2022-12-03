// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.Globalization;
using static System.Console;

WriteLine("Earliest date/TimeOnly value is: {0}", arg0: DateTime.MinValue);
WriteLine("UNIX epoch date/time value is: {0}", arg0: DateTime.UnixEpoch);
WriteLine("Date/time value Now is: {0}", arg0: DateTime.Now);
WriteLine("Date/time value Today is: {0}", arg0: DateTime.Today);

DateTime christmas = new(year: 2022, month: 12, day: 25);
WriteLine("Christmas: {0}", arg0: christmas);
WriteLine("Christmas: {0:dddd, dd일 MMMM yyyy년}", arg0: christmas);
WriteLine("Christmas: {0:yyyy년 MMMM dd일(dddd)}", arg0: christmas);
WriteLine("Christmas is in month {0} of the year.", arg0: christmas.Month);
WriteLine("Christmas is day {0} of the year", arg0: christmas.DayOfYear);
WriteLine("Christmas {0} is on {1}", arg0: christmas.Year, arg1: christmas.DayOfWeek);

DateTime beforeXmas = christmas.Subtract(TimeSpan.FromDays(12));
DateTime afterXmas = christmas.AddDays(12);
WriteLine("12 days before Christmas is: {0}", arg0: beforeXmas);
WriteLine("12 days after Christmas is: {0}", arg0: afterXmas);

TimeSpan untilChristmas = christmas - DateTime.Now;
WriteLine("There are {0} days and {1} hours until Christmas.",
  arg0: untilChristmas.Days, arg1: untilChristmas.Hours);
WriteLine("There are {0:N0} hours until Christmas.",
  arg0: untilChristmas.TotalHours);
WriteLine("There are {0:N0} seconds until Christmas.",
  arg0: untilChristmas.TotalSeconds);

DateTime kidsWakeup = new(year: 2022, month: 12, day: 25, hour: 6, minute: 30, second: 0);
WriteLine("Kids wake up on Christmas: {0}", kidsWakeup);
WriteLine("The kids woke me up at {0}", kidsWakeup.ToShortTimeString());

WriteLine("Current culture is: {0}", arg0: CultureInfo.CurrentCulture.Name);

string textDate = "4 July 2022";
DateTime independencyDay = DateTime.Parse(textDate);
WriteLine("Text: {0}, DateTime: {1:d MMMM}", arg0:textDate, arg1: independencyDay);

//textDate = "4/7/2022";
textDate = "2022/7/4";
independencyDay = DateTime.Parse(textDate);
WriteLine("Text: {0}, DateTime: {1:d MMMM}", arg0: textDate, arg1: independencyDay);

independencyDay = DateTime.Parse(textDate,
  provider: CultureInfo.GetCultureInfo("en-US"));
WriteLine("Text: {0}, DateTime: {1:dd MMMM}", arg0: textDate, arg1: independencyDay);

independencyDay = DateTime.Parse(textDate,
  provider: CultureInfo.GetCultureInfo("ko-KR"));
WriteLine("Text: {0}, DateTime: {1:dd MMMM}", arg0: textDate, arg1: independencyDay);

independencyDay = DateTime.Parse(textDate,
  provider: CultureInfo.GetCultureInfo("en-GB"));
WriteLine("Text: {0}, DateTime: {1:dd MMMM}", arg0: textDate, arg1: independencyDay);

for(int year = 2020; year < 2026; year++)
{
  Write($"{year} is a leap year: {DateTime.IsLeapYear(year)}. ");
  WriteLine("There are {0} days is February {1}.",
    arg0: DateTime.DaysInMonth(year: year, month: 2), arg1: year);
}
WriteLine("Is Christmas daylight saving time? {0}", 
  arg0: christmas.IsDaylightSavingTime());
WriteLine("Is July 4th daylight saving time? {0}",
  arg0: independencyDay.IsDaylightSavingTime());

DateOnly queensBirthday = new(year: 2023, month: 4, day: 21);
WriteLine($"The Queen's next birthday is on {queensBirthday}.");

TimeOnly partyStarts = new(hour: 20, minute: 30);
WriteLine($"The Queen's party starts at {partyStarts}.");

DateTime calendarEntry = queensBirthday.ToDateTime(partyStarts);
WriteLine($"Add to your calendar: {calendarEntry}.");
