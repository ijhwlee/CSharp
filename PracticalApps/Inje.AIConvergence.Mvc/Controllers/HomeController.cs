using Inje.AIConvergence.Mvc.Models;
using Inje.AIConvergence.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Inje.AIConvergence.Mvc.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindContext db;

    public HomeController(ILogger<HomeController> logger, NorthwindContext db)
    {
      _logger = logger;
      this.db = db;
    }

    public async Task<IActionResult> Index()
    {
      HomeIndexViewModel model = new
      (
        VisitorCount: (new Random()).Next(1, 1001),
        Categories: await db.Categories.ToListAsync(),
        Products: await db.Products.ToListAsync()
      );
      return View(model);
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}