using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using epht_admin_portal.Models;

namespace epht_admin_portal.Pages.Data.AsthmaNcdmStatewide
{
    public class EditModel : PageModel
    {
        private readonly MdhephtContext _context;

        public EditModel(MdhephtContext context)
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

            var asthmancdmstatewide =  await _context.AsthmaNcdmStatewides.FirstOrDefaultAsync(m => m.AsthmaStatewideId == id);
            if (asthmancdmstatewide == null)
            {
                return NotFound();
            }
            AsthmaNcdmStatewide = asthmancdmstatewide;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AsthmaNcdmStatewide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsthmaNcdmStatewideExists(AsthmaNcdmStatewide.AsthmaStatewideId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AsthmaNcdmStatewideExists(int id)
        {
            return _context.AsthmaNcdmStatewides.Any(e => e.AsthmaStatewideId == id);
        }
    }
}
