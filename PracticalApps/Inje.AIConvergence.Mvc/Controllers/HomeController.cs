using Inje.AIConvergence.Mvc.Models;
using Inje.AIConvergence.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Console;

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

    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
    public IActionResult Index()
    {
      _logger.LogError("This is a serious error (not really!)");
      _logger.LogWarning("This is your first warning!");
      _logger.LogWarning("This is your second warning!");
      _logger.LogInformation("I am in the Index method of HomeController.");
      WriteLine("[DEBUG-hwlee]I am in the Index method of HomeController.");
      HomeIndexViewModel model = new
      (
        VisitorCount: (new Random()).Next(1, 1001),
        Categories: db.Categories.ToList(),
        Products: db.Products.ToList()
      );
      return View(model);
    }

    [Route("private")]
    [Authorize(Roles = "Administrators")]
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