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
    public class IndexModel : PageModel
    {
        private readonly epht_admin_portal.Models.MdhephtContext _context;

        public IndexModel(epht_admin_portal.Models.MdhephtContext context)
        {
            _context = context;
        }

        public IList<Models.AsthmaNcdmStatewideSSISTest> AsthmaNcdmStatewideSSISTest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AsthmaNcdmStatewideSSISTest = await _context.AsthmaNcdmStatewideSSISTests.ToListAsync();
        }
    }
}
