namespace Domain.Shared.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> Get();
        ValueTask<T?> GetById(Guid id);
        Task Create(T model);
        Task Update(T model);
    }
}
