using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<PersonEntity> People { get; set; }
        DbSet<RatingEntity> ProfileRatings { get; set; }
        DbSet<ProfessionalEntity> Professionals { get; set; }
        DbSet<ProfileEntity> Profiles { get; set; }
        DbSet<ProfileConnectionEntity> Connections { get; set; }
        DbSet<MessageEntity> Messages { get; set; }
        DbSet<AddressEntity> Addresses { get; set; }

        Task<int> SaveChangesAsync();
    }
}
