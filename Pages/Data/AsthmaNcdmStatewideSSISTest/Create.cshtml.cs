using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using epht_admin_portal.Models;

namespace epht_admin_portal.Pages.AsthmaNcdmStatewideSSISTest
{
    public class CreateModel : PageModel
    {
        private readonly epht_admin_portal.Models.MdhephtContext _context;

        public CreateModel(epht_admin_portal.Models.MdhephtContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.AsthmaNcdmStatewideSSISTest AsthmaNcdmStatewideSSISTest { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AsthmaNcdmStatewideSSISTests.Add(AsthmaNcdmStatewideSSISTest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
