using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Inje.AIConvergence.Shared;

namespace AIConvergenceFeatures.Pages;

public class EmployeesPageModel : PageModel
{
  private NorthwindContext db;
  public Employee[] Employees { get; set; } = null;
  public EmployeesPageModel(NorthwindContext db)
  {
    this.db = db;
  }

  public void OnGet()
  {
    ViewData["Title"] = "Inje University AI Convergence B2B - Employees";
    Employees = db.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToArray();
  }
}