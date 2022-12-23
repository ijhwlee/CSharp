using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inje.AIConvergence.Shared;
using Inje.AIConvergence.WebApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics.Metrics;

namespace Inje.AIConvergence.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
  private ICustomerRepository repo;
  public CustomersController(ICustomerRepository repo)
  {
    WriteLine($"[DEBUG-hwlee]CustomersController:constructor called repo = {repo}");
    this.repo = repo;
  }
  [HttpGet]
  [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
  public async Task<IEnumerable<Customer>> GetCustomers(string? country)
  {
    WriteLine($"[DEBUG-hwlee]CustomersController:GetCustomers called country = {country}");
    if (string.IsNullOrWhiteSpace(country))
    {
      return await repo.RetrieveAllAsync();
    }
    else
    {
      return (await repo.RetrieveAllAsync()).Where(customer => customer.Country == country);
    }
  }
  [HttpGet("{id}", Name = nameof(GetCustomers))]
  [ProducesResponseType(200, Type = typeof(Customer))]
  [ProducesResponseType(404)]
  public async Task<IActionResult> GetCustomer(string id)
  {
    WriteLine($"[DEBUG-hwlee]CustomersController:GetCustomer called id = {id}");
    Customer? c = await repo.RetrieveAsync(id);
    if (c == null)
    {
      return NotFound();
    }
    return Ok(c);
  }
  [HttpPost]
  [ProducesResponseType(201, Type = typeof(Customer))]
  [ProducesResponseType(400)]
  public async Task<IActionResult> Create([FromBody] Customer c)
  {
    WriteLine($"[DEBUG-hwlee]CustomersController:Create called customer = {c}");
    if ( c== null)
    {
      return BadRequest();
    }
    c.Orders = new List<Order>();
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    Customer? added = await repo.CreateAsync(c);
    return CreatedAtRoute(
      routeName: nameof(GetCustomer),
      routeValues: new {id = added?.CustomerId.ToLower()},
      value: added);
  }
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(string id, [FromBody] Customer c)
  {
    WriteLine($"[DEBUG-hwlee]CustomersController:Update called id = {id}, customer = {c}");
    if ( c== null)
    {
      return BadRequest();
    }
    id = id.ToUpper();
    c.CustomerId = c.CustomerId.ToUpper();
    if(c.CustomerId != id)
    {
      return BadRequest();
    }
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    var existing = await repo.RetrieveAsync(id);
    if (existing == null)
    {
      return NotFound();
    }
    await repo.UpdateAsync(id, c);
    return new NoContentResult();
  }
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(string id)
  {
    WriteLine($"[DEBUG-hwlee]CustomersController:Delete called id = {id}");
    if (id == "bad")
    {
      var problemDetails = new ProblemDetails
      {
        Status = StatusCodes.Status400BadRequest,
        Type = "https://localhost:5003/customers/failed-to-delete",
        Title = $"Customer ID {id} found but failed to delete.",
        Detail = "More details like Company Name, Country and so on.",
        Instance = HttpContext.Request.Path
      };
      return BadRequest(problemDetails);
    }
    var existing = await repo.RetrieveAsync(id);
    if (existing == null)
    {
      return NotFound();
    }
    bool? deleted = await repo.DeleteAsync(id);
    if (deleted.HasValue && deleted.Value)
    {
      return new NoContentResult();
    }
    else
    {
      return BadRequest($"Customer {id} was found but failed to delete.");
    }
  }
}
