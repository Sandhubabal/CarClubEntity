using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarClub.Data;
using CarClub.Models;

namespace CarClub.Pages.Contact
{
    public class DeleteModel : PageModel
    {
        private readonly CarClub.Data.CarClubContext _context;

        public DeleteModel(CarClub.Data.CarClubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactUs ContactUs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactUs = await _context.ContactUs.FirstOrDefaultAsync(m => m.id == id);

            if (ContactUs == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactUs = await _context.ContactUs.FindAsync(id);

            if (ContactUs != null)
            {
                _context.ContactUs.Remove(ContactUs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
