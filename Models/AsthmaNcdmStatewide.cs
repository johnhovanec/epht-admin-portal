using System;
using System.Collections.Generic;

namespace epht_admin_portal.Models;

public partial class AsthmaNcdmStatewide
{
    public int AsthmaStatewideId { get; set; }

    public int TypeId { get; set; }

    public string Mdcode { get; set; } = null!;

    public int Year { get; set; }

    public decimal Rate { get; set; }

    public int? GroupAgeId { get; set; }

    public string? RaceCode { get; set; }

    public string? GenderCode { get; set; }
}
