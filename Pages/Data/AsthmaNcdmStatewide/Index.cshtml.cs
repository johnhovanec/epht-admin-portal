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
    public class IndexModel : PageModel
    {
        private readonly MdhephtContext _context;

        public IndexModel(MdhephtContext context)
        {
            _context = context;
        }

        public IList<Models.AsthmaNcdmStatewide> AsthmaNcdmStatewide { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AsthmaNcdmStatewide = await _context.AsthmaNcdmStatewides.ToListAsync();
        }
    }
}
