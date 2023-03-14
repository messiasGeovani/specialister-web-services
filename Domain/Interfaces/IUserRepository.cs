using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> Get();
        ValueTask<User?> GetById(Guid id);
        Task<List<User>> Search(Expression<Func<User, bool>> query);
        Task Create(User user);
        Task Update(User user);
    }
}
