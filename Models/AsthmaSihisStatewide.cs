using System;
using System.Collections.Generic;

namespace epht_admin_portal.Models;

public partial class AsthmaSihisStatewide
{
    public int AsthmaStatewideId { get; set; }

    public string Mdcode { get; set; } = null!;

    public int Year { get; set; }

    public decimal Rate { get; set; }

    public int TypeId { get; set; }

    public string RaceCode { get; set; } = null!;
}
