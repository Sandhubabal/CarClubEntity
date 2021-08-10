using Microsoft.EntityFrameworkCore;

namespace CarClub.Data
{
    public class CarClubContext : DbContext
    {
        public CarClubContext (DbContextOptions<CarClubContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; }

        public DbSet<Models.BookingCars> BookingCars { get; set; }

        public DbSet<Models.ContactUs> ContactUs { get; set; }
    }
}
