using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<PersonEntity> People { get; set; }


        Task<int> SaveChangesAsync();
    }
}
