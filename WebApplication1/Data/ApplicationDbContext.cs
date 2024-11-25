using ABCMoneyTransfer.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCMoneyTransfer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Add DbSet for your sc_user table
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the sc_user table
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("sc_user"); // Map to sc_user table
                entity.HasKey(e => e.UserId); // Primary Key

                entity.Property(e => e.UserId).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsFixedLength().IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsFixedLength().IsRequired();
                entity.Property(e => e.Address).HasMaxLength(100).IsFixedLength();
                entity.Property(e => e.Email).HasMaxLength(100).IsFixedLength().IsRequired();
                entity.Property(e => e.Password).HasMaxLength(100).IsFixedLength().IsRequired();
                entity.Property(e => e.EnteredDate).IsRequired();
            });
        }
    }
}
