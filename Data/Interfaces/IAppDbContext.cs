using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}
