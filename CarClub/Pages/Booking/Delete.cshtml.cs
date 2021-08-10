using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarClub.Data;
using CarClub.Models;

namespace CarClub.Pages.Booking
{
    public class DeleteModel : PageModel
    {
        private readonly CarClub.Data.CarClubContext _context;

        public DeleteModel(CarClub.Data.CarClubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookingCars BookingCars { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookingCars = await _context.BookingCars.FirstOrDefaultAsync(m => m.id == id);

            if (BookingCars == null)
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

            BookingCars = await _context.BookingCars.FindAsync(id);

            if (BookingCars != null)
            {
                _context.BookingCars.Remove(BookingCars);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
