using Microsoft.EntityFrameworkCore;
using ParcelManager.Models;

namespace ParcelManager.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Parcel> Parcel { get; set; }
    }
}
