using System;
using System.Collections.Generic;

namespace epht_admin_portal.Models;

public partial class AsthmaSihisCounty
{
    public int AsthmaCountyId { get; set; }

    public string Mdcode { get; set; } = null!;

    public int Year { get; set; }

    public decimal Rate { get; set; }

    public int TypeId { get; set; }
}
