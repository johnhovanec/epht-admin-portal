using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using epht_admin_portal.Models;

namespace epht_admin_portal.Pages.Config.ConfigTopic
{
    public class DeleteModel : PageModel
    {
        private readonly MdhephtContext _context;

        public DeleteModel(MdhephtContext context)
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

            var configtopic = await _context.ConfigTopics.FirstOrDefaultAsync(m => m.TopicId == id);

            if (configtopic == null)
            {
                return NotFound();
            }
            else
            {
                ConfigTopic = configtopic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configtopic = await _context.ConfigTopics.FindAsync(id);
            if (configtopic != null)
            {
                ConfigTopic = configtopic;
                _context.ConfigTopics.Remove(ConfigTopic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
