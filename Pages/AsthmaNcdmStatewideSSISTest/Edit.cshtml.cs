using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using epht_admin_portal.Models;

namespace epht_admin_portal.Pages.AsthmaNcdmStatewideSSISTest
{
    public class EditModel : PageModel
    {
        private readonly epht_admin_portal.Models.MdhephtContext _context;

        public EditModel(epht_admin_portal.Models.MdhephtContext context)
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

            var asthmancdmstatewidessistest =  await _context.AsthmaNcdmStatewideSSISTests.FirstOrDefaultAsync(m => m.AsthmaStatewideId == id);
            if (asthmancdmstatewidessistest == null)
            {
                return NotFound();
            }
            AsthmaNcdmStatewideSSISTest = asthmancdmstatewidessistest;
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

            _context.Attach(AsthmaNcdmStatewideSSISTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsthmaNcdmStatewideSSISTestExists(AsthmaNcdmStatewideSSISTest.AsthmaStatewideId))
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

        private bool AsthmaNcdmStatewideSSISTestExists(int id)
        {
            return _context.AsthmaNcdmStatewideSSISTests.Any(e => e.AsthmaStatewideId == id);
        }
    }
}
