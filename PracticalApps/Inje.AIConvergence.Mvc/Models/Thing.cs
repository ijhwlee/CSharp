using System.ComponentModel.DataAnnotations;

namespace Inje.AIConvergence.Mvc.Models;

public class Thing
{
  [Range(1,10)]
  public int? Id { get; set; }
  [Required]
  public string? Color { get; set; }
  [EmailAddress]
  public string? EmailAddress { get; set;}
}
