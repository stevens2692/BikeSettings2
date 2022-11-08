using BikeSettings2.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeSettings2.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Bike> Bikes { get; set; }
    }
}
