using System.Linq.Expressions;

namespace Domain.Shared.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> Get();
        ValueTask<T?> GetById(Guid id);
        Task<List<T>> Search(Expression<Func<T, bool>> query);
        Task Create(T model);
        Task Update(T model);
    }
}
