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
    public class IndexModel : PageModel
    {
        private readonly MdhephtContext _context;

        public IndexModel(MdhephtContext context)
        {
            _context = context;
        }

        public IList<Models.ConfigTopic> ConfigTopic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ConfigTopic = await _context.ConfigTopics.ToListAsync();
        }
    }
}
