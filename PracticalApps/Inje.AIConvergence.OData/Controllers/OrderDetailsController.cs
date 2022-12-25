using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Inje.AIConvergence.Shared;
using static System.Console;

namespace Inje.AIConvergence.OData.Controllers;

public class OrderDetailsController : ODataController
{
  private readonly NorthwindContext db;
  public OrderDetailsController(NorthwindContext db)
  {
    this.db = db;
  }
  [EnableQuery]
  public IActionResult Get()
  {
    return Ok(db.OrderDetails);
  }

  [EnableQuery]
  public IActionResult Get(int key)
  {
    return Ok(db.OrderDetails.Find(key));
  }
}
