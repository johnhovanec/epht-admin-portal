using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using epht_admin_portal.Models;

namespace epht_admin_portal.Pages.Config.ConfigTopic
{
    public class EditModel : PageModel
    {
        private readonly MdhephtContext _context;

        public EditModel(MdhephtContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.ConfigTopic ConfigTopic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configtopic =  await _context.ConfigTopics.FirstOrDefaultAsync(m => m.TopicId == id);
            if (configtopic == null)
            {
                return NotFound();
            }
            ConfigTopic = configtopic;
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

            _context.Attach(ConfigTopic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigTopicExists(ConfigTopic.TopicId))
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

        private bool ConfigTopicExists(int id)
        {
            return _context.ConfigTopics.Any(e => e.TopicId == id);
        }
    }
}
