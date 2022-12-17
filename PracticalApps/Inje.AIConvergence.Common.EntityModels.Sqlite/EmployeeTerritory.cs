﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AIConvergence.Shared
{
    [Keyless]
    public partial class EmployeeTerritory
    {
        [Column(TypeName = "INT")]
        public long EmployeeId { get; set; }
        [Column(TypeName = "nvarchar] (20")]
        public string TerritoryId { get; set; } = null!;
    }
}
