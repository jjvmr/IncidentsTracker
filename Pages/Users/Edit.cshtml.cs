using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IncidentsTrackingSystem.Data;
using IncidentsTrackingSystem.Models;

namespace IncidentsTrackingSystem.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IncidentsTrackingSystem.Data.ProjHubContext _context;

        public EditModel(IncidentsTrackingSystem.Data.ProjHubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppUser AppUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.AppUsers.FindAsync(id);

            if (AppUser == null)
            {
                return NotFound();
            }
            return  Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var userToUpdate = await _context.AppUsers.FindAsync(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<AppUser>(
                userToUpdate,
                "AppUser",
                s => s.UserName, s => s.Email, s => s.Password))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool AppUserExists(int id)
        {
            return _context.AppUsers.Any(e => e.ID == id);
        }
    }
}
