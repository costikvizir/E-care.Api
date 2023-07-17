using E_care.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace E_care.Dal
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<MedicalCenter> MedicalCenters { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
    }
}
