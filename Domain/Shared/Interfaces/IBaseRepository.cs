namespace Domain.Shared.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> Get();
        ValueTask<T?> GetById(Guid id);
        Task Create(T model);
        Task Update(T model);
    }
}
