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
    public class IndexModel : PageModel
    {
        private readonly CarClub.Data.CarClubContext _context;

        public IndexModel(CarClub.Data.CarClubContext context)
        {
            _context = context;
        }

        public IList<BookingCars> BookingCars { get;set; }

        public async Task OnGetAsync()
        {
            BookingCars = await _context.BookingCars.ToListAsync();
        }
    }
}
