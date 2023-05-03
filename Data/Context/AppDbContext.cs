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
        public DbSet<RatingEntity> ProfileRatings { get; set; }
        public DbSet<ProfessionalEntity> Professionals { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<ProfileConnectionEntity> Connections { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressEntity>()
                .HasOne(a => a.Person)
                .WithOne(i => i.Address)
                .HasForeignKey<PersonEntity>(a => a.AddressId);

            modelBuilder.Entity<AddressEntity>()
                .HasOne(a => a.Professional)
                .WithOne(i => i.CompanyAddress)
                .HasForeignKey<ProfessionalEntity>(a => a.AddressId);

            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.Profile)
                .WithOne(i => i.User)
                .HasForeignKey<ProfileEntity>(p => p.UserId);

            modelBuilder.Entity<RatingEntity>()
                .HasOne(r => r.Receiver)
                .WithMany(p => p.ReceivedRatings)
                .HasForeignKey(r => r.ReceiverID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RatingEntity>()
                .HasOne(r => r.Author)
                .WithMany(p => p.SentRatings)
                .HasForeignKey(r => r.AuthorID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
