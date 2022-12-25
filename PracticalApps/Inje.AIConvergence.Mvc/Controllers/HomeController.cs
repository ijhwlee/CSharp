﻿using Inje.AIConvergence.Mvc.Models;
using Inje.AIConvergence.Shared;
using Inje.AIConvergence.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Console;

namespace Inje.AIConvergence.Mvc.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly NorthwindContext db;
  private readonly IHttpClientFactory clientFactory;

  public HomeController(ILogger<HomeController> logger, NorthwindContext db, IHttpClientFactory clientFactory)
  {
    _logger = logger;
    this.db = db;
    this.clientFactory = clientFactory;
  }

  [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
  public async Task<IActionResult> Index()
  {
    _logger.LogError("This is a serious error (not really!)");
    _logger.LogWarning("This is your first warning!");
    _logger.LogWarning("This is your second warning!");
    _logger.LogInformation("I am in the Index method of HomeController.");
    WriteLine("[DEBUG-hwlee]I am in the Index method of HomeController.");
    HomeIndexViewModel model = new
    (
      VisitorCount: (new Random()).Next(1, 1001),
      Categories: await db.Categories.ToListAsync(),
      Products: await db.Products.ToListAsync()
    );
    try
    {
      HttpClient client = clientFactory.CreateClient(name: "Minimal.WebApi");
      HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: "api/weather");
      HttpResponseMessage response = await client.SendAsync(request);
      ViewData["weather"] = await response.Content.ReadFromJsonAsync<WeatherForecast[]>();
    }
    catch(Exception ex)
    {
      _logger.LogWarning($"The Minimal.WebApi service is not responding. Exception: {ex.Message}");
      ViewData["weather"] = Enumerable.Empty<WeatherForecast>().ToArray();
    }
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
  public async Task<IActionResult> ProductDetail(int? id)
  {
    if(!id.HasValue)
    {
      return BadRequest("You must pass a product ID in the route, for example /Home/ProductDetail/21");
    }
    Product? model = await db.Products.SingleOrDefaultAsync( p => p.ProductId== id);
    if(model == null)
    {
      return NotFound($"ProductId {id} is not found.");
    }
    return View(model);
  }
  public IActionResult ModelBinding()
  {
    return View();
  }
  [HttpPost]
  public IActionResult ModelBinding(Thing thing)
  {
    //return View(thing);
    HomeModelBindingViewModel model = new(
      thing,
      !ModelState.IsValid,
      ModelState.Values.SelectMany(state => state.Errors).Select(error => error.ErrorMessage)
    );
    return View(model);
  }
  public IActionResult ProductsThatCostMoreThan(decimal? price)
  {
    if (!price.HasValue)
    {
      return BadRequest("You must pass a product price in the query string, for example, /Home/ProductsThatCostMoreThan?price=90");
    }
    IEnumerable<Product> model = db.Products
      .Include(p => p.Category)
      .Include(p => p.Supplier)
      .Where(p => p.UnitPrice > price);
    if (!model.Any())
    {
      return NotFound($"No products cost more than {price:$#,##0.00}.");
    }
    ViewData["MaxPrice"] = price.Value.ToString("$#,##0.00");
    return View(model);
  }
  public async Task<IActionResult> Customers(string country)
  {
    IEnumerable<Customer>? model;
    try
    {

      string uri;
      if (string.IsNullOrEmpty(country))
      {
        ViewData["Title"] = "All Customers Worldwide";
        uri = "api/customers";
      }
      else
      {
        ViewData["Title"] = $"Customers in {country}";
        uri = $"api/customers/?country={country}";
      }
      HttpClient client = clientFactory.CreateClient(name: "Inje.AIConvergence.WebApi");
      HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
      HttpResponseMessage response = await client.SendAsync(request);
      model = await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();
    }
    catch (Exception ex)
    {
      _logger.LogWarning($"The Minimal.WebApi service is not responding. Exception: {ex.Message}");
      ViewData["Title"] = "Customers List";
      model = null;
    }
    return View(model);
  }
  public async Task<IActionResult> Services()
  {
    WriteLine("[DEBUG-hwlee]HomeController:Services ==================");
    try
    {
      HttpClient client = clientFactory.CreateClient(name: "Inje.AIConvergence.OData");
      HttpRequestMessage request = new(method: HttpMethod.Get,
          requestUri: "catalog/products/?$filter=startswith(ProductName, 'Cha')&$select=ProductId,ProductName,UnitPrice");
      HttpResponseMessage response = await client.SendAsync(request);
      ViewData["productsCha"] = (await response.Content.ReadFromJsonAsync<ODataProducts>())?.Value;
    }
    catch (Exception ex)
    {
      _logger.LogWarning($"Inje.AIConvergence.OData service exception: {ex.Message}");
    }
    return View();
  }
}