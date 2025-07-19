using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IncidentsTrackingSystem.Data;
using IncidentsTrackingSystem.Models;

namespace IncidentsTrackingSystem.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IncidentsTrackingSystem.Data.ProjHubContext _context;

        public IndexModel(IncidentsTrackingSystem.Data.ProjHubContext context)
        {
            _context = context;
        }

        public IList<AppUser> AppUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AppUser = await _context.AppUsers.ToListAsync();
        }
    }
}
