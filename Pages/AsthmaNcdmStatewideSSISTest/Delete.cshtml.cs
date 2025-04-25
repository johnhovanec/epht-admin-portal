using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using epht_admin_portal.Models;

namespace epht_admin_portal.Pages.AsthmaNcdmStatewideSSISTest
{
    public class DeleteModel : PageModel
    {
        private readonly epht_admin_portal.Models.MdhephtContext _context;

        public DeleteModel(epht_admin_portal.Models.MdhephtContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.AsthmaNcdmStatewideSSISTest AsthmaNcdmStatewideSSISTest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asthmancdmstatewidessistest = await _context.AsthmaNcdmStatewideSSISTests.FirstOrDefaultAsync(m => m.AsthmaStatewideId == id);

            if (asthmancdmstatewidessistest == null)
            {
                return NotFound();
            }
            else
            {
                AsthmaNcdmStatewideSSISTest = asthmancdmstatewidessistest;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asthmancdmstatewidessistest = await _context.AsthmaNcdmStatewideSSISTests.FindAsync(id);
            if (asthmancdmstatewidessistest != null)
            {
                AsthmaNcdmStatewideSSISTest = asthmancdmstatewidessistest;
                _context.AsthmaNcdmStatewideSSISTests.Remove(AsthmaNcdmStatewideSSISTest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
