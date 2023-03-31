using Domain.Entities;
using Domain.Shared.Interfaces;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IProfileRepository : IBaseRepository<ProfileEntity>
    {
        Task<List<ProfileEntity>> Search(Expression<Func<ProfileEntity, bool>> query);
        Task<ProfileEntity?> GetByUserId(Guid id);
    }
}
