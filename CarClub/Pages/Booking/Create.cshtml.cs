using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarClub.Data;
using CarClub.Models;
using Microsoft.EntityFrameworkCore;

namespace CarClub.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly CarClub.Data.CarClubContext _context;

        public CreateModel(CarClub.Data.CarClubContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> cars { get; set; }
        public async Task OnGet()
        {
            cars = await _context.Car.ToListAsync();
        }


        [BindProperty]
        public BookingCars BookingCars { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookingCars.Add(BookingCars);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
