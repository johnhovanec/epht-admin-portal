using System;
using System.Collections.Generic;

namespace epht_admin_portal.Models;

public partial class ConfigTopic
{
    public int TopicId { get; set; }

    public string? TopicTitle { get; set; }

    public string? TopicUrlPath { get; set; }

    public string? Category { get; set; }

    public string? DefaultThemePath { get; set; }

    public string? Overview { get; set; }

    public string? AboutData { get; set; }

    public string? CountySuppressionRuleRange { get; set; }

    public string? CountySuppressionRulePopMin { get; set; }

    public string? SubCountySuppressionRuleRange { get; set; }

    public string? SubCountySuppressionRulePopMin { get; set; }

    public bool? OmitNcdmData { get; set; }

    public string? ParentTopic { get; set; }

    public bool? IsVisible { get; set; }
}
