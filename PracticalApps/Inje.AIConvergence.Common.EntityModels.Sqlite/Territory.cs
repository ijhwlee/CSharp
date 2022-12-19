using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inje.AIConvergence.Shared;

[Keyless]
public partial class Territory
{
  [Column(TypeName = "nvarchar (20")]
  [StringLength(20)]
  public string TerritoryId { get; set; } = null!;
  [Column(TypeName = "nchar (50")]
  [StringLength(50)]
  public string TerritoryDescription { get; set; } = null!;
  [Column(TypeName = "INT")]
  public long RegionId { get; set; }
}
