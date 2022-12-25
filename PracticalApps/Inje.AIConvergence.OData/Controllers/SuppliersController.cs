using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Inje.AIConvergence.Shared;
using static System.Console;

namespace Inje.AIConvergence.OData.Controllers;

public class SuppliersController : ODataController
{
  private readonly NorthwindContext db;
  public SuppliersController(NorthwindContext db)
  {
    this.db = db;
  }
  [EnableQuery]
  public IActionResult Get()
  {
    return Ok(db.Suppliers);
  }

  [EnableQuery]
  public IActionResult Get(int key)
  {
    return Ok(db.Suppliers.Find(key));
  }
}
