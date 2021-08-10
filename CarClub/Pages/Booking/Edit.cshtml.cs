using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarClub.Data;
using CarClub.Models;

namespace CarClub.Pages.Booking
{
    public class EditModel : PageModel
    {
        private readonly CarClub.Data.CarClubContext _context;

        public EditModel(CarClub.Data.CarClubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookingCars BookingCars { get; set; }
        public IEnumerable<Car> cars { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            cars = await _context.Car.ToListAsync();
        
        BookingCars = await _context.BookingCars.FirstOrDefaultAsync(m => m.id == id);

            if (BookingCars == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookingCars).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingCarsExists(BookingCars.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingCarsExists(int id)
        {
            return _context.BookingCars.Any(e => e.id == id);
        }
    }
}
