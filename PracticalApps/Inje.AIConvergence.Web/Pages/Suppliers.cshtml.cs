using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Inje.AIConvergence.Shared;

namespace Inje.AIConvergence.Web.Pages;

public class SuppliersModel : PageModel
{
  private NorthwindContext db;
  public IEnumerable<Supplier>? Suppliers { get; set; }
  [BindProperty]
  public Supplier? Supplier { get; set; }
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
  public IActionResult OnPost()
  {
    if((Supplier is not null) && ModelState.IsValid)
    {
      db.Suppliers.Add(Supplier);
      db.SaveChanges();
      return RedirectToAction("/suppliers");
    }
    else
    {
      return Page();
    }
  }
}
