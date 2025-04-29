using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using epht_admin_portal.Models;

namespace epht_admin_portal.Pages.Data.AsthmaNcdmStatewide
{
    public class DeleteModel : PageModel
    {
        private readonly MdhephtContext _context;

        public DeleteModel(MdhephtContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.AsthmaNcdmStatewide AsthmaNcdmStatewide { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asthmancdmstatewide = await _context.AsthmaNcdmStatewides.FirstOrDefaultAsync(m => m.AsthmaStatewideId == id);

            if (asthmancdmstatewide == null)
            {
                return NotFound();
            }
            else
            {
                AsthmaNcdmStatewide = asthmancdmstatewide;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asthmancdmstatewide = await _context.AsthmaNcdmStatewides.FindAsync(id);
            if (asthmancdmstatewide != null)
            {
                AsthmaNcdmStatewide = asthmancdmstatewide;
                _context.AsthmaNcdmStatewides.Remove(AsthmaNcdmStatewide);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
