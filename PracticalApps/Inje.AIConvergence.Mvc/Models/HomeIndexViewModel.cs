using System.Collections.Generic;
using Inje.AIConvergence.Shared;

namespace Inje.AIConvergence.Mvc.Models;

public class HomeIndexViewModel
{
  public HomeIndexViewModel(int VisitorCount, List<Category> Categories, List<Product> Products)
  {
    this.VisitorCount = VisitorCount;
    this.Categories = Categories;
    this.Products = Products;
  }

  public int VisitorCount { get; set; }
  public IList<Category> Categories { get; set; }
  public IList<Product> Products { get; set; }
}
