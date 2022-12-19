using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Inje.AIConvergence.Shared;

namespace Inje.AIConvergence.Web.Pages;

public class SuppliersModel : PageModel
{
  private NorthwindContext db;
  public IEnumerable<Supplier>? Suppliers { get; set; }
  public SuppliersModel(NorthwindContext injectedContext)
  {
    db = injectedContext;
  }
  public void OnGet()
  {
    ViewData["Title"] = "Inje University AI Convergence B2B - Suppliers";
    Suppliers = db.Suppliers
      .OrderBy(c => c.Country).ThenBy(c => c.CompanyName);
  }
}
