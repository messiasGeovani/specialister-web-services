using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> Get();
        ValueTask<User?> GetById(Guid id);
        Task Create(User user);
        Task Update(User user);
    }
}
