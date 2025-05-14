using System.ComponentModel.DataAnnotations;

namespace epht_admin_portal.Models.Validation;
public class NoSpacesAttribute : ValidationAttribute
{
    public NoSpacesAttribute()
    {
        ErrorMessage = "Spaces are not allowed.";
    }

    public override bool IsValid(object value)
    {
        var strValue = value as string;
        return string.IsNullOrWhiteSpace(strValue) || !strValue.Contains(' ');
    }
}