using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Console;

namespace Inje.AIConvergence.Mvc.Controllers;

public class RolesController : Controller
{
  private string AdminRole = "Administrators";
  private string UserEmail = "hwlee@inje.ac.kr";
  private readonly RoleManager<IdentityRole> roleManager;
  private readonly UserManager<IdentityUser> userManager;

  public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
  {
    this.roleManager = roleManager;
    this.userManager = userManager;
  }
  public async Task<IActionResult> Index()
  {
    WriteLine("[DEBUG-hwlee]Index of RolesController");
    if(!(await roleManager.RoleExistsAsync(AdminRole)))
    {
      await roleManager.CreateAsync(new IdentityRole(AdminRole));
    }
    IdentityUser user = await userManager.FindByEmailAsync(UserEmail);
    WriteLine($"[DEBUG-hwlee]user: {user?.UserName}");
    if (user == null)
    {
      user = new();
      user.UserName = UserEmail; user.Email = UserEmail;
      IdentityResult result = await userManager.CreateAsync(user, "Pa$$w0rd");
      if(result.Succeeded)
      {
        WriteLine($"User {user.UserName} created successfully.");
      }
      else
      {
        foreach(IdentityError error in result.Errors)
        {
          WriteLine(error.Description+ Environment.NewLine);
        }
      }
    }
    WriteLine($"[DEBUG-hwlee]user.EmailConfirmed: {user?.EmailConfirmed}");
    if (!user.EmailConfirmed)
    {
      string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
      IdentityResult result = await userManager.ConfirmEmailAsync(user, token);
      if(result.Succeeded)
      {
        WriteLine($"User {user.UserName} email confirmed successfully.");
      }
      else
      {
        foreach(IdentityError error in result.Errors)
        {
          WriteLine(error.Description+ Environment.NewLine);
        }
      }
    }
    if(!(await userManager.IsInRoleAsync(user, AdminRole)))
    {
      WriteLine($"[DEBUG-hwlee]{user.UserName} is not in {AdminRole}");
      IdentityResult result = await userManager.AddToRoleAsync(user, AdminRole);
      if (result.Succeeded)
      {
        WriteLine($"User {user.UserName} added to {AdminRole} successfully.");
      }
      else
      {
        foreach (IdentityError error in result.Errors)
        {
          WriteLine(error.Description + Environment.NewLine);
        }
      }
    }
    else
    {
      WriteLine($"[DEBUG-hwlee]{user.UserName} is in {AdminRole}");
    }
    WriteLine($"[DEBUG-hwlee]Redirecting to Home");
    return Redirect("/");
  }
}
