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
    public class IndexModel : PageModel
    {
        private readonly CarClub.Data.CarClubContext _context;

        public IndexModel(CarClub.Data.CarClubContext context)
        {
            _context = context;
        }

        public IList<ContactUs> ContactUs { get;set; }

        public async Task OnGetAsync()
        {
            ContactUs = await _context.ContactUs.ToListAsync();
        }
    }
}
