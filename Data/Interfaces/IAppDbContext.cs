using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Person> People { get; set; }


        Task<int> SaveChangesAsync();
    }
}
