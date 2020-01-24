using Microsoft.EntityFrameworkCore;
using quantum_it.Core.Models;

namespace quantum_it.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}