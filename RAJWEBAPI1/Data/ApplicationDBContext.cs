using Microsoft.EntityFrameworkCore;
using RAJWEBAPI1.Models.Domain;

namespace RAJWEBAPI1.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
