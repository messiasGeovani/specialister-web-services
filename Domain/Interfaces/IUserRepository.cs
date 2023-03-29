using Domain.Entities;
using Domain.Shared.Interfaces;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<List<UserEntity>> Search(Expression<Func<UserEntity, bool>> query);
    }
}
