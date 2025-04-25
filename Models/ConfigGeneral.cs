using System;
using System.Collections.Generic;

namespace epht_admin_portal.Models;

public partial class ConfigGeneral
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }
}
