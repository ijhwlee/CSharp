using Inje.AIConvergence.Shared;
using System.Security; // SecurityException
using System.Security.Principal; // IPrincipal
using System.Security.Claims; // ClaimsPrincipal, Claim

using static System.Console;

// See https://aka.ms/new-console-template for more information
WriteLine("======== Starting SecureApp ===========");

Protector.Register("Alice", "Pa$$w0rd", roles: new[] { "Admins" });
Protector.Register("Bob", "Pa$$w0rd", roles: new[] { "Sales", "TeamManager" });
Protector.Register("Eve", "Pa$$w0rd");

Write($"Enter your user name: ");
string? username = ReadLine();
Write($"Enter your password: ");
string? password = ReadLine();
if ((username == null) || (password == null))
{
  WriteLine("Username or password is null. Cannot login.");
  return;
}
Protector.LogIn(username, password);

if (Thread.CurrentPrincipal == null)
{
  WriteLine("Log in failed.");
  return;
}

IPrincipal p = Thread.CurrentPrincipal;
WriteLine($"IsAuthenticated: {p.Identity?.IsAuthenticated}");
WriteLine($"AuthenticationType: {p.Identity?.AuthenticationType}");
WriteLine($"Name: {p.Identity?.Name}");
WriteLine($"IsInRole(\"Admins\"): {p.IsInRole("Admins")}");
WriteLine($"IsInRole(\"Sales\"): {p.IsInRole("Sales")}");

if (p is ClaimsPrincipal)
{
  WriteLine($"{p.Identity?.Name} has the following claims:");
  IEnumerable<Claim>? claims = (p as ClaimsPrincipal)?.Claims;
  if (claims is not null)
  {
    foreach (Claim claim in claims)
    {
      WriteLine($"{claim.Type}: {claim.Value}");
    }
  }
}

try
{
  SecureFeature();
}
catch (Exception ex)
{
  WriteLine($"{ex.GetType()}: {ex.Message}");
}

static void SecureFeature()
{
  if (Thread.CurrentPrincipal == null)
  {
    throw new SecurityException("A user must be logged in to access this feature.");
  }
  if (!Thread.CurrentPrincipal.IsInRole("Admins"))
  {
    throw new SecurityException("User must be a member of Admins to access this feature.");
  }
  WriteLine("You have access to this secure feature.");
}