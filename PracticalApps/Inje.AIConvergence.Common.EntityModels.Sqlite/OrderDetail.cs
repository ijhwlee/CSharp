﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inje.AIConvergence.Shared;

[Table("Order Details")]
[Index("OrderId", Name = "OrderId")]
[Index("OrderId", Name = "OrdersOrder_Details")]
[Index("ProductId", Name = "ProductId")]
[Index("ProductId", Name = "ProductsOrder_Details")]
public partial class OrderDetail
{
  [Key]
  [Column(TypeName = "INT")]
  public long OrderId { get; set; }
  [Key]
  [Column(TypeName = "INT")]
  public long ProductId { get; set; }
  [Column(TypeName = "money")]
  public decimal? UnitPrice { get; set; } = null!;
  [Column(TypeName = "smallint")]
  public long Quantity { get; set; }
  public double Discount { get; set; }

  [ForeignKey("OrderId")]
  [InverseProperty("OrderDetails")]
  public virtual Order Order { get; set; } = null!;
  [ForeignKey("ProductId")]
  [InverseProperty("OrderDetails")]
  public virtual Product Product { get; set; } = null!;
}
