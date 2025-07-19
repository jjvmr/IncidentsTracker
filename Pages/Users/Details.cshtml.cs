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
    public class DetailsModel : PageModel
    {
        private readonly IncidentsTrackingSystem.Data.ProjHubContext _context;

        public DetailsModel(IncidentsTrackingSystem.Data.ProjHubContext context)
        {
            _context = context;
        }

        public AppUser AppUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appuser = await _context.AppUsers.FirstOrDefaultAsync(m => m.ID == id);
            if (appuser == null)
            {
                return NotFound();
            }
            else
            {
                AppUser = appuser;
            }
            return Page();
        }
    }
}
