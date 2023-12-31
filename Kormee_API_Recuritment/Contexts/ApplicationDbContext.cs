using Kormee_API_Recuritment.Model;
using Microsoft.EntityFrameworkCore;

namespace Kormee_API_Recuritment.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>().ToTable("Registers").HasKey(k => k.Id);
            modelBuilder.Entity<Login>().ToTable("Logins").HasKey(k => k.Id);
        }
    }
}
