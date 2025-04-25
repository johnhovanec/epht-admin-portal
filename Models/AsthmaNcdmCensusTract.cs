using System;
using System.Collections.Generic;

namespace epht_admin_portal.Models;

public partial class AsthmaNcdmCensusTract
{
    public int AsthmaCensusTractId { get; set; }

    public int TypeId { get; set; }

    public string Mdcode { get; set; } = null!;

    public string? TractCode { get; set; }

    public int Year { get; set; }

    public decimal Rate { get; set; }

    public int Counts { get; set; }
}
