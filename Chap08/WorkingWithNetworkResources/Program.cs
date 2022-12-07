// See https://aka.ms/new-console-template for more information
using AIConvergence.Shared;
using System.Net;
using System.Net.NetworkInformation;
using static System.Console;

Uri uri = WorkingWithURL();
WorkingWithPing(uri);

static void WorkingWithPing(Uri uri)
{
  try
  {
    Ping ping = new();
    WriteLine("Pinging server, Please wait...");
    PingReply reply = ping.Send(uri.Host);

    WriteLine($"{uri.Host} was pinged and replied: {reply.Status}");
    if(reply.Status == IPStatus.Success)
    {
      WriteLine("Reply from {0} took {1:N0}ms",
        arg0: reply.Address,
        arg1: reply.RoundtripTime);
    }
  }
  catch(Exception ex)
  {
    WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
  }
}

static Uri WorkingWithURL()
{
  string? url;
  WriteLine("================= Working with URLs =================");
  while (true)
  {
    Write("Enter a valid web address: ");
    url = ReadLine();
    if (string.IsNullOrWhiteSpace(url))
    {
      url = "https://stackoverflow.com/search?q=securestring";
      break;
    }
    if (url.IsValidURL())
    {
      if (CheckWithDns(url))
      {
        break;
      }
      WriteLine($"{url} does not have DNS entry, try again.");
    }
    else
    {
      WriteLine($"{url} is not valid URL, try again.");
    }
  };

  Uri uri = new(url);
  WriteLine($"URL: {url}");
  WriteLine($"Scheme: {uri.Scheme}");
  WriteLine($"Port: {uri.Port}");
  WriteLine($"Host: {uri.Host}");
  WriteLine($"Path: {uri.AbsolutePath}");
  WriteLine($"Query: {uri.Query}");

  IPHostEntry entry = Dns.GetHostEntry(uri.Host);
  WriteLine($"{entry.HostName} has the following IP addresses: ");
  foreach (IPAddress address in entry.AddressList)
  {
    WriteLine($"  {address} ({address.AddressFamily})");
  }

  return uri;
}
static bool CheckWithDns(string url)
{
  Uri uri = new(url);
  try
  {
    IPHostEntry entry = Dns.GetHostEntry(uri.Host);
    if (entry.AddressList.Length > 0)
    {
      return true;
    }
    return false;
  }
  catch (System.Net.Sockets.SocketException)
  {
    return false;
  }
}