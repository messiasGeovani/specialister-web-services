using Domain.Entities;
using Domain.Shared.Interfaces;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> Search(Expression<Func<User, bool>> query);
    }
}
