using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KariyerBackendApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Employer> Employers { get; set; } = default!;

        public DbSet<Job> Jobs { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Employer>(entity =>
            {

                entity.HasIndex(e => e.PhoneNumber).IsUnique();

            });

            modelBuilder.Entity<Job>()
           .HasOne(e => e.Employer)
           .WithMany(c => c.Jobs);
            base.OnModelCreating(modelBuilder);
        }
    }
}
