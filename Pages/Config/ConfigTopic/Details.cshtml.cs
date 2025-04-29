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
    public class DetailsModel : PageModel
    {
        private readonly MdhephtContext _context;

        public DetailsModel(MdhephtContext context)
        {
            _context = context;
        }

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
    }
}
