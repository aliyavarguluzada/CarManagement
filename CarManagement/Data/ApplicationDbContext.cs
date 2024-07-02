using CarManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        
    }
}
