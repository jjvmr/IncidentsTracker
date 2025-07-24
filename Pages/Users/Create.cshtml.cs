using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IncidentsTrackingSystem.Data;
using IncidentsTrackingSystem.Models;

namespace IncidentsTrackingSystem.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IncidentsTrackingSystem.Data.ProjHubContext _context;

        public CreateModel(IncidentsTrackingSystem.Data.ProjHubContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AppUser AppUser { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var emptyUser = new AppUser();
            if (await TryUpdateModelAsync<AppUser>(
                emptyUser,
                "AppUser",   // Prefix for form value.
                s => s.UserName, s => s.Email, s => s.Password))
            {
                // this is for adding a new user from form submission
                _context.AppUsers.Add(emptyUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            else
            {
                // Log model errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // or log issue
                }
            }

            return Page();

            // Uncomment the following lines if you want to validate the model state 
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

        }
    }
}
