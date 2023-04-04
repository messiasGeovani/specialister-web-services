using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<ProfessionalEntity> Professionals { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<ProfileConnectionEntity> Connections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressEntity>()
                .HasOne(b => b.Person)
                .WithOne(i => i.Address)
                .HasForeignKey<PersonEntity>(b => b.AddressId);

            modelBuilder.Entity<AddressEntity>()
                .HasOne(b => b.Professional)
                .WithOne(i => i.CompanyAddress)
                .HasForeignKey<ProfessionalEntity>(b => b.AddressId);

            modelBuilder.Entity<UserEntity>()
                .HasOne(b => b.Profile)
                .WithOne(i => i.User)
                .HasForeignKey<ProfileEntity>(b => b.UserId);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
