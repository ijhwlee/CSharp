﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Inje.AIConvergence.Shared
{
  [Index("City", Name = "City")]
  [Index("CompanyName", Name = "CompanyName")]
  [Index("PostalCode", Name = "PostalCode")]
  [Index("Region", Name = "Region")]
  public partial class Customer
  {
    public Customer()
    {
      Orders = new HashSet<Order>();
      CustomerTypes = new HashSet<CustomerDemographic>();
    }

    [Key]
    [Required]
    [Column("CustomerID")]
    [StringLength(5)]
    [RegularExpression("[A-Z]{5}")]
    public string CustomerId { get; set; } = null!;
    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; } = null!;
    [StringLength(30)]
    public string? ContactName { get; set; }
    [StringLength(30)]
    public string? ContactTitle { get; set; }
    [StringLength(60)]
    public string? Address { get; set; }
    [StringLength(15)]
    public string? City { get; set; }
    [StringLength(15)]
    public string? Region { get; set; }
    [StringLength(10)]
    public string? PostalCode { get; set; }
    [StringLength(15)]
    public string? Country { get; set; }
    [StringLength(24)]
    public string? Phone { get; set; }
    [StringLength(24)]
    public string? Fax { get; set; }

    [InverseProperty("Customer")]
    [XmlIgnore]
    public virtual ICollection<Order> Orders { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Customers")]
    [XmlIgnore]
    public virtual ICollection<CustomerDemographic> CustomerTypes { get; set; }
  }
}
