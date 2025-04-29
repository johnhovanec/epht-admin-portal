using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace epht_admin_portal.Pages.AsthmaNcdmStatewideSSISTest
{
    public class ErrorModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            // ErrorMessage will be automatically populated from the route value
        }
    }
}
