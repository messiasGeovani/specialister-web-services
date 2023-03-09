using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        ValueTask<User?> FindById(Guid id);
        Task<User?> Find(string username, string password);
    }
}
