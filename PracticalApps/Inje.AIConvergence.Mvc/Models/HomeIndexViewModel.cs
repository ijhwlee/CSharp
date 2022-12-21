using System.Collections.Generic;
using Inje.AIConvergence.Shared;

namespace Inje.AIConvergence.Mvc.Models;

public record HomeIndexViewModel
(
  int VisitorCount,
  IList<Category> Categories,
  IList<Product> Products
);
