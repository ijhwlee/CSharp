using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Inje.AIConvergence.Shared;
using static System.Console;

namespace Inje.AIConvergence.OData.Controllers;

public class OrdersControllercs : ODataController
{
  private readonly NorthwindContext db;
  public OrdersControllercs(NorthwindContext db)
  {
    this.db = db;
  }
  [EnableQuery]
  public IActionResult Get()
  {
    return Ok(db.Orders);
  }

  [EnableQuery]
  public IActionResult Get(int key)
  {
    return Ok(db.Orders.Find(key));
  }
}
