using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Inje.AIConvergence.Shared;
using static System.Console;

namespace Inje.AIConvergence.OData.Controllers;

public class CustomersController : ODataController
{
  private readonly NorthwindContext db;
  public CustomersController(NorthwindContext db)
  {
    this.db = db;
  }
  [EnableQuery]
  public IActionResult Get()
  {
    return Ok(db.Customers);
  }

  [EnableQuery]
  public IActionResult Get(string key)
  {
    return Ok(db.Customers.Find(key));
  }
}
