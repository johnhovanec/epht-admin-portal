using epht_admin_portal.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace epht_admin_portal.Models;

public partial class ConfigTopic
{
    public int TopicId { get; set; }

    [Required(ErrorMessage = "Topic Name is required.")]
    public string? TopicTitle { get; set; }

    [Required(ErrorMessage = "TopicUrlPath is required.")]
    [NoSpaces]
    public string? TopicUrlPath { get; set; }

    public string? Category { get; set; }

    public string? DefaultThemePath { get; set; }

    [StringLength(100, ErrorMessage = "Message can't exceed 100 characters")]
    public string? Overview { get; set; }

    public string? AboutData { get; set; }

    public string? CountySuppressionRuleRange { get; set; }

    public string? CountySuppressionRulePopMin { get; set; }

    public string? SubCountySuppressionRuleRange { get; set; }

    public string? SubCountySuppressionRulePopMin { get; set; }

    public bool? OmitNcdmData { get; set; }

    public string? ParentTopic { get; set; }

    //public bool? IsVisible { get; set; }
}
